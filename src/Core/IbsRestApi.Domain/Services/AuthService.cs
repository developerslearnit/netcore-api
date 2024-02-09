using IbsRestApi.Application.AuthModels;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IbsRestApi.Domain.Services;

public class AuthService : IAuthService
{
    private readonly MdmContext _context;

    public AuthService(MdmContext context)
    {
        _context = context;
    }

    public async Task<PersonModel> FindPerson(int ucid)
    {
        return await _context.IbsPeople.AsNoTracking().Where(x => x.Ucid == ucid)
            .Select(p => new PersonModel
            {
                ucid = p.Ucid,
                accountId = p.PccNo ?? "",
                email = p.Email ?? " ",
                firstName = p.FirstName ?? "",
                lastName = p.LastName ?? "",
                mobilePhone = p.MobilePhone ?? "",
                avatarUrl = p.ProfilePictureUrl

            }).FirstOrDefaultAsync();
    }

    public async Task<UserAuthModel> FindUser(string param)
    {
        // UserAuthModel user = null;

        var user = await _context.OnlineUserAccounts.AsNoTracking().Where(x => x.AccountCode == param).Select(x => new UserAuthModel
        {
            userName = x.LoginPin,
            password = x.Password,
            passwordSalt = x.PasswordSalt
        }).FirstOrDefaultAsync();

        if (user == null)
        {
            user = await _context.OnlineUserAccounts.AsNoTracking().Where(x => x.Email == param).Select(x => new UserAuthModel
            {
                userName = x.LoginPin,
                password = x.Password,
                passwordSalt = x.PasswordSalt
            }).FirstOrDefaultAsync();
        }

        if (user == null)
        {
            user = await _context.OnlineUserAccounts.AsNoTracking().Where(x => x.LoginPin == param).Select(x => new UserAuthModel
            {
                userName = x.LoginPin,
                password = x.Password,
                passwordSalt = x.PasswordSalt
            }).FirstOrDefaultAsync();
        }

        return user;
    }

    public async Task<UserModel> FindUserAccount(string param)
    {
        var user = await _context.OnlineUserAccounts.AsNoTracking().Where(x => x.AccountCode == param).Select(x => new UserModel
        {
            email = x.Email,
            client_unique_ref = x.Ucid,
            accountId = x.AccountCode
        }).FirstOrDefaultAsync();

        if (user == null)
        {
            user = await _context.OnlineUserAccounts.AsNoTracking().Where(x => x.Email == param).Select(x => new UserModel
            {
                email = x.Email,
                client_unique_ref = x.Ucid,
                accountId = x.AccountCode
            }).FirstOrDefaultAsync();
        }

        if (user == null)
        {
            user = await _context.OnlineUserAccounts.AsNoTracking().Where(x => x.LoginPin == param).Select(x => new UserModel
            {
                email = x.Email,
                client_unique_ref = x.Ucid,
                accountId = x.AccountCode
            }).FirstOrDefaultAsync();
        }

        return user;
    }

    public async Task<LoginResult> LoginWithPassword(string loginId, string password)
    {
        var user = await _context.OnlineUserAccounts.AsNoTracking().FirstOrDefaultAsync(x => x.LoginPin == loginId);
        if (user == null)
            user = await _context.OnlineUserAccounts.AsNoTracking().FirstOrDefaultAsync(x => x.Email == loginId);

        if (user == null)
            user = await _context.OnlineUserAccounts.AsNoTracking().FirstOrDefaultAsync(x => x.AccountCode == loginId);

        if (user == null) return new LoginResult
        {
            status = LoginStatus.Failed,
            message = "Wrong username or password"
        };

        if (!user.IsActive) return new LoginResult
        {
            status = LoginStatus.Deactivated,
            message = "Wrong username or password"
        };

        if (!user.Password.Equals(password)) return new LoginResult
        {
            status = LoginStatus.Failed,
            message = "Wrong username or password"
        };

        return new LoginResult
        {
            status = LoginStatus.Success,
            message = "Login success",
            requiredPasswordChange = !user.LastLoginDate.HasValue,
            user = new UserModel
            {
                client_unique_ref = user.Ucid,
                email = user.Email ?? string.Empty,
                activeStatus = user.IsActive,
                accountId = user.AccountCode
            }
        };

    }

    public void LogToken(string token, DateTime expiryDate, string username)
    {
        throw new NotImplementedException();
    }
}
