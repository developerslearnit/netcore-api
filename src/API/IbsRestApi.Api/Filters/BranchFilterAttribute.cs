using IbsRestApi.Application.CommonModels;
using IbsRestApi.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace IbsRestApi.Api.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class BranchFilterAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var _appSetting = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        
        var forceBranchNameHeader = _appSetting.GetValue<bool>("ForceBranchNameHeader");

        if (forceBranchNameHeader)
        {

            if (!context.HttpContext.Request.Headers.TryGetValue(AppConstants.APIKEY_BRANCH, out var branch))
            {
                var errorMessage = $"{AppConstants.APIKEY_BRANCH} is missing in the request header";

                
                context.Result = new UnauthorizedResult();

                return;
            }

            if (StringValues.IsNullOrEmpty(branch))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

        }

        await next();
    }
}
