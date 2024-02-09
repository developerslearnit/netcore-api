using IbsRestApi.Application.CommonModels;
using IbsRestApi.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace IbsRestApi.Api.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class APIKeyAuthAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {

        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();


        var _logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<APIKeyAuthAttribute>>();

        _logger.LogInformation("APIKey Auth Called");

        _logger.LogInformation("selected branch", context.HttpContext.Request.Headers[AppConstants.APIKEY_BRANCH]);

        var _appSetting = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var _aPIService = context.HttpContext.RequestServices.GetRequiredService<IIbsAPIService>();
        var isLive = _appSetting.GetValue<bool>("IsLive");
        var username = _appSetting.GetValue<string>("Client");
        var useDynamicUser = _appSetting.GetValue<bool>("UseDynamicUser");
        var forceBranchNameHeader = _appSetting.GetValue<bool>("ForceBranchNameHeader");

        if (useDynamicUser)
        {
            
                if (!context.HttpContext.Request.Headers.TryGetValue(AppConstants.APIKEY_CLIENT_USERNAME, out var clientUsername))
                {
                    var errorMessage = $"{AppConstants.APIKEY_CLIENT_USERNAME} is missing in the request header";

                    _logger.LogError(errorMessage);

                    context.Result = new UnauthorizedResult();

                    return;
                }

                if (StringValues.IsNullOrEmpty(clientUsername))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                username = clientUsername.First();
            

        }


        if (forceBranchNameHeader)
        {
            if (!allowAnonymous)
            {
                if (!context.HttpContext.Request.Headers.TryGetValue(AppConstants.APIKEY_BRANCH, out var branch))
                {
                    var errorMessage = $"{AppConstants.APIKEY_BRANCH} is missing in the request header";

                    _logger.LogError(errorMessage);

                    context.Result = new UnauthorizedResult();

                    return;
                }

                if (StringValues.IsNullOrEmpty(branch))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
        }




        var apiuserToken = _aPIService.GetTokenByUserName(username);

        if (apiuserToken == null)
        {
            _logger.LogError("API Key not found");
            context.Result = new UnauthorizedResult();
            return;
        }

        if (apiuserToken?.Active == false)
        {
            _logger.LogError("API Key is not active");
            context.Result = new UnauthorizedResult();
            return;
        }

        if (string.IsNullOrWhiteSpace(apiuserToken?.LiveToken) || string.IsNullOrWhiteSpace(apiuserToken?.TestToken))
        {
            _logger.LogError("API Key is not found");
            context.Result = new UnauthorizedResult();
            return;
        }

        var IbsHeaderKey = isLive ? apiuserToken?.LiveToken : apiuserToken?.TestToken;



        if (!context.HttpContext.Request.Headers.TryGetValue(AppConstants.APIKEY_KEY_NAME, out var potentialApiKey))
        {
            var errorMessage = $"{AppConstants.APIKEY_KEY_NAME} is missing in the request header";

            _logger.LogError(errorMessage);

            context.Result = new UnauthorizedResult();

            return;
        }

        if (!potentialApiKey.Equals(IbsHeaderKey))
        {
            var errorMessage = $"Wrong {AppConstants.APIKEY_KEY_NAME}";

            _logger.LogError(errorMessage);

            context.Result = new UnauthorizedResult();

            return;
        }


        await next();
    }

}
