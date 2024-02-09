using IbsRestApi.Api.Contracts;
using IbsRestApi.Api.Filters;
using IbsRestApi.Application.CommonModels;
using IbsRestApi.Application.Contracts;
using IbsRestApi.Application.IbsMdm;
using IbsRestApi.Application.IMoneytor;
using IbsRestApi.Application.Portfolios;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace IbsRestApi.Api.Areas.Setups.Controllers;

[ApiVersion("1.0")]
[Route("api/core/v{v:apiversion}")]
[ApiController]
[APIKeyAuth]
public class SetupsController : ControllerBase
{
    private readonly IAppService _appService;

    public SetupsController(IAppService appService)
    {
        _appService = appService;
    }

    [HttpGet(ApiRoutes.SetupRoutes.Products)]
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

    [HttpGet(ApiRoutes.SetupRoutes.ProductsByTypes)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<ProductViewModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ProductsByType([FromRoute] string product_type)
    {
        var products = await _appService.SetupService.FetchPublicPortfolios(product_type);
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

    [HttpGet(ApiRoutes.SetupRoutes.ProductsMinimal)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<PublicPortfolioMinViewModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllPortfoliosMin(string? product_type)
    {
        var products = await _appService.SetupService.FetchPublicPortfoliosMinDetails(product_type);

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<PublicPortfolioMinViewModel>>
        {
            statusCode = StatusCodes.Status200OK,
            data = products,
            message = "Success",
            hasError = false
        });
    }

    [HttpGet(ApiRoutes.SetupRoutes.FixedDepositRates)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<BorrowRateResponse>>), StatusCodes.Status200OK)]
    public IActionResult GetAllFixedDepositRates()
    {
        var rates = _appService.PortfolioService.FetchPublicFixedDepositRateGap().Select(x => new BorrowRateResponse()
        {
            interestRate = x.IntRate,
            effectiveDate = x.EffectiveDate.HasValue ? x.EffectiveDate.Value.ToString("dd/MM/yyyy") : "",
            fromAmount = x.FromAmount,
            toAmount = x.ToAmount,
            fromTenor = x.FromTenor,
            toTenor = x.ToTenor
        }).ToList();
        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<BorrowRateResponse>>
        {
            statusCode = StatusCodes.Status200OK,
            data = rates,
            message = "Success",
            hasError = false
        });
    }

    [HttpGet(ApiRoutes.SetupRoutes.Titles)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<string>>), StatusCodes.Status200OK)]
    public IActionResult GetTitles()
    {
        var titles = _appService.MdmService.GetTitles().Select(x => x.Title).ToList();
        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<string>>
        {
            statusCode = StatusCodes.Status200OK,
            message = "",
            hasError = false,
            data = titles
        });
    }

    [HttpGet(ApiRoutes.SetupRoutes.Occupations)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<OccupationViewModel>>), StatusCodes.Status200OK)]
    public IActionResult GetOccupations()
    {
        var occupation = _appService.MdmService.GetOccupations().Select(x => new OccupationViewModel
        {
            OccupationId = x.IdOccupation,
            Name = x.Occupation
        }).ToList();
        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<OccupationViewModel>>
        {
            message = "Successful",
            data = occupation,
            hasError = false
        });
    }

    [HttpGet(ApiRoutes.SetupRoutes.SourceOfFund)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<SourceOfFundViewModel>>), StatusCodes.Status200OK)]
    public IActionResult GetSourceOfFund()
    {
        var sourceOfFund = _appService.MdmService.GetSourceOfFund().Select(x => new SourceOfFundViewModel()
        {
            Id = x.IdSourceOfFund,
            Title = x.SourceOfFund1 ?? ""
        }).ToList();
        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<SourceOfFundViewModel>>
        {
            statusCode = StatusCodes.Status200OK,
            message = "",
            hasError = false,
            data = sourceOfFund
        });
    }
}
