using IbsRestApi.Api.Contracts;
using IbsRestApi.Api.Controllers;
using IbsRestApi.Api.Filters;
using IbsRestApi.Api.Helpers;
using IbsRestApi.Application.Contracts;
using IbsRestApi.Application.IMoneytor;
using IbsRestApi.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IbsRestApi.Api.Areas.Investment.Controllers;

[ApiVersion("1.0")]
[Route("api/core/v{v:apiversion}")]
[ApiController]
public class DashboardController : BaseController
{
    private readonly IAppService _appService;

    public DashboardController(IAppService appService)
    {
        _appService = appService;
    }

    [HttpGet(ApiRoutes.DashboardRoutes.MututalFunds)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<ClientOwnedPortfolios>>), StatusCodes.Status200OK)]
    public IActionResult FetchClientMutualFundProducts([FromRoute] int clientId)
    {
        var model = _appService.PortfolioService.FetchClientOwnedPortfolios();

        var mutualFunds = model.Where(x => x.ucid == clientId && x.unitBased == true);

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<ClientOwnedPortfolios>>
        {
            statusCode = StatusCodes.Status200OK,
            message = "",
            hasError = false,
            data = mutualFunds.ToList()
        });
    }
    
    [HttpGet(ApiRoutes.DashboardRoutes.FixedDeposit)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<BorrowingProductViewModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FetchClientFixedDepositProducts([FromRoute] int clientId)
    {

        var portfolioContributor = await _appService.PortfolioService.GetPortfolioContributor(clientId, "NGN");

        var model = _appService.PortfolioService.AllBorrowing();

        if (portfolioContributor == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<BorrowingProductViewModel>>
        {
            statusCode = StatusCodes.Status200OK,
            message = "",
            hasError = false,
        });

        

        var fixedDeposits = model.Where(x => x.clientId == portfolioContributor.IdPortfolioContributor);

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<BorrowingProductViewModel>>
        {
            statusCode = StatusCodes.Status200OK,
            message = "",
            hasError = false,
            data = fixedDeposits.ToList()
        });
    }

    [HttpGet(ApiRoutes.DashboardRoutes.FixedDepositProduct)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<BorrowingProductViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FetchClientFixedDepositProduct([FromRoute] int clientId, int productId)
    {

        var portfolioContributor = await _appService.PortfolioService.GetPortfolioContributor(clientId, "NGN");

        var model = _appService.PortfolioService.AllBorrowing();

        var fixedDeposit = model.Where(x => x.clientId == portfolioContributor.IdPortfolioContributor && x.productId == productId).FirstOrDefault();

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<BorrowingProductViewModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "",
            hasError = false,
            data = fixedDeposit
        });
    }

    [HttpGet(ApiRoutes.DashboardRoutes.PortfolioBalance)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<GroupedClientInvestmentViewModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FetClientPortfolioBalance([FromRoute] int clientId)
    {
        var allInvestment = await _appService.PortfolioService.FetchClientInvestmentsWithBorrowingID(clientId);
        var groupedInvestment = allInvestment.GroupBy(x => new { x.Asset, x.Currency, x.ID_Portfolio, x.InvestmentModule, x.DatabaseName })
                                    .Select(g => new GroupedClientInvestmentViewModel()
                                    {
                                        assetName = g.Key.Asset,
                                        assetValue = g.Sum(s => s.AssetValue),
                                        currency = g.Key.Currency,
                                        idPortfolio = g.Key.ID_Portfolio,
                                        investmentModule = g.Key.InvestmentModule,
                                        databaseName = g.Key.DatabaseName
                                    }).ToList();

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<GroupedClientInvestmentViewModel>>
        {
            statusCode = StatusCodes.Status200OK,
            message = "",
            hasError = false,
            data = groupedInvestment
        });
    }


    [HttpGet(ApiRoutes.DashboardRoutes.AllClientInvestment)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<ClientInvestmentDTO>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> AllClientInvestment([FromRoute] int clientId, string branchId)
    {
        var allInvestment = await _appService.PortfolioService.FetchClientAllInvestments(clientId,branchId);
      
        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<ClientInvestmentDTO>>
        {
            statusCode = StatusCodes.Status200OK,
            message = "",
            hasError = false,
            data = allInvestment
        });
    }


    [HttpGet(ApiRoutes.DashboardRoutes.PortfolioBalance2)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<GroupedClientInvestmentViewModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FetClientPortfolioBalanceUnGrouped([FromRoute] int clientId)
    {
        var allInvestment = await _appService.PortfolioService.FetchClientInvestmentsWithBorrowingID(clientId);
        var groupedInvestment = allInvestment
                                    .Select(g => new GroupedClientInvestmentViewModel()
                                    {
                                        assetName = g.Asset,
                                        assetValue = g.AssetValue,
                                        currency = g.Currency,
                                        idPortfolio = g.ID_Portfolio,
                                        investmentModule = g.InvestmentModule
                                    }).ToList();

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<GroupedClientInvestmentViewModel>>
        {
            statusCode = StatusCodes.Status200OK,
            message = "",
            hasError = false,
            data = groupedInvestment
        });
    }

    [HttpGet(ApiRoutes.DashboardRoutes.WalletTransactions)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<TransactionViewModel>>), StatusCodes.Status200OK)]
    public ActionResult FetClientWalletTransactions([FromRoute] int clientId)
    {
        var allTransactions = _appService.PortfolioService.FetchClientCashTransactions(clientId).Take(50);

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<TransactionViewModel>>
        {
            statusCode = StatusCodes.Status200OK,
            message = "",
            hasError = false,
            data = allTransactions.ToList()
        });
    }
}
