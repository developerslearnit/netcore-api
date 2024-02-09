using IbsRestApi.Api.Contracts;
using IbsRestApi.Api.Helpers;
using IbsRestApi.Application.AuthModels;
using IbsRestApi.Application.CommonModels;
using IbsRestApi.Application.Contracts;
using IbsRestApi.Application.IbsMdm;
using IbsRestApi.Common;
using IbsRestApi.Communications;
using IbsRestApi.Communications.Model;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Entities.IbsMdm;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;

namespace IbsRestApi.Api.Areas.Auth.Controllers;

[ApiVersion("1.0")]
[Route("api/core/v{v:apiversion}/auth")]
[ApiController]
//[APIKeyAuth]
public class AuthenticationController : ControllerBase
{
    SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
    private readonly IAppService _service;
    private readonly JWTSettings _jWTSettings;
    private readonly UserManager<OnlineUserAccount> _userManager;
    private readonly IWebHostEnvironment _env;
    private readonly IMailSender _mailSender;
    private readonly IAPIHelpers _apiHelper;
    private readonly IMailKitService _mailKitSender;
    private readonly IAppService _appService;
    private readonly IConfiguration _config;
    public AuthenticationController(IAppService service, IOptions<JWTSettings> jWTSettings, UserManager<OnlineUserAccount> userManager, IWebHostEnvironment env, IMailSender mailSender, IAPIHelpers apiHelper, IMailKitService mailKitSender, IAppService appService, IConfiguration config)
    {
        _service = service;
        _jWTSettings = jWTSettings.Value;
        _userManager = userManager;
        _env = env;
        _mailSender = mailSender;
        _apiHelper = apiHelper;
        _mailKitSender = mailKitSender;
        _appService = appService;
        _config = config;
    }

    [HttpPost(ApiRoutes.AuthRoutes.Login)]
    [ProducesResponseType(200)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(contentType: MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(LoginResult), StatusCodes.Status200OK)]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (model == null) return BadRequest("Username and password are required");

        if (string.IsNullOrWhiteSpace(model.userName) || string.IsNullOrWhiteSpace(model.password))
            return BadRequest("Username and password are required");

        var user = await _service.Auth.FindUser(model.userName);
        if (user == null) return StatusCode(StatusCodes.Status200OK,
            new LoginResult { message = "Wrong username or password", status = LoginStatus.Failed, hasError = true });



        var passwordSalt = user.passwordSalt;
        var passwordHash = model.password.ToSha512(passwordSalt);


        var signInResult = await _service.Auth.LoginWithPassword(model.userName, passwordHash);

        if (signInResult.status != LoginStatus.Success) return StatusCode(StatusCodes.Status200OK,
           new LoginResult
           {
               message = "Wrong username or password",
               status = signInResult.status,
               hasError = true
           });


        var person = await _service.Auth.FindPerson(signInResult.user.client_unique_ref);


        var avatarUri = person.avatarUrl;

        var returnUserAvatar = new UserAvatarModel
        {
            avatarUrl = avatarUri,
            fileType = "Url",
            ucid = signInResult.user.client_unique_ref,
            hasAvatar = false
        };

        if (!string.IsNullOrWhiteSpace(avatarUri))
        {

            returnUserAvatar.avatarUrl = avatarUri;
            returnUserAvatar.fileType = "Url";
            returnUserAvatar.ucid = signInResult.user.client_unique_ref;
            returnUserAvatar.hasAvatar = true;

            var serveAvatarAsBase64String = _config.GetValue<bool>("ServeAvatarAsBase64String");
            if (serveAvatarAsBase64String)
            {
                var splittedUri = avatarUri.Split("/");
                var fileName = splittedUri[splittedUri.Length - 1];
                var _rootPath = _env.WebRootPath;
                var uploadPath = Path.Combine(_rootPath, "avatars");
                var filePath = Path.Combine(uploadPath, fileName);
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                avatarUri = Convert.ToBase64String(fileBytes);
                returnUserAvatar.avatarUrl = avatarUri;
                returnUserAvatar.fileType = "base64";
                returnUserAvatar.hasAvatar = true;
            }
        }




