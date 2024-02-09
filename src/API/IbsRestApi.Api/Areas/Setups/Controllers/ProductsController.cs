using IbsRestApi.Api.Contracts;
using IbsRestApi.Api.Filters;
using IbsRestApi.Application.Contracts;
using IbsRestApi.Application.Portfolios;
using IbsRestApi.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IbsRestApi.Api.Areas.Setups.Controllers;


[ApiVersion("1.0")]
[Route("api/core/v{v:apiversion}/portfolios")]
[ApiController]
[APIKeyAuth]
public class ProductsController : ControllerBase
{
    private readonly IAppService _appService;

    public ProductsController(IAppService appService)
    {
        _appService = appService;
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<PortfolioViewModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Products()
    {

        try
        {
            var products = await _appService.SetupService.FetchOnlinePortfolios();

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<List<PortfolioViewModel>>
                {
                    data = products,
                    message = "Success",
                    statusCode = StatusCodes.Status200OK,
                    hasError = false
                });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status200OK,
               new ApiResponse<List<PortfolioViewModel>>
               {
                   data = null,
                   message = ex.Message,
                   statusCode = StatusCodes.Status200OK,
                   hasError = false
               });
        }

       
    }


    [HttpGet]
    [Route("tenors/{borrowTypeId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<TenorModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> LoadProductTenors([FromRoute] string borrowTypeId)
    {
        //TenorModel
        try
        {
            var tenors = await _appService.SetupService.FecthProductTenors(borrowTypeId);

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<List<TenorModel>>
                {
                    data = tenors,
                    message = "Success",
                    statusCode = StatusCodes.Status200OK,
                    hasError = false
                });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status200OK,
               new ApiResponse<List<PortfolioViewModel>>
               {
                   data = null,
                   message = ex.Message,
                   statusCode = StatusCodes.Status200OK,
                   hasError = false
               });
        }
    }
}
