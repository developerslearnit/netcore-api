using IbsRestApi.Api.Contracts;
using IbsRestApi.Api.Controllers;
using IbsRestApi.Api.Helpers;
using IbsRestApi.Application.AuthModels;
using IbsRestApi.Application.Contracts;
using IbsRestApi.Application.IbsMdm;
using IbsRestApi.Communications;
using IbsRestApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IbsRestApi.Api.Areas.Auth.Controllers;

[ApiVersion("1.0")]
[Route("api/core/v{v:apiversion}/client")]
[ApiController]
public class OnboardController : BaseController
{

    private readonly IAppService _appService;
    private readonly IConfiguration _config;
    private readonly IAPIHelpers _apiHelper;
    private readonly IMailKitService _mailSender;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public OnboardController(IAppService appService, IConfiguration config, IAPIHelpers apiHelper, IMailKitService mailSender, IHttpContextAccessor httpContextAccessor)
    {
        _appService = appService;
        _config = config;
        _apiHelper = apiHelper;
        _mailSender = mailSender;
        _httpContextAccessor = httpContextAccessor;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="accountCode"></param>
    /// <returns></returns>
    [HttpGet(ApiRoutes.OnboardingRoutes.ClientFullDetails)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<ClientFullModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FetchCustomer([FromRoute] string accountCode)
    {
        if (string.IsNullOrWhiteSpace(accountCode))
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<ClientFullModel>
            {
                statusCode = StatusCodes.Status400BadRequest,
                hasError = true,
                message = "Bad request"
            });
        }

        _ = int.TryParse(accountCode, out int ucid);
        var isExisting = await _appService.MdmService.FetchCustomerByUCID(ucid);

        if (isExisting.ucid == 0)
        {
            ucid = _appService.PortfolioService.GetUCIDWithAccountCode(accountCode);
            isExisting = await _appService.MdmService.FetchCustomerByUCID(ucid);
        }

        if (isExisting.ucid == 0) return StatusCode(StatusCodes.Status200OK, new ApiResponse<ClientFullModel>
        {
            statusCode = StatusCodes.Status404NotFound,
            message = "Not found",
            hasError = true
        });

        var nextOfKin = _appService.MdmService.FetchPersonNOK(isExisting.ucid).ToList();
        var customerBanks = _appService.MdmService.GetPersonBankAccounts(isExisting.ucid).ToList();
        var minors = _appService.MdmService.FetchCustomersMinior(isExisting.ucid).ToList();

        ClientFullModel clientFullModel = new()
        {
            email = isExisting.email,
            firstName = isExisting.firstName,
            lastName = isExisting.lastName,
            client_unique_ref = isExisting.ucid,
            otherNames = isExisting.Othername,
            address = isExisting.address_line1,
            phoneNumber = isExisting.mobile_phone,
            bvn = isExisting.bvn,
            birth_date = isExisting.dateOfbirth.ToString("dd/MM/yyyy"),
            banks = customerBanks,
            nextOfKin = nextOfKin,
            minors = minors,
            profilePictureUrl = isExisting.PhotoImage
        };

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<ClientFullModel>
        {
            message = "Customer found",
            data = clientFullModel,
            hasError = false
        });
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet(ApiRoutes.OnboardingRoutes.GetRelationships)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<RelationShipModel>>), StatusCodes.Status200OK)]
    public IActionResult GetRelationships()
    {
        var relationShips = _appService.MdmService.GetRelationShips();
        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<RelationShipModel>>
        {
            message = "Successful",
            data = relationShips.Select(x => new RelationShipModel
            {
                relationShipId = x.IdRelationShip,
                name = x.RelationShip1
            }).ToList(),
            hasError = false
        });
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet(ApiRoutes.OnboardingRoutes.GetBanks)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<BankMinViewModel>>), StatusCodes.Status200OK)]
    public IActionResult GetInHouseBanks()
    {
        var inhouseBanks = _appService.MdmService.ListAllBanks();
        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<BankMinViewModel>>
        {
            message = "Successful",
            data = inhouseBanks.Where(x => !string.IsNullOrWhiteSpace(x.bankId)).Select(x => new BankMinViewModel
            {
                IdBank = x.bankId,
                name = x.bankName
            }).ToList(),
            hasError = false
        });
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost(ApiRoutes.OnboardingRoutes.AddOrUpdateNextOfKin)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<IbsPeopleNextOfKinResultModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddOrUpdateNextOfKin([FromBody] IbsPeopleNextOfKinModel model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<IbsPeopleNextOfKinResultModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });

        if (string.IsNullOrWhiteSpace(model.firstName) || string.IsNullOrWhiteSpace(model.lastName) ||
            string.IsNullOrWhiteSpace(model.phoneNumber) || string.IsNullOrWhiteSpace(model.email) ||
            string.IsNullOrWhiteSpace(model.address) || model.client_unique_ref == 0
            || model.idRelationship == 0)
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleNextOfKinResultModel>
            {
                statusCode = StatusCodes.Status400BadRequest,
                hasError = true,
                message = "All field are required"
            });
        }

        var person = await _appService.MdmService.FetchCustomerByUCID(model.client_unique_ref);

        if (person.ucid == 0) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleNextOfKinResultModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            hasError = true,
            message = "User not found"
        });
        var relationship = _appService.MdmService.GetRelationShips().FirstOrDefault(x => x.IdRelationShip == model.idRelationship);
        if (relationship == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleNextOfKinResultModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            hasError = true,
            message = "Invalid Relationship"
        });
        bool isSaved = false;
        int id;
        if (model.id != 0)
        {
            var existingNextOfKin = _appService.MdmService.FetchPersonNOK(model.client_unique_ref).FirstOrDefault(x => x.id == model.id);
            if (existingNextOfKin == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleNextOfKinResultModel>
            {
                statusCode = StatusCodes.Status404NotFound,
                hasError = true,
                message = "Next of Kin does not exist"
            });
            isSaved = await _appService.MdmService.UpdateNextOfKin(model, model.id);
            id = model.id;
        }
        else
        {
            id = await _appService.MdmService.AddNextOfKin(model);
            isSaved = true;
        }

        if (isSaved) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleNextOfKinResultModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "User details updated",
            hasError = false,
            data = new IbsPeopleNextOfKinResultModel
            {
                id = id
            }
        });

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleNextOfKinResultModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "No change made to the user details",
            hasError = true
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost(ApiRoutes.OnboardingRoutes.AddOrUpdateBankDetail)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<IbsPeopleBankAccountResultModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddOrUpdateClientBankDetails([FromBody] IbsPeopleBankAccountModel model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<IbsPeopleBankAccountResultModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });

        if (string.IsNullOrWhiteSpace(model.AccountName) ||
            string.IsNullOrWhiteSpace(model.AccountNumber) || string.IsNullOrWhiteSpace(model.Bvn) ||
            string.IsNullOrWhiteSpace(model.IdBank) || model.client_unique_ref == 0)
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleBankAccountResultModel>
            {
                statusCode = StatusCodes.Status400BadRequest,
                hasError = true,
                message = "All field are required"
            });
        }

        var bank = _appService.MdmService.ListAllBanks().FirstOrDefault(x => x.bankId == model.IdBank);

        if (bank == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleBankAccountResultModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            hasError = true,
            message = "Invalid Bank Id"
        });

        var person = await _appService.MdmService.FetchCustomerByUCID(model.client_unique_ref);

        if (person.ucid == 0) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleBankAccountResultModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            hasError = true,
            message = "User not found"
        });

        var isSaved = false;
        int id;

        if (model.id != 0)
        {
            var exisitingBank = _appService.MdmService.GetPersonBankAccounts(model.client_unique_ref).FirstOrDefault(x => x.id == model.id);
            if (exisitingBank == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleBankAccountResultModel>
            {
                statusCode = StatusCodes.Status404NotFound,
                hasError = true,
                message = "Bank Account does not exist"
            });
            await _appService.MdmService.UpdatePersonBankAccount(model, model.id);
            isSaved = true;
            id = model.id;
        }
        else
        {
            id = await _appService.MdmService.AddPersonBankAccount(model);
            isSaved = true;
        }

        if (isSaved) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleBankAccountResultModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "User details updated",
            hasError = false,
            data = new IbsPeopleBankAccountResultModel
            {
                id = id
            }
        });

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleBankAccountResultModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "No change made to the user details",
            hasError = true
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ucid"></param>
    /// <returns></returns>
    [HttpGet(ApiRoutes.OnboardingRoutes.FetchBankDetail)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<IbsPeopleBankAccountModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FetchClientBankDetails([FromRoute] int ucid)
    {
        if (ucid <= 0)
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<IbsPeopleBankAccountModel>>
            {
                statusCode = StatusCodes.Status400BadRequest,
                hasError = true,
                message = "Bad request"
            });
        }

        var isExisting = await _appService.MdmService.FetchCustomerByUCID(ucid);

        if (isExisting.ucid == 0) return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<IbsPeopleBankAccountModel>>
        {
            statusCode = StatusCodes.Status404NotFound,
            message = "Not found",
            hasError = true
        });
        var customerBanks = _appService.MdmService.GetPersonBankAccounts(isExisting.ucid).ToList();

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<IbsPeopleBankAccountModel>>
        {
            message = "Customer banks found",
            data = customerBanks,
            hasError = false
        });
    }

    [HttpDelete(ApiRoutes.OnboardingRoutes.DeleteBankDetail)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<NullModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteClientBankDetails([FromRoute] int bankAccountId, int ucid)
    {
        if (bankAccountId <= 0 || ucid <= 0) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });

        var exisitingBank = _appService.MdmService.GetPersonBankAccounts(ucid).FirstOrDefault(x => x.id == bankAccountId);

        if (exisitingBank == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status404NotFound,
            hasError = true,
            message = "Bank Account does not exist"
        });
        var isSaved = await _appService.MdmService.DeletePersonBankAccount(bankAccountId, ucid);

        if (isSaved) return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Bank account Deleted",
            hasError = false,
        });

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "No change made to the user details",
            hasError = true
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost(ApiRoutes.OnboardingRoutes.AddOrUpdateMinor)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<IbsPeopleMinorResultModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddOrUpdateClientMinor([FromBody] IbsPeopleMinorUpdateModel model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<IbsPeopleMinorResultModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });

        if (string.IsNullOrWhiteSpace(model.firstName) || string.IsNullOrWhiteSpace(model.lastName) ||
            string.IsNullOrWhiteSpace(model.email) ||
            string.IsNullOrWhiteSpace(model.address_line1) || string.IsNullOrWhiteSpace(model.dateOfbirth) ||
            string.IsNullOrWhiteSpace(model.mobile_phone) || model.client_unique_ref == 0)
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleMinorResultModel>
            {
                statusCode = StatusCodes.Status400BadRequest,
                hasError = true,
                message = "All field are required"
            });
        }

        var person = await _appService.MdmService.FetchCustomerByUCID(model.client_unique_ref);

        if (person.ucid == 0) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleMinorResultModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            hasError = true,
            message = "Parent not found"
        });

        if (!model.dateOfbirth.Contains("/")) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleMinorResultModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Invalid date of birth. Date should be in format 'dd/MM/yyyy'",
            hasError = true
        });

        var splittedDate = model.dateOfbirth.Split("/");

        model.dob = new DateTime(int.Parse(splittedDate[2]),
            int.Parse(splittedDate[1]), int.Parse(splittedDate[0]));

        bool isSaved = false;
        int ucid;

        if (model.ucid != 0)
        {
            var exisitingMinor = _appService.MdmService.FetchCustomersMinior(model.client_unique_ref).FirstOrDefault(x => x.ucid == model.ucid);
            if (exisitingMinor == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleMinorResultModel>
            {
                statusCode = StatusCodes.Status404NotFound,
                hasError = true,
                message = "Minor does not exist"
            });
            isSaved = await _appService.MdmService.UpdatePersonMinor(model, model.ucid);
            ucid = model.ucid;
        }
        else
        {
            ucid = await _appService.MdmService.AddPersonMinor(model);
            isSaved = true;
        }

        if (isSaved) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleMinorResultModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "User details updated",
            hasError = false,
            data = new IbsPeopleMinorResultModel
            {
                ucid = ucid
            }
        });

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<IbsPeopleMinorResultModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "No change made to the user details",
            hasError = true
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost(ApiRoutes.OnboardingRoutes.AddOrUpdateProfilePicture)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddOrUpdateClientProfilePicture()
    {
        var request = await HttpContext.Request.ReadFormAsync();

        if (!request.Files.Any()) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status200OK,
            message = "No image sent",
            hasError = true
        });

        var file = request.Files[0];

        var rawUcid = request["ucid"].FirstOrDefault();

        if (string.IsNullOrEmpty(rawUcid))
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
            {
                statusCode = StatusCodes.Status400BadRequest,
                message = "No ucid sent",
                hasError = true
            });
        }

        if (!int.TryParse(rawUcid, out int ucid))
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
            {
                statusCode = StatusCodes.Status400BadRequest,
                message = "Invalid ucid sent",
                hasError = true
            });
        }


        var person = await _appService.MdmService.FetchCustomerByUCID(ucid);

        if (person.ucid == 0) return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status400BadRequest,
            hasError = true,
            message = "User not found"
        });
        var previousProfilePicture = _appService.MdmService.FetchPersonProfilePicturePath(ucid);
        var path = await _appService.FileStorageService.EditFile(file, previousProfilePicture);
        // var baseUrl = _config.GetValue<string>("BaseUrl");
        var uriBuilder = new UriBuilder(_httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host.Host, _httpContextAccessor.HttpContext.Request.Host.Port ?? -1);
        if (uriBuilder.Uri.IsDefaultPort)
        {
            uriBuilder.Port = -1;
        }
        var baseUrl = uriBuilder.Uri.AbsoluteUri;
        var folder = _config.GetValue<string>("ImageFolder");
        var fullPath = Path.Combine(baseUrl, folder, path).Replace("\\", "/");
        var isSaved = await _appService.MdmService.SavePersonProfilePicturePath(fullPath, ucid);

        if (isSaved)
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
            {
                statusCode = StatusCodes.Status200OK,
                message = "User details updated",
                hasError = false,
                data = fullPath
            });
        }

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "No change made to the user details",
            hasError = true
        });
    }


    [HttpPost(ApiRoutes.OnboardingRoutes.UploadAvatar)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<UserAvatarModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> UploadUserAvatar()
    {
        var request = await HttpContext.Request.ReadFormAsync();

        if (!request.Files.Any()) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status200OK,
            message = "No image sent",
            hasError = true
        });

        var file = request.Files.FirstOrDefault();

        if (file == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status200OK,
            message = "No image sent",
            hasError = true
        });

        var rawUcid = request["ucid"].FirstOrDefault();

        if (string.IsNullOrEmpty(rawUcid))
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
            {
                statusCode = StatusCodes.Status200OK,
                message = "No ucid sent",
                hasError = true
            });
        }

        if (!int.TryParse(rawUcid, out int ucid))
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Invalid ucid sent",
                hasError = true
            });
        }

        var person = await _appService.MdmService.FetchCustomerByUCID(ucid);

        if (person == null || person.ucid == 0) return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status200OK,
            hasError = true,
            message = "User not found"
        });

        var uploadPath = await _apiHelper.UploadUserAvatar(file);

        var uriBuilder = new UriBuilder(_httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host.Host, _httpContextAccessor.HttpContext.Request.Host.Port ?? -1);
        if (uriBuilder.Uri.IsDefaultPort)
        {
            uriBuilder.Port = -1;
        }
        var baseUrl = uriBuilder.Uri.AbsoluteUri;

        var fullPathUri = Path.Combine(baseUrl, uploadPath);

        var serveAvatarAsBase64String = _config.GetValue<bool>("ServeAvatarAsBase64String");

        var isSaved = await _appService.MdmService.SavePersonProfilePicturePath(fullPathUri, ucid);

        var avatarUri = fullPathUri;

        if(serveAvatarAsBase64String)
        {
            var fileBytes = System.IO.File.ReadAllBytes(uploadPath);
            avatarUri = Convert.ToBase64String(fileBytes);
        }

        if (isSaved)
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<UserAvatarModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "User details updated",
                hasError = false,
                data = new UserAvatarModel
                {
                    avatarUrl = avatarUri,
                    fileType = serveAvatarAsBase64String ? "base64" : "Url",
                    ucid = ucid
                }
            });
        }
        else
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
            {
                statusCode = StatusCodes.Status200OK,
                message = "There was an error uploading user avatar",
                hasError = true,                
            });
        }

    }





}
