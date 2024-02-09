using IbsRestApi.Api.Contracts;
using IbsRestApi.Api.Controllers;
using IbsRestApi.Application.AuthModels;
using IbsRestApi.Application.Contracts;
using IbsRestApi.Application.IbsMdm;
using IbsRestApi.Application.IMoneytor;
using IbsRestApi.Common;
using IbsRestApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IbsRestApi.Api.Areas.Investment.Controllers;

[ApiVersion("1.0")]
[Route("api/core/v{v:apiversion}/fixed-deposit")]
[ApiController]
public class FixedDepositSubscriptionController : BaseController
{
    private readonly IAppService _appService;

    public FixedDepositSubscriptionController(IAppService appService)
    {
        _appService = appService;
    }

    [HttpPost(ApiRoutes.FixedDepositRoutes.Subscribe)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<FixedDepositOutputParam>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Subscribe([FromBody] BorrowingSubscribeModel model)
    {

        var exMessage = string.Empty;

        try
        {

            if (model == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
            {
                statusCode = StatusCodes.Status400BadRequest,
                message = "API Request body cannot be null",
                hasError = true
            });

            if (model.client_unique_ref <= 0)
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Invalid client unique reference",
                    hasError = true
                });

            if (string.IsNullOrEmpty(model.currency) || model.currency.Length > 3)
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Invalid currency",
                    hasError = true
                });

            if (model.amount <= 0)
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Transaction amount can not be less than or equal to zero",
                    hasError = true
                });

            if (model.product_id <= 0)
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Invalid product selected",
                    hasError = true
                });
            if (model.showInterest == false)
            {
                if (string.IsNullOrEmpty(model.paymentChannel))
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<NullModel>
                    {
                        statusCode = StatusCodes.Status200OK,
                        message = "Invalid payment channel",
                        hasError = true
                    });
            }

            if (model.paymentChannel == "WALLET")
            {
                var clientCashBalance = await _appService.PortfolioService.FetchCustomerCashBalance(model.client_unique_ref, -1, model.currency, 0, DateTime.Now);

                if (clientCashBalance < float.Parse(model.amount.ToString())) return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "You do not have sufficient balance to carry out this transaction",
                    hasError = true
                });
            }

            var portfolio = _appService.PortfolioService.PortfolioById(model.product_id);

            if (!portfolio.Any()) return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
            {
                statusCode = StatusCodes.Status200OK,
                message = "There is no product with the selected id",
                hasError = true
            });


            var isFixedDeposit = model.productType.ToLower() == "FIXEDD".ToLower() ? true : false;

            if (!isFixedDeposit) return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
            {
                statusCode = StatusCodes.Status200OK,
                message = "There selected product is not a fixed deposit product",
                hasError = true
            });


            var person = await _appService.MdmService.FetchCustomerByUCID(model.client_unique_ref);

            if (person == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
            {
                statusCode = StatusCodes.Status200OK,
                message = "You are not a known customer.",
                hasError = true
            });


            var borrowType = _appService.PortfolioService.FetchBorrowTypeList().Where(
                c => c.IdPortfolio == model.product_id
                && c.IdBorrowType == model.borrowTypeId
                ).FirstOrDefault();

            if (borrowType == null)
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Invalid product selected",
                    hasError = true
                });


            var currency = _appService.PortfolioService.FetchPortfolioCurrency(model.product_id);

            if (!model.currency.ToLower().Equals(currency.ToLower()))
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
                {
                    statusCode = StatusCodes.Status200OK,
                    message = $"Invalid product currency. The selected portfolio currency can only be {currency}",
                    hasError = true
                });

            var borrowRateRaw = _appService.PortfolioService.FetchPublicFixedDepositRateGap()
                .Where(c => c.IdBorrowType.ToLower().Trim()
               == model.borrowTypeId.Trim().ToLower()
               && (c.FromTenor >= model.tenor && model.tenor <= c.ToTenor));


            if (!borrowRateRaw.Any())
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "No fixed deposit rate setup for the selected amount or tenor. Please contact the administrator",
                    hasError = true
                });

            var borrowRate = borrowRateRaw.FirstOrDefault();

            var onlinePortfolio = await _appService.SetupService.FetchPublicPortfolios();
            var onlinePortfolioId = onlinePortfolio.Where(x => x.portfolioId == model.product_id).FirstOrDefault();
            if (model.amount < onlinePortfolioId?.minSubAmount)

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
                {
                    statusCode = StatusCodes.Status200OK,
                    message = $"Minimum Investment Amount is {onlinePortfolioId?.minSubAmount.ToString("#,##.00")}",
                    hasError = true
                });

            var interestInfo = ComputeInterest(borrowType, model.amount, borrowRate, model.tenor, model.product_id);

            if (model.showInterest == true)
            {
                return StatusCode(StatusCodes.Status200OK, interestInfo);
            }

            GenericSPForCalculatingInterest geneicSpCalInt = new();
            FixedDepositInputParams InpuParamterfixedDepmodel = new();


            var portfolioCurrency = _appService.PortfolioService.FetchPortfolioCurrency(model.product_id);

            geneicSpCalInt.FaceAmount = model.amount;
            geneicSpCalInt.IntRate = borrowRate == null ? 0 : borrowRate.IntRate;
            geneicSpCalInt.IntMode = "L";
            geneicSpCalInt.IntType = borrowType.InterestPaidUpfront == null ? false : borrowType.InterestPaidUpfront;
            geneicSpCalInt.CapitalisedUpfrontInterest = borrowType.CapitaliseUpfrontInterest == null ? false : borrowType.CapitaliseUpfrontInterest;
            geneicSpCalInt.EffDate = DateTime.Now.Date;
            geneicSpCalInt.Tenor = model.tenor;
            geneicSpCalInt.ApplyWTax = borrowType.ApplyWithTax == null ? false : borrowType.ApplyWithTax;

            var intCalsp = _appService.PortfolioService.GetGeneric_sp_CalculateInterest(geneicSpCalInt, model.product_id);

            InpuParamterfixedDepmodel.effectIntRate = Convert.ToDecimal(intCalsp.EffIntRate.Replace('%', '0'));
            InpuParamterfixedDepmodel.FaceAmount = Convert.ToDecimal(intCalsp.BorrowAmount);
            InpuParamterfixedDepmodel.CapitalisedUpfrontInterest = borrowType.CapitaliseUpfrontInterest;
            InpuParamterfixedDepmodel.IntType = borrowType.InterestPaidUpfront;
            InpuParamterfixedDepmodel.ApplyWTax = borrowType.ApplyWithTax;
            InpuParamterfixedDepmodel.smaturityDate = intCalsp.MaturityDate;
            InpuParamterfixedDepmodel.currencyID = portfolioCurrency;
            InpuParamterfixedDepmodel.productID = model.product_id;
            InpuParamterfixedDepmodel.IntRate = borrowRate?.IntRate;
            InpuParamterfixedDepmodel.IntMode = "L";
            InpuParamterfixedDepmodel.Tenor = model.tenor;
            InpuParamterfixedDepmodel.BorrowAmt = Convert.ToDecimal(intCalsp.BorrowAmount);

            var portfolioContributorId = await _appService.PortfolioService.OpenCustomerAccount(ucid: model.client_unique_ref, currencyId: model.currency, portfolioId: -1, isMutualFund: false);

            if (portfolioContributorId > 0)
            {
                InpuParamterfixedDepmodel.portfolioContributorId = portfolioContributorId;
                if (model.paymentChannel == "CARD")
                {

                    var contributorAccount = await _appService.PortfolioService.InsertCustomerBorrowTransaction(-1, portfolioContributorId,
                    DateTime.Now, DateTime.Now.ToDateWithoutTime(), model.amount, "B", $"DEP IRO: {person.lastName} {person.firstName} [{model.product_id}]",
                    portfolioCurrency, $"Subcription via  API by {person.lastName} on {DateTime.Now} ================================", $"{person.lastName}", "API");
                }
            }


            //TODO: To be reviewed later
            WebHookModel webHookModel = new()
            {
                loggedDate = DateTime.Now,
                amount = model.amount,
                originAccount = model.client_unique_ref.ToString(),
                originAccountName = model.client_unique_ref.ToString(),
                originBank = model.currency,
                originNarration = "Fixed Deposit Subscription",
                rawPayload = JsonConvert.SerializeObject(model),
                referenceNo = model.paymentChannel,
                walletAccountNo = model.client_unique_ref.ToString(),
                transactionTimeStamp = DateTime.Now.ToString()
            };

            await _appService.MdmService.LogWebHookRequest(webHookModel);
            
            var fullname = $"{person.lastName} {person.firstName}";

            int saveTransaction = await _appService.PortfolioService.SaveFixedDepositInvestment(InpuParamterfixedDepmodel, fullname, person.ucid);

            if (saveTransaction > 0)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Subscription completed successfully ",
                    data = interestInfo.data,
                    hasError = false
                });
            }
        }
        catch (Exception ex)
        {
            exMessage = ex.Message;

        }

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<FixedDepositOutputParam>
        {
            statusCode = StatusCodes.Status200OK,
            message = !string.IsNullOrWhiteSpace(exMessage) ? $"Server Error {exMessage}" : "An unknown error has occured",
            hasError = true
        });


    }



    [HttpPost(ApiRoutes.FixedDepositRoutes.InitiateTermination)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<FixedDepositOutputParam>), StatusCodes.Status200OK)]
    public async Task<IActionResult> BorrowingTermination([FromBody] BorrowingTerminationModel model)
    {
        if (model == null)
            return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<BorrowWithdrawalResponseDetails>
            {
                message = "Bad request",
                hasError = true
            });

        if (model.DealId == 0 || string.IsNullOrWhiteSpace(model.WithdrawalType) || model.withdrawalAmount <= 0)
            return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<BorrowWithdrawalResponseDetails>
            {
                message = "All fields are required",
                hasError = true
            });

        var contributor = await _appService.PortfolioService.GetPortfolioContributor(model.ClientId, "NGN");

        if (contributor == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<BorrowWithdrawalResponseDetails>
        {
            message = "Invalid customer",
            hasError = true
        });

        var selectedDeal = _appService.PortfolioService.AllBorrowing().Where(x => x.dealId == model.DealId && x.clientId == contributor.IdPortfolioContributor).FirstOrDefault();

        if (selectedDeal == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<BorrowWithdrawalResponseDetails>
        {
            message = "Invalid deal selected",
            hasError = true
        });

        var calDetail = await _appService.PortfolioService.FetchFundingTermCalculations(model.DealId, model.WithdrawalType, model.withdrawalAmount);

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<BorrowWithdrawalResponseDetails>
        {
            hasError = false,
            statusCode = 200,
            data = new BorrowWithdrawalResponseDetails()
            {
                DealId = model.DealId,
                InterestBalance = calDetail.InterestBalance,
                PenaltyAmount = calDetail.PenaltyAmount,
                TotalAmount = calDetail.TotalAmount,
                WithDrawAmount = calDetail.WithDrawAmount,
                PrincipalBalance = calDetail.PrincipalBalance,
                SubTotal = calDetail.SubTotal
            }
        });
    }

    [HttpPost(ApiRoutes.FixedDepositRoutes.Terminate)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<FixedDepositOutputParam>), StatusCodes.Status200OK)]
    public async Task<IActionResult> BorrowingTerminate([FromBody] BorrowingTerminationModel model)
    {
        if (model == null)
            return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<BorrowWithdrawalResponseDetails>
            {
                message = "Bad request",
                hasError = true
            });

        if (model.DealId == 0 || string.IsNullOrWhiteSpace(model.WithdrawalType) || model.withdrawalAmount <= 0)
            return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<BorrowWithdrawalResponseDetails>
            {
                message = "All fields are required",
                hasError = true

            });

        var contributor = await _appService.PortfolioService.GetPortfolioContributor(model.ClientId, "NGN");

        if (contributor == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<BorrowWithdrawalResponseDetails>
        {
            message = "Invalid customer",
            hasError = true
        });

        var selectedDeal = _appService.PortfolioService.AllBorrowing().Where(x => x.dealId == model.DealId && x.clientId == contributor.IdPortfolioContributor).FirstOrDefault();

        if (selectedDeal == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<BorrowWithdrawalResponseDetails>
        {
            message = "Invalid deal selected",
            hasError = true
        });

        var calDetail = await _appService.PortfolioService.FetchFundingTermCalculations(model.DealId, model.WithdrawalType, model.withdrawalAmount);

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<BorrowWithdrawalResponseDetails>
        {
            hasError = false,
            statusCode = 200,
            data = new BorrowWithdrawalResponseDetails()
            {
                DealId = model.DealId,
                InterestBalance = calDetail.InterestBalance,
                PenaltyAmount = calDetail.PenaltyAmount,
                TotalAmount = calDetail.TotalAmount,
                WithDrawAmount = calDetail.WithDrawAmount,
                PrincipalBalance = calDetail.PrincipalBalance,
                SubTotal = calDetail.SubTotal
            }
        });
    }

    [HttpPost(ApiRoutes.FixedDepositRoutes.CustomerActiveDeals)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<CustomerActiveDealsModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FetchClientActiveTransactions([FromRoute] int ucid, [FromRoute] int portfolioId)
    {
        if (ucid == 0 || portfolioId == 0) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<IEnumerable<CustomerActiveDealsModel>>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });

        var portfolio = _appService.PortfolioService.PortfolioById(portfolioId).FirstOrDefault();

        if (portfolio == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IEnumerable<CustomerActiveDealsModel>>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "There is no product with the selected id",
            hasError = true
        });

        var products = await _appService.PortfolioService.FetchPublicPortfolios();

        var selectedProduct = products.Where(x => x.portfolioId == portfolioId).FirstOrDefault();
        if (selectedProduct == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IEnumerable<CustomerActiveDealsModel>>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "There is no product with the selected id",
            hasError = true
        });

        var isFixedDeposit = selectedProduct.ProductType.ToLower() == "FIXEDD".ToLower() ? true : false;

        if (!isFixedDeposit) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IEnumerable<CustomerActiveDealsModel>>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "There selected product is not a fixed deposit product",
            hasError = true
        });

        var person = await _appService.MdmService.FetchCustomerByUCID(ucid);

        if (person.ucid == 0) return StatusCode(StatusCodes.Status200OK, new ApiResponse<IEnumerable<CustomerActiveDealsModel>>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "You are not a known customer.",
            hasError = true
        });
        var portfoliocontributor = await _appService.PortfolioService.OpenCustomerAccount(ucid: ucid, currencyId: portfolio.IdCurrency, portfolioId: portfolioId, isMutualFund: false);
        var deals = _appService.PortfolioService.GetCustomersActiveFixedDepositDeals(portfoliocontributor).ToList();

        var fullDeals = deals.Select(x => new CustomerActiveDealsModel()
        {
            DealId = x.DealId,
            PortfoioId = portfolioId,
            PortfolioName = string.IsNullOrWhiteSpace(portfolio.Portfolio1) ? "" : portfolio.Portfolio1,
            MaturityDate = x.MaturityDate,
            Tenor = x.Tenor,
            Amount = x.Amount,
        });

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<IEnumerable<CustomerActiveDealsModel>>
        {
            hasError = false,
            statusCode = 200,
            data = fullDeals
        });

    }

    [HttpPost(ApiRoutes.FixedDepositRoutes.InitializeDealTerminate)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<BorrowTerminateDetailModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> InitiateFixedDepositTermination([FromBody] BorrowTerminateInitialModel model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<BorrowTerminateDetailModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });

        var person = await _appService.MdmService.FetchCustomerByUCID(model.client_unique_ref);

        if (person.ucid == 0) return StatusCode(StatusCodes.Status200OK, new ApiResponse<BorrowTerminateDetailModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "You are not a known customer.",
            hasError = true
        });

        var terminateResponse = await _appService.PortfolioService.InitializeBorrowTerminate(model.DealId, DateTime.Now);
        if (terminateResponse.ErrorMessage != "Ok") return StatusCode(StatusCodes.Status200OK, new ApiResponse<BorrowTerminateDetailModel>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = terminateResponse.ErrorMessage,
            hasError = true
        });

        var terminationDetail = _appService.PortfolioService.GetCustomerBorrowTerminateDetail(terminateResponse.DealId).FirstOrDefault();
        return StatusCode(StatusCodes.Status200OK, new ApiResponse<BorrowTerminateDetailModel>
        {
            hasError = false,
            statusCode = 200,
            data = terminationDetail
        });
    }

    [HttpPost(ApiRoutes.FixedDepositRoutes.ConfirmDealTerminate)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ConfirmFixedDepositTermination([FromBody] BorrowTerminateConfirmModel model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "Bad Request",
            hasError = true
        });

        var person = await _appService.MdmService.FetchCustomerByUCID(model.client_unique_ref);
        if (person.ucid == 0) return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "You are not a known customer.",
            hasError = true
        });

        await _appService.PortfolioService.ApproveTermination(model.terminateId);
        return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
        {
            hasError = false,
            statusCode = 200,
            message = "Termination request has been approved"
        });
    }
    #region Helpers
    ApiResponse<FixedDepositOutputParam> ComputeInterest(BorrowTypeModel borrowType, decimal amount, BorrowRateModel borrowRate, int tenor, int productId)
    {
        var inputParams = new GenericSPForCalculatingInterest()
        {
            FaceAmount = amount,
            IntRate = borrowRate == null ? 0 : borrowRate.IntRate,
            IntMode = "L",
            IntType = borrowType.InterestPaidUpfront,
            CapitalisedUpfrontInterest = borrowType.CapitaliseUpfrontInterest,
            EffDate = DateTime.Now.ToDateWithoutTime(),
            Tenor = tenor,
            ApplyWTax = borrowType.ApplyWithTax
        };

        var data = _appService.PortfolioService.GetGeneric_sp_CalculateInterest(inputParams, productId);
        string currency = _appService.PortfolioService.FetchPortfolioCurrency(productId);
        data.StrSettlememtDate = data.SettlememtDate.Value.ToString("dd-MM-yyyy");
        data.EffectiveDate = DateTime.Now.Date.ToString("dd-MM-yyyy");
        data.Tenor = tenor;
        data.CurrencyId = currency;

        return new ApiResponse<FixedDepositOutputParam>
        {
            statusCode = StatusCodes.Status200OK,
            hasError = false,
            data = data
        };

    }
    #endregion
}