        List<string> roles = new();

        var jwtToken = await ComputeToken(model.userName, roles);

        signInResult.user.access_token = jwtToken;

        if (person != null)
        {
            signInResult.user.mobilePhone = person.mobilePhone;
            signInResult.user.firstName = person.firstName;
            signInResult.user.lastName = person.lastName;
            signInResult.user.userAvatar = returnUserAvatar;

        }

        return StatusCode(StatusCodes.Status200OK, signInResult);



    }

    [HttpPost(ApiRoutes.AuthRoutes.Register)]
    [ProducesResponseType(200)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(contentType: MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ApiResponse<OnboardResult>), StatusCodes.Status200OK)]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] OnboardModel model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<OnboardResult>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });

        if (string.IsNullOrWhiteSpace(model.phoneNumber) ||
            string.IsNullOrWhiteSpace(model.firstName) ||
            string.IsNullOrWhiteSpace(model.lastName) ||
            string.IsNullOrWhiteSpace(model.email))
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
            {
                hasError = true,
                message = "All field are required"
            });
        }
        if (!string.IsNullOrWhiteSpace(model.bvn))
        {
            if (model.bvn.Length != 11) return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
            {
                statusCode = StatusCodes.Status200OK,
                message = "BVN should be 11 digit.",
                hasError = true
            });
        }

        if (model.phoneNumber.Length != 11) return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Phone number should be 11 digit.",
            hasError = true
        });

        if (!CommonHelper.IsValidPhoneNumber(model.phoneNumber)) return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Phone number is not valid.",
            hasError = true
        });

        var dob = DateTime.Now.AddYears(-20);

        if (!string.IsNullOrWhiteSpace(model.birth_date))
        {

            if (!model.birth_date.Contains("/")) return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Invalid date of birth. Date should be in format 'dd/MM/yyyy'",
                hasError = true
            });

            var splittedDate = model.birth_date.Split("/");

            dob = new DateTime(int.Parse(splittedDate[2]),
                 int.Parse(splittedDate[1]), int.Parse(splittedDate[0]));

            if (dob >= DateTime.Now) return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Invalid date of birth. Date should be in past.",
                hasError = true
            });

        }
        if (!string.IsNullOrWhiteSpace(model.idCountry))
        {
            var country = _service.MdmService.GetCountries().FirstOrDefault(x => x.IdCountry == model.idCountry);
            if (country == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Invalid country code.",
                hasError = true
            });
        }

        if (!string.IsNullOrWhiteSpace(model.idState))
        {
            var state = _service.MdmService.GetStates().FirstOrDefault(x => x.IdState == model.idState);
            if (state == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Invalid state id.",
                hasError = true
            });
        }

        if (!string.IsNullOrWhiteSpace(model.title))
        {
            var title = _service.MdmService.GetTitles().FirstOrDefault(x => x.Title == model.title);
            if (title == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Invalid title.",
                hasError = true
            });
        }

        if (model.idOccupation != 0)
        {
            var occupation = _service.MdmService.GetOccupations().FirstOrDefault(x => x.IdOccupation == model.idOccupation);
            if (occupation == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Invalid occupation id.",
                hasError = true
            });
        }

        PeopleViewModel person = new();
        PeopleViewModel peopleModel = new()
        {
            firstName = model.firstName,
            lastName = model.lastName,
            otherName = model.otherNames,
            Bvn = model.bvn,
            email = model.email,
            pccNumber = string.Empty,
            phoneNumber = model.phoneNumber,
            dateOfBirth = dob,
            addressLine1 = string.IsNullOrEmpty(model.address) ? "" : model.address,
            title = model.title,
            idCountry = model.idCountry,
            idState = model.idState,
            occupationId = model.idOccupation,
            gender = model.gender,
            maritalStatus = model.maritalStatus,
            sourceOfFund = model.sourceOfFund,
        };
        if (model.client_unique_ref > 0)
        {
            person = await _service.MdmService.GetPersonByUCID(model.client_unique_ref);
            if (person == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
            {
                statusCode = StatusCodes.Status404NotFound,
                message = "Customer not found",
                hasError = true
            });
            var samePerson = await _service.MdmService.FetchPeopleByEmail(model.email);
            if (samePerson is not null)
            {
                if (samePerson.ucid != model.client_unique_ref)
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
                    {
                        statusCode = StatusCodes.Status200OK,
                        message = $"A customer with the email address '{model.email}' already exist",
                        hasError = true
                    });
            }
            person = await _service.MdmService.UpdatePerson(peopleModel, model.client_unique_ref);
            var onlineUser = await _userManager.FindByEmailAsync(model.email);
            if (onlineUser == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
            {
                statusCode = StatusCodes.Status404NotFound,
                message = "Customer not found",
                hasError = true
            });
            //onlineUser.Email = peopleModel.email;
            //await _service.MdmService.UpdatePerson(onlineUser);
        }
        else
        {
            if (string.IsNullOrWhiteSpace(model.password)) return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
            {
                hasError = true,
                message = "Password is required"
            });

            var isExisting = await _service.MdmService.FetchPeopleByEmail(model.email);

            if (isExisting != null)
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
                {
                    statusCode = StatusCodes.Status200OK,
                    message = $"A customer with the email address '{model.email}' already exist",
                    hasError = true
                });


            //Create Person
            person = await _service.MdmService.AddPerson(peopleModel);
            //BindingAddress to portfolio contributor
            //There is no need of creating customer here
            //var portfolioContributorId = await _service.PortfolioService.OpenCustomerAccount(ucid: person.ucid, currencyId: "NGN", portfolioId: -1);


            var randomPassword = model.password;
            var passwordSalt = StringHelpers.RandomString(length: 500, symbols: true, lowerCase: true, numbers: true, upperCase: true);

            var hashedPassword = randomPassword.ToSha512(passwordSalt);

            var onlineUser = new OnlineUserAccount()
            {
                AccountCode = person.pccNumber,
                DateCreated = DateTime.Now,
                Email = person.email,
                IsActive = true,
                LoginPin = person.pccNumber,
                Password = hashedPassword,
                PasswordSalt = passwordSalt,
                Ucid = person.ucid,
                LastLoginDate = DateTime.Now,
                FailedPasswordTries = 0,
                AcceptTerms = model.accept_terms
            };
            _service.MdmService.CreateUserAccount(onlineUser);
            await _userManager.CreateAsync(onlineUser);
            await _service.KycService.SaveIbsPeopleKyc(person.ucid, 5000);

            var exMessage = string.Empty;

            try
            {
                var inHouseEmail = _service.SettingsService.GetSetting("CustomerCareEmail");
                var CustomerCareLines = _service.SettingsService.GetSetting("CustomerCareLines");
                var supportUrl = _service.SettingsService.GetSetting("COY_SUPPORT_URL");
                var companyName = _service.CashManagementService.FetchPreference().GetAwaiter().GetResult().CompanyName;
                var fullName = $"{person.firstName} {person.lastName}";

                var customerMail =  _apiHelper.BuildNewAccountTemplate(person.pccNumber, CustomerCareLines, companyName, fullName, randomPassword, supportUrl);
                var inhouseMailBody = _apiHelper.BuildNewAccountInHouseNotificatitonTemplate(person.pccNumber, companyName, fullName);

                await _mailSender.SendMail("Welcome", person.email, customerMail);
                await _mailSender.SendMail("New Account Notice", inHouseEmail, inhouseMailBody);

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
                {
                    message = model.client_unique_ref == 0 ? "Your registration was successful" : "Client details updated successful",
                    data = new OnboardResult
                    {
                        client_unique_ref = person.ucid,
                        currency = "NGN",
                        accountId = person.pccNumber,
                        email = person.email
                    },
                    hasError = false
                });
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;

            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
            {
                message = $"Error :: {exMessage}",
                hasError = true
            });

        }

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<OnboardResult>
        {
            message = $"We could not create your account at the moment please try again later",
            hasError = true
        });

    }

    [HttpPost(ApiRoutes.AuthRoutes.PasswordResetCode)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<NullModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> SendPasswordResetCode(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            // Don't reveal that the user does not exist or is not confirmed
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status200OK,
                hasError = false,
                message = "A password reset link has been sent to your email"
            });

        }
        var foundUser = await _service.MdmService.FetchCustomerByUCID(user.Ucid);
        _service.MdmService.UpdateToken(email);
        var resetCode = _service.MdmService.GeneratePasswordResetLink(email, true);
        var company = await _service.CashManagementService.FetchPreference();

        var mailBody = _apiHelper.BuildPasswordResetMobileTemplate(resetCode,
            foundUser.name, company.CompanyName);

        await _mailSender.SendMail("Password Reset", email, mailBody);

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status200OK,
            hasError = false,
            message = "A password reset code has been sent to your email"
        });
    }

    [HttpPost(ApiRoutes.AuthRoutes.PasswordReset)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<NullModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ResetPassword([FromBody] PasswordResetModel model)
    {
        if (model == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });
        if (string.IsNullOrWhiteSpace(model.password) || string.IsNullOrWhiteSpace(model.token))
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status400BadRequest,
                message = "Bad Request",
                hasError = true
            });


        var email = await _service.MdmService.GetPasswordRequest(model.token);

        if (string.IsNullOrWhiteSpace(email)) return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Invalid Reset password token",
            hasError = true
        });

        var isTokenExpired = await _service.MdmService.IsPasswordResetTokenExpires(model.token);

        if (isTokenExpired) return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "This password reset link has expired",
            hasError = true
        });

       

        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status404NotFound,
                message = "No such username found on the system",
                hasError = true
            });
        }

        if (!user.IsActive)
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status400BadRequest,
                message = "Your account has been disabled, please contact your administrator",
                hasError = true
            });
        }
        try
        {
            var salt = user.PasswordSalt;
            model.password = model.password.ToSha512(salt);

            var isChanged = await _service.MdmService.ResetPassword(model);

            if (!isChanged) return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Your account has been compromised, please contact your administrator",
                hasError = true
            });

            var foundUser = await _service.MdmService.FetchCustomerByUCID(user.Ucid);

            var coyName = _appService.SettingsService.GetSetting("COMPANY_NAME");

            var mailBody = _apiHelper.BuildPasswordResetConfirmationTemplate(foundUser.firstName, coyName);



            await _mailSender.SendMail("Password Reset Confirmation", email, mailBody);

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status200OK,
                hasError = false,
                message = "You have reset your password. Please proceed to login"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status200OK,
                hasError = true,
                message = ex.Message
            });
        }


    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost(ApiRoutes.AuthRoutes.ChangePassword)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<NullModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });
        if (string.IsNullOrWhiteSpace(model.newpassword) || string.IsNullOrWhiteSpace(model.oldpassword)) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });
        var appUser = await _service.Auth.FindUser(model.accountId.Trim());

        if (appUser == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Wrong user account or password",
            hasError = true
        });

        var passwordSalt = appUser.passwordSalt;
        var passwordFromDb = appUser.password;

        var suppliedPassword = model.oldpassword.ToSha512(passwordSalt);//  EncryptionAlg.ToSha512()

        //Verify Password
        var isValidPassword = passwordFromDb.Equals(suppliedPassword);

        if (!isValidPassword) return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Wrong user account or password",
            hasError = true
        });

        model.newpassword = model.newpassword.ToSha512(passwordSalt);
        model.oldpassword = passwordFromDb;
        var result = await _service.MdmService.ChangeuserPasswordAsync(model);

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status200OK,
            hasError = false,
            message = "Password Changed successfully"
        });
    }

    private async Task<string> ComputeToken(string username, List<string> roles)
    {

        var user = await _service.Auth.FindUserAccount(username);

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(AppConstants.JWT_SECRET_KEY);

        var claims = new List<Claim>
        {
             new Claim(ClaimTypes.Name, username),
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
             new Claim(ClaimTypes.Email,user.email),
              new Claim(ClaimTypes.GroupSid,user.client_unique_ref.ToString()),
        };

        if (roles.Any())
            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(_jWTSettings.tokenExipration),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature),
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    [HttpPost(ApiRoutes.OnboardingRoutes.SendEmailToken)]
    [ProducesResponseType(200)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(contentType: MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ApiResponse<ResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> SendEmailToken([FromBody] EmailOTPModel model, CancellationToken cancellationToken)
    {
        if (model == null)
            return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<ResponseModel>
            {
                hasError = true,
                message = "Bad Request",
                statusCode = StatusCodes.Status400BadRequest,
            });


        if (!model.email.IsEmailAddress()) return StatusCode(StatusCodes.Status200OK, new ApiResponse<ResponseModel>
        {
            hasError = true,
            message = "Invalid email address",
            statusCode = StatusCodes.Status200OK,
        });

        try
        {
            await semaphore.WaitAsync();
            var token = DateTime.Now.Ticks.ToString().Right(10);
            semaphore.Release();

            await _appService.SettingsService.AddEmailToken(model.email, token);

            //COMPANY_NAME
            var coyName = _appService.SettingsService.GetSetting("COMPANY_NAME");
            var emailBody = _apiHelper.BuildEmailConfirmationTemplate(coyName, model.email, token);


            var mailModel = new EmailViewModel(model.email, "Confirm Email", emailBody);
            //var smtpSettings = _appService.SettingsService.GetSMTPSettings();
            //var emailSent = await _mailKitSender.SendAsync(mailModel, smtpSettings, cancellationToken);
            await _mailSender.SendMail("Email Confirmation Token", model.email, emailBody);

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<ResponseModel>
            {
                hasError = false,
                message = "Email confirmation token sent",
                statusCode = StatusCodes.Status200OK,
            });


        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<ResponseModel>
            {
                hasError = true,
                message = "Internal server error",
                statusCode = StatusCodes.Status500InternalServerError,
            });

        }
    }

    [HttpPost(ApiRoutes.OnboardingRoutes.ConfirmEmailToken)]
    [ProducesResponseType(200)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(contentType: MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ApiResponse<ResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ConfirmEmailToken([FromBody] EmailOTPModel model, CancellationToken cancellationToken)
    {
        if (model == null)
            return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<ResponseModel>
            {
                hasError = true,
                message = "Bad Request",
                statusCode = StatusCodes.Status400BadRequest,
            });




        if (!model.email.IsEmailAddress()) return StatusCode(StatusCodes.Status200OK, new ApiResponse<ResponseModel>
        {
            hasError = true,
            message = "Invalid email address",
            statusCode = StatusCodes.Status200OK,
        });

        if (string.IsNullOrWhiteSpace(model.code)) return StatusCode(StatusCodes.Status200OK, new ApiResponse<ResponseModel>
        {
            hasError = true,
            message = "Invalid OTP Code",
            statusCode = StatusCodes.Status200OK,
        });

        try
        {

            var emailIsValid = await _appService.SettingsService.ValidateEmailToken(model.email, model.code);


            if (emailIsValid.HasError) return StatusCode(StatusCodes.Status200OK, new ApiResponse<ResponseModel>
            {
                hasError = true,
                message = emailIsValid.ErrorMessage,
                statusCode = StatusCodes.Status200OK,
            });

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<ResponseModel>
            {
                hasError = emailIsValid.HasError,
                message = emailIsValid.ErrorMessage,
                statusCode = StatusCodes.Status200OK,
            });


        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<ResponseModel>
            {
                hasError = true,
                message = "Internal server error",
                statusCode = StatusCodes.Status500InternalServerError,
            });

        }
    }


}

