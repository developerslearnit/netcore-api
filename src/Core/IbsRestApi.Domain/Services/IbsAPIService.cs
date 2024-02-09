using Ibs.Persistence.IbsAPIEntities;
using IbsRestApi.Application.IbsAPI;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbsRestApi.Domain.Services;
public class IbsAPIService : IIbsAPIService
{
    private readonly IbsApiContext _context;

    public IbsAPIService(IbsApiContext context)
    {
        _context = context;
    }

    public async Task<LoginTokenModel> FetchLoginToken(string refreshToken, string username)
    {
        return await _context.LoginToken.Where(x => x.AuthToken == refreshToken && x.Username == username)
             .AsNoTracking()
             .OrderByDescending(y => y.LoginTokenID)
             .Select(u => new LoginTokenModel { authToken = u.AuthToken, username = u.Username, expiryDate = u.ExpiryDate })
             .FirstOrDefaultAsync();
    }

    public void LogToken(string token, DateTime expiryDate, string username)
    {
        var logToken = new LoginToken()
        {
            AuthToken = token,
            ExpiryDate = expiryDate,
            Username = username
        };

        _context.LoginToken.Add(logToken);

        _context.SaveChanges();
    }

    public bool ValidateClientAPIKey(TokenRequestModel model)
    {
        return _context.APIUser
            .AsNoTracking()
             .Any(x => x.APIKey == model.consumerKey && x.APISecret == model.consumerSecret && x.Status == true);
    }


    public APIUser AuthenticateClient(TokenRequestModel model)
    {
        return _context.APIUser
            .AsNoTracking()
             .FirstOrDefault(x => x.HashedAPIKey == model.consumerKey && x.HashedAPISecret == model.consumerSecret && x.Status == true);
    }

    public APIUser FindUserByUserName(string username)
    {
        return _context.APIUser
            .AsNoTracking()
             .FirstOrDefault(x => x.UserName == username);
    }

    public ApiUserTokenModel GetTokenByUserName(string username)
    {
        return _context.APITokenUser
            .AsNoTracking()
             .Where(x => x.Name == username)
             .Select(u => new ApiUserTokenModel { APITokenUserId = u.APITokenUserId, Name = u.Name, LiveToken = u.LiveToken, TestToken = u.TestToken, Active = u.Active })
             .FirstOrDefault();
    }
}
