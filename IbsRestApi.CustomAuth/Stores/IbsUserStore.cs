using IbsRestApi.Entities.IbsMdm;
using Microsoft.AspNetCore.Identity;

namespace IbsRestApi.CustomAuth.Stores;

public class IbsUserStore : IUserStore<OnlineUserAccount>,
    IUserPasswordStore<OnlineUserAccount>, IUserEmailStore<OnlineUserAccount>,
    IPasswordHasher<OnlineUserAccount>
{

    private readonly UserStoreService _userStoreService;

    public IbsUserStore(UserStoreService userStoreService)
    {
        _userStoreService = userStoreService;
    }

    public async Task<IdentityResult> CreateAsync(OnlineUserAccount user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null) throw new ArgumentNullException(nameof(user));
        return await _userStoreService.CreateAsync(user);
    }

    public Task<IdentityResult> DeleteAsync(OnlineUserAccount user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {

    }

    public async Task<OnlineUserAccount> FindByEmailAsync(string email, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (email == null) throw new ArgumentNullException(nameof(email));

        return await _userStoreService.FindByEmailAsync(email);
    }

    public async Task<OnlineUserAccount> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (userId == null) throw new ArgumentNullException(nameof(userId));
        if (!int.TryParse(userId, out int idGuid))
        {
            throw new ArgumentException("Not a valid Guid id", nameof(userId));
        }

        return await _userStoreService.FindByIdAsync(idGuid);
    }

    public async Task<OnlineUserAccount> FindByNameAsync(string userName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (userName == null) throw new ArgumentNullException(nameof(userName));

        return await _userStoreService.FindByNameAsync(userName);
    }

    public Task<string> GetEmailAsync(OnlineUserAccount user, CancellationToken cancellationToken)
    {
        //throw new NotImplementedException();

        return Task.FromResult<string>(user.Email);
    }

    public Task<bool> GetEmailConfirmedAsync(OnlineUserAccount user, CancellationToken cancellationToken)
    {
        return Task.FromResult<bool>(true);
    }

    public Task<string> GetNormalizedEmailAsync(OnlineUserAccount user, CancellationToken cancellationToken)
    {
        return Task.FromResult<string>(user.Email);
    }

    public Task<string> GetNormalizedUserNameAsync(OnlineUserAccount user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetPasswordHashAsync(OnlineUserAccount user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserIdAsync(OnlineUserAccount user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null) throw new ArgumentNullException(nameof(user));

        return Task.FromResult(user.IdOnlineUserAccount.ToString());
    }

    public Task<string> GetUserNameAsync(OnlineUserAccount user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null) throw new ArgumentNullException(nameof(user));

        return Task.FromResult(user.AccountCode);
    }



    public Task<bool> HasPasswordAsync(OnlineUserAccount user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetEmailAsync(OnlineUserAccount user, string email, CancellationToken cancellationToken)
    {
        user.Email = email;
        return Task.FromResult<object>(null);
    }

    public Task SetEmailConfirmedAsync(OnlineUserAccount user, bool confirmed, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetNormalizedEmailAsync(OnlineUserAccount user, string normalizedEmail, CancellationToken cancellationToken)
    {

        return Task.FromResult<object>(null);
    }

    public Task SetNormalizedUserNameAsync(OnlineUserAccount user, string normalizedName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (normalizedName == null) throw new ArgumentNullException(nameof(normalizedName));

        //user.Username = normalizedName;
        return Task.FromResult<object>(null);
    }

    public Task SetPasswordHashAsync(OnlineUserAccount user, string passwordHash, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetUserNameAsync(OnlineUserAccount user, string userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> UpdateAsync(OnlineUserAccount user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public string HashPassword(OnlineUserAccount user, string password)
    {
        throw new NotImplementedException();
    }

    public PasswordVerificationResult VerifyHashedPassword(OnlineUserAccount user, string hashedPassword, string providedPassword)
    {
        var passwordFromDb = user.Password;
        var passwordSalt = user.PasswordSalt;



        throw new NotImplementedException();


    }

    public async Task<bool> VerifyPassword(string username, string password)
    {
        return await _userStoreService.CheckPasswordHashAsync(username, password);
    }

}
