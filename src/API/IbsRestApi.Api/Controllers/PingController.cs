using Microsoft.AspNetCore.Mvc;
using IbsRestApi.Common;
using IbsRestApi.Api.Extensions;
using Org.BouncyCastle.Ocsp;

namespace IbsRestApi.Api.Controllers;
[ApiVersion("1.0")]
[Route("api/core/v{v:apiversion}")]
[ApiController]
public class PingController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    //private HttpRequest _req;
    public PingController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
       // _req = req;
    }

    [HttpGet("ping")]
    public IActionResult PingServer()
    {
        try
        {
            var uriBuilder = new UriBuilder(_httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host.Host, _httpContextAccessor.HttpContext.Request.Host.Port ?? -1);
            if (uriBuilder.Uri.IsDefaultPort)
            {
                uriBuilder.Port = -1;
            }
            var baseUri = uriBuilder.Uri.AbsoluteUri;
            return StatusCode(StatusCodes.Status200OK, new {
                StatusCode = StatusCodes.Status200OK,
                Message = "Server running",
                BaseUri = baseUri,
                DateTimeRan = DateTime.Now,
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status200OK, new {
                StatusCode = StatusCodes.Status200OK,
                Message = "Server running with error " + ex.Message,
            });
        }
        
       
    }
}

//api/core/v
