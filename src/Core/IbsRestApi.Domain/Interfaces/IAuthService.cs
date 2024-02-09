using IbsRestApi.Application.AuthModels;

namespace IbsRestApi.Domain.Interfaces;

public interface IAuthService
{
    Task<LoginResult> LoginWithPassword(string loginId, string password);
    void LogToken(string token, DateTime expiryDate, string username);
    Task<UserAuthModel> FindUser(string param);

    Task<UserModel> FindUserAccount(string param);

    Task<PersonModel> FindPerson(int ucid);
}
