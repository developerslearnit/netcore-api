using IbsRestApi.Api.Contracts;
using IbsRestApi.Api.Controllers;
using IbsRestApi.Application.AuthModels;
using IbsRestApi.Application.Contracts;
using IbsRestApi.Application.IbsMdm;
using IbsRestApi.Application.IMoneytor;
using IbsRestApi.Common;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace IbsRestApi.Api.Areas.Investment.Controllers;

[ApiVersion("1.0")]
[Route("api/core/v{v:apiversion}/mutual-fund")]
[ApiController]
public class MutualFundSubscriptionController : BaseController
{
    private readonly IAppService _appService;
    private readonly IConfiguration _config;

    public MutualFundSubscriptionController(IAppService appService, IConfiguration config)
    {
        _appService = appService;
        _config = config;
    }

    [HttpPost(ApiRoutes.MutualFundRoutes.Subscribe)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<FundSubResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Subscribe([FromBody] SubscribeModel model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });

        if (model.client_unique_ref <= 0)
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Invalid client unique reference",
                hasError = true
            });

        if (string.IsNullOrEmpty(model.currency) || model.currency.Length > 3)
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Invalid currency",
                hasError = true
            });

        if (model.amount <= 0)
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Transaction amount can not be less than or equal to zero",
                hasError = true
            });

        if (model.product_id <= 0)
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Invalid product selected",
                hasError = true
            });

        if (string.IsNullOrEmpty(model.paymentChannel))
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Invalid payment channel",
                hasError = true
            });

        if (model.paymentChannel == "WALLET")
        {
            var clientCashBalance = await _appService.PortfolioService.FetchCustomerCashBalance(model.client_unique_ref, -1, model.currency, 0, DateTime.Now);

            if (clientCashBalance < float.Parse(model.amount.ToString())) return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = $"You do not have sufficient balance to carry out this transaction. Your cash balance is {clientCashBalance.ToString("#,##.00")}",
                hasError = true
            });
        }

        var portfolio = _appService.PortfolioService.PortfolioById(model.product_id);

        if (!portfolio.Any()) return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "There is no product with the selected id",
            hasError = true
        });


        var products = await _appService.SetupService.FetchPublicPortfolios();

        var selectedProduct = products.Where(x => x.portfolioId == model.product_id).FirstOrDefault();
        if (selectedProduct == null)
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "There is no product with the selected id",
                hasError = true
            });

        if(string.IsNullOrWhiteSpace(selectedProduct.ProductType))
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Product type not set for the selected product",
                hasError = true
            });

        //DateTime.Now.ToDateWithoutTime()

        var isUnitBased = selectedProduct.ProductType.ToLower() == "MFUNDS".ToLower() ? true : false; //portfolio.FirstOrDefault().UnitBased.HasValue ? portfolio.FirstOrDefault().UnitBased.Value : false;

        if (!isUnitBased) return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "There selected product is not a mutual fund product",
            hasError = true
        });

        var currency = _appService.PortfolioService.FetchPortfolioCurrency(model.product_id);

        if (!model.currency.ToLower().Equals(currency.ToLower()))
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = $"Invalid product currency. The selected portfolio currency can only be {currency}",
                hasError = true
            });

        var IdPortfolioGroup = portfolio.FirstOrDefault().IdPortfolioGroup.HasValue ? portfolio.FirstOrDefault().IdPortfolioGroup.Value : 0;

        var portGroup = await _appService.PortfolioService.FetchPortfolioGroup(IdPortfolioGroup);

        if (portGroup == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Portfolio group not set up",
            hasError = true
        });

        if (string.IsNullOrWhiteSpace(portGroup.IdBankAccount01)) return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Portfolio lodgement account not set up",
            hasError = true
        });


        var person = await _appService.MdmService.FetchCustomerByUCID(model.client_unique_ref);

        if (person == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "You are not a known customer.",
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
            originNarration = "Mutual Fund Subscribe",
            rawPayload = JsonConvert.SerializeObject(model),
            referenceNo = model.paymentChannel,
            walletAccountNo = model.client_unique_ref.ToString(),
            transactionTimeStamp = DateTime.Now.ToString()
        };

        await _appService.MdmService.LogWebHookRequest(webHookModel);
        var portfolioContributorId = await _appService.PortfolioService.OpenCustomerAccount(ucid: model.client_unique_ref, currencyId: model.currency, portfolioId: model.product_id);

        var transactionDate = DateTime.Now.ToDateWithoutTime();

        if (portfolioContributorId > 0)
        {
            var IdPortfolioContributorAccount = await _appService.PortfolioService.AddCustomerTransaction(model.product_id, portfolioContributorId,
           transactionDate, transactionDate, model.amount, "S", $"DEP IRO: {person.lastName} {person.Othername} [{model.product_id}]", model.currency, $"Subcription via  App by {person.lastName} on {DateTime.Now} ================================", $"{person.firstName}", true, "API");

            if (model.paymentChannel == "WALLET")
            {
                var addDebitLeg = _appService.PortfolioService.AddCustomerDebitTransaction(model.client_unique_ref, DateTime.Now, transactionDate, model.amount, "S", "Mutual Fund Subscription", "NGN", "Mutual Fund subscription", person.lastName);
            }

            var offerPrice = Convert.ToDecimal(_appService.PortfolioService.GetOfferPriceAsAt(model.product_id, DateTime.Now.Date.AddDays(-1), 0));
            if (offerPrice != 0)
            {
                var approvalResponse =
                    await _appService.PortfolioService.MutualFundBuySellApproval(model.product_id, "S", person.firstName, IdPortfolioContributorAccount, portGroup.IdBankAccount01, DateTime.Now);

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
                {
                    statusCode = StatusCodes.Status200OK,
                    data = new FundSubResponseModel
                    {
                        TransactionDate = transactionDate,
                        ProductName = selectedProduct.portfolioName,
                        Amount = model.amount.ToString("#,##.00")
                    },
                    message = "Your fund subscription was completed successfully",
                    hasError = false
                });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<FundSubResponseModel>
            {
                statusCode = StatusCodes.Status200OK,
                data = new FundSubResponseModel
                {
                    TransactionDate = transactionDate,
                    ProductName = selectedProduct.portfolioName,
                    Amount = model.amount.ToString("#,##.00")
                },
                message = "Your fund subscription request was received and will be treated in a short while.",
                hasError = false
            });

        }
        else
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<FundSubResponseModel>
            {
                statusCode = StatusCodes.Status500InternalServerError,
                message = "Internal Server Error",
                hasError = true
            });
        }

    }

    [HttpPost(ApiRoutes.MutualFundRoutes.Balance)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ClientMutualFundbalance([FromBody] SubscriptionEnqModel model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });

        var currCustomer = _appService.PortfolioService.FetchClientTransactionsByUCIDAndFundId(model.client_unique_ref, model.product_id).FirstOrDefault();

        if (currCustomer == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status200OK,
            message = "",
            hasError = false,
            data = "0.0"
        });

        var balance = await _appService.PortfolioService.GetPortfolioBalance(model.product_id, currCustomer.id_portcontributor);

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status200OK,
            message = "",
            hasError = false,
            data = balance.ToString("#,##.00")
        });
    }

    [HttpPost(ApiRoutes.MutualFundRoutes.RedemptionDetails)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<RedemptionResultModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FetchRedemptionDetails([FromBody] SubscriptionEnqModel model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest);

        if (model.amount < 0 || model.amount == 0)
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<RedemptionResultModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Amount to redeem cannot be less than or equal to zero",
                hasError = true
            });
        }

        if (model.amount > model.balance)
        {

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<RedemptionResultModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Amount to redeem cannot be greater than available balance",
                hasError = true
            });
        }

        var amountToRedeem = model.amount;

        var currCustomer = _appService.PortfolioService.FetchClientTransactionsByUCIDAndFundId(model.client_unique_ref, model.product_id).FirstOrDefault();

        if (currCustomer == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<RedemptionResultModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Invalid customer",
            hasError = true
        });

        var valuationDate = await _appService.PortfolioService.GetLastValuationDate(model.product_id);
        var salesDate = DateTime.Now;


        var bidPrice = await _appService.PortfolioService.GetBidPriceAsAt(model.product_id, valuationDate, 0);

        var totalAmount = amountToRedeem / Convert.ToDecimal(bidPrice);

        _appService.PortfolioService.DeleteTempRedemptionRequest(model.product_id, currCustomer.id_portcontributor);

        var redemptionList = await _appService.PortfolioService.AutoRedemption(currCustomer.id_portcontributor, model.product_id,
            salesDate.Date, totalAmount, true, false);

        if (redemptionList.Any())
        {
            _appService.PortfolioService.InsertTempRedemptionRequest(redemptionList);
        }

        var netSettlementAmount = redemptionList.Sum(x => x.NetSettlement);
        var totalNoOfUnits = redemptionList.Sum(x => x.NoOfUnits);

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<RedemptionResultModel>
        {
            statusCode = StatusCodes.Status200OK,
            hasError = false,
            data = new RedemptionResultModel
            {
                certList = redemptionList,
                noOfUnit = totalNoOfUnits.ToString("#,##.00"),
                netSettlement = netSettlementAmount.ToString("#,##.00")
            }
        });
    }

    [HttpGet(ApiRoutes.MutualFundRoutes.ListOfRedemptions)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<RedemptionHistoryViewModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FetchRedemptionList([FromRoute] int ucid)
    {
        if (ucid <= 0) return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<RedemptionHistoryViewModel>>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Invalid Client",
            hasError = true
        });

        var currCustomer = _appService.MdmService.FetchCustomerByUCID(ucid);

        if (currCustomer == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<RedemptionHistoryViewModel>>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Invalid customer",
            hasError = true
        });

        var clientPortfolioContributorIds = await _appService.PortfolioService.ListClientPortfolioContributorIds(ucid);

        var transactionList = await _appService.PortfolioService.ListRedemptionHistories()
                .Where(x => clientPortfolioContributorIds.Contains(x.portcontributorId))
                .OrderByDescending(x => x.transactionId).ToListAsync();

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<RedemptionHistoryViewModel>>
        {
            statusCode = StatusCodes.Status200OK,
            hasError = false,
            data = transactionList
        });
    }

    [HttpPost(ApiRoutes.MutualFundRoutes.RedemptionConfirmation)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<RedemptionResultModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ProcessRedemption([FromBody] SubscriptionEnqModel model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });

        var currCustomer = _appService.PortfolioService.FetchClientTransactionsByUCIDAndFundId(model.client_unique_ref, model.product_id).FirstOrDefault();

        if (currCustomer == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Invalid customer",
            hasError = true
        });

        var customerOldTransactions = _appService.PortfolioService.FetchClientTransactions(model.client_unique_ref, model.product_id);

        if (customerOldTransactions.Any(x => x.transactionType == "R" && (x.status == "P" || x.status == "T" || x.status == "B" || x.status == "V")))
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
            {
                statusCode = StatusCodes.Status200OK,
                message = "Please note that you have a pending redemption request. Please try again later",
                hasError = true
            });
        }

        var response = await _appService.PortfolioService.AddRedemptionRequest(model.product_id, currCustomer.id_portcontributor);
        var smtpSettings = _appService.SettingsService.GetSMTPSettings();

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Your redemption request was successful",
            hasError = false
        });
    }
}
