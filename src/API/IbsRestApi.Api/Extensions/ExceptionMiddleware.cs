using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace IbsRestApi.Api.Extensions;

public static class ExceptionMiddleware
{
    public static void UseGlobalException(this IApplicationBuilder app, ILogger logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    logger.LogError(contextFeature.Error, $"Something went wrong: {contextFeature.Error}");
                    var response = JsonSerializer.Serialize(new {
                        statusCode = context.Response.StatusCode,
                        message = $"Internal Server Error",
                        hasError = true
                    });
                    await context.Response.WriteAsync(response);
                }
            });
        });
    }
}
