using IbsRestApi.Api.Contracts;
using IbsRestApi.Api.Filters;
using IbsRestApi.Application.Contracts;
using IbsRestApi.Application.Portfolios;
using IbsRestApi.Application.WxIbsSecure;
using IbsRestApi.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IbsRestApi.Api.Areas.Setups.Controllers;


[ApiVersion("1.0")]
[Route("api/core/v{v:apiversion}")]
[ApiController]
public class BranchesController : ControllerBase
{
    private readonly IAppService _appService;

    public BranchesController(IAppService appService)
    {
        _appService = appService;
    }

    
    [HttpGet(ApiRoutes.SetupRoutes.AppBranches)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<BranchModel>>), StatusCodes.Status200OK)]
    public IActionResult Branches()
    {
        var branches = _appService.SettingsService.GetAllBarnches();

        return StatusCode(StatusCodes.Status200OK,
            new ApiResponse<List<BranchModel>>
            {
                data = branches,
                message = "Success",
                statusCode = StatusCodes.Status200OK,
                hasError = false
            });
    }

    [BranchFilter]
    [HttpGet(ApiRoutes.SetupRoutes.PublicProducts)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<ProductViewModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Products()
    {
        var products = await _appService.SetupService.FetchPublicPortfolios();
        var productWithBidPrice = _appService.SetupService.PortfoliosWithOfferAndBidPrice(products);

        return StatusCode(StatusCodes.Status200OK,
            new ApiResponse<List<ProductViewModel>>
            {
                data = productWithBidPrice.ToList(),
                message = "Success",
                statusCode = StatusCodes.Status200OK,
                hasError = false
            });
    }
}
