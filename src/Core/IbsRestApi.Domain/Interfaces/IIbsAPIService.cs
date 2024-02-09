using Ibs.Persistence.IbsAPIEntities;
using IbsRestApi.Application.IbsAPI;

namespace IbsRestApi.Domain.Interfaces;
public interface IIbsAPIService
{
    APIUser AuthenticateClient(TokenRequestModel model);
    Task<LoginTokenModel> FetchLoginToken(string refreshToken, string username);
    APIUser FindUserByUserName(string username);
    ApiUserTokenModel GetTokenByUserName(string username);
    void LogToken(string token, DateTime expiryDate, string username);
    bool ValidateClientAPIKey(TokenRequestModel model);
}