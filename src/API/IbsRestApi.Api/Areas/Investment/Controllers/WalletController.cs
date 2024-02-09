using IbsRestApi.Api.Contracts;
using IbsRestApi.Api.Controllers;
using IbsRestApi.Api.Filters;
using IbsRestApi.Application.AuthModels;
using IbsRestApi.Application.Contracts;
using IbsRestApi.Application.IbsMdm;
using IbsRestApi.Application.IMoneytor;
using IbsRestApi.Common;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IbsRestApi.Api.Areas.Investment.Controllers;

[ApiVersion("1.0")]
[Route("api/core/v{v:apiversion}/wallet")]
[ApiController]
public class WalletController : BaseController
{
    private readonly IAppService _appService;

    public WalletController(IAppService appService)
    {
        _appService = appService;
    }

    [HttpPost(ApiRoutes.WalletRoutes.FundWallet)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<NullModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FundWallet([FromBody] FundWalletModel model)
    {

        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });

        if (model.amount < 0)
            return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status400BadRequest,
                message = "Deposit amount can not be less than or equal to zero",
                hasError = true
            });

        if (model.client_unique_ref <= 0)
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Invalid client unique reference",
                hasError = true
            });

        if (string.IsNullOrEmpty(model.currency) || model.currency.Length > 3)
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Invalid currency",
                hasError = true
            });
        if (string.IsNullOrEmpty(model.transRef))
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Invalid Transaction Reference",
                hasError = true
            });
        var exist = await _appService.CashManagementService.GetPreviousTransactionReference(model.transRef);
        if (exist)
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Duplicate Transaction Reference",
                hasError = true
            });

        if (model.amount <= 0)
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Deposit amount can not be less than or equal to zero",
                hasError = true
            });

        var user = await _appService.MdmService.FetchCustomerByUCID(model.client_unique_ref);
        if (user.ucid == 0)
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "User not found",
                hasError = true
            });
        //TODO: To be reviewed later
        WebHookModel webHookModel = new()
        {
            loggedDate = DateTime.Now,
            amount = model.amount,
            originAccount = model.client_unique_ref.ToString(),
            originAccountName = model.client_unique_ref.ToString(),
            originBank = model.currency,
            originNarration = "FundWallet",
            rawPayload = JsonConvert.SerializeObject(model),
            referenceNo = model.transRef,
            walletAccountNo = model.client_unique_ref.ToString(),
            transactionTimeStamp = DateTime.Now.ToString()
        };

        await _appService.MdmService.LogWebHookRequest(webHookModel);
        var currencyMapping = _appService.MdmService.FetchBankByCurrency(model.currency);

        _appService.CashManagementService.WalletDepositOrWithdraw(model.client_unique_ref, model.currency, model.amount, currencyMapping.IdBankAccount,
            currencyMapping.IdCashMgtAccountLogement, model.transRef, "D");

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Transaction was successful",
            hasError = false
        });

    }

    [HttpGet(ApiRoutes.WalletRoutes.WalletBalance)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<FundWalletResultModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> WalletBalance([FromRoute] int clientId, string currency)
    {
        if (clientId <= 0) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<FundWalletResultModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });
        if (string.IsNullOrWhiteSpace(currency)) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<FundWalletResultModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Invalid Currency",
            hasError = true
        });

        var clientCashBalance = await _appService.PortfolioService.FetchCustomerCashBalance(clientId, -1, currency, 0, DateTime.Now.ToDateWithoutTime());

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundWalletResultModel>
        {
            statusCode = StatusCodes.Status200OK,
            hasError = false,
            data = new FundWalletResultModel
            {
                currency = currency,
                balance = clientCashBalance,
                formate_balance = clientCashBalance > 0 ? clientCashBalance.ToString("#,##.00") : "0.0"
            }
        });

    }
}
