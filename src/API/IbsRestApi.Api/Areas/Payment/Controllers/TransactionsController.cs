using IbsRestApi.Api.Areas.Payment.Models;
using IbsRestApi.Api.Contracts;
using IbsRestApi.Api.Controllers;
using IbsRestApi.Api.PaymentService;
using IbsRestApi.Application.Contracts;
using IbsRestApi.Application.IMoneytor;
using IbsRestApi.Common;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Entities.iMoneytor;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IbsRestApi.Api.Areas.Payment.Controllers;

[ApiVersion("1.0")]
[Route("api/core/v{v:apiversion}")]
[ApiController]
public class TransactionsController : BaseController
{

    private readonly IAppService _appService;

    public TransactionsController(IAppService appService)
    {
        _appService = appService;
    }

    [HttpPost(ApiRoutes.TransactionsRoutes.InitTransaction)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<TransactionInitResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> InitializeTransaction([FromBody] TransactionModel model)
    {

        if (model == null) return BadRequest("Model is null");

        if (model.ucid <= 0) return BadRequest("ucid is not valid");

        if (model.amount <= 0) return BadRequest("Amount is not valid");

        if (model.currencyId == null) return BadRequest("Currency is not valid");

        if (model.portfolioId <= 0) return BadRequest("Portfolio is not valid");

        var transRef = CommonHelper.GenerateRandomString(20, true);


        var orderModel = new ExistingClientOrderModel()
        {
            amount = model.amount,
            currencyId = model.currencyId,
            portfolioId = model.portfolioId,
            ucid = model.ucid,
            tranxRef = transRef
        };

        var response = await _appService.PortfolioService.AddExistingClientOrder(orderModel);

        if (response)
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionInitResponseModel>
            {
                data = new TransactionInitResponseModel
                {
                    tranxRef = transRef,
                    amount = model.amount,
                    portfolioId = model.portfolioId
                },
                hasError = false,
                message = "Success",
                statusCode = StatusCodes.Status200OK

            });
        }
        else
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<TransactionInitResponseModel>
            {
                data = null,
                hasError = true,
                message = "Failed",
                statusCode = StatusCodes.Status500InternalServerError

            });
        }

    }

    [HttpGet(ApiRoutes.TransactionsRoutes.VerifyTransaction)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<TransactionVerifyResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> VerifyTransaction([FromQuery] string tranxRef)
    {
        var paystackKey = _appService.SettingsService.GetSetting("PAYSTACK_KEY");
        var paystackAPI = new PaystackPayment(paystackKey);

        var response = await paystackAPI.VerifyTransaction(tranxRef);

        if (response.status && response.data.status == "success")
        {
            var amountPaid = (decimal)(response.data.amount / 100); //Always divide returned amount by 100 to get 
            var transactionRef = response.data.reference;

            var order = _appService.PortfolioService.GetExistingClientOrder(transactionRef);

            if (order == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
            {
                data = null,
                hasError = true,
                message = "No associated order found",
                statusCode = StatusCodes.Status200OK

            });

            if (amountPaid <= 0) return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
            {
                data = null,
                hasError = true,
                message = "Transaction failed",
                statusCode = StatusCodes.Status200OK

            });

            var amountLessCharge = amountPaid > order.Amount ? (amountPaid-order.Amount) + order.Amount : amountPaid;


            if (transactionRef.Equals(tranxRef))
            {
                if (amountLessCharge == order.Amount)
                {
                    if (order != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
                        {
                            data = new TransactionVerifyResponseModel
                            {
                                amount = order.Amount,
                                portfolioId = order.IdPortfolio,
                                tranxRef = order.TransactionReference,
                                status = true
                            },
                            hasError = false,
                            message = "Transaction was successful",
                            statusCode = StatusCodes.Status200OK

                        });
                    }
                   
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
                    {
                        data = new TransactionVerifyResponseModel
                        {
                            status = response.data.status == "success" ? true : false,
                            tranxRef = response.data.reference,
                            amount = amountLessCharge
                        },
                        hasError = true,
                        message = "Amount not equal",
                        statusCode = StatusCodes.Status200OK

                    });
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
                {
                    data = new TransactionVerifyResponseModel
                    {
                        status = response.data.status == "success" ? true : false,
                        tranxRef = response.data.reference,
                        amount = amountLessCharge
                    },
                    hasError = true,
                    message = "Transaction ref not match",
                    statusCode = StatusCodes.Status200OK

                });
            }
        }

        //if (response.data != null)
        //{
        //    return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
        //    {
        //        data = new TransactionVerifyResponseModel
        //        {
        //            status = response.data.status == "success" ? true : false,
        //            tranxRef = response.data.reference,
        //        },
        //        hasError = true,
        //        message = JsonConvert.SerializeObject(response.data),
        //        statusCode = StatusCodes.Status200OK

        //    });
        //}
        return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
        {
            data = new TransactionVerifyResponseModel
            {
                status = false,
                tranxRef = tranxRef
            },
            hasError = true,
            message = "Transaction failed",
            statusCode = StatusCodes.Status200OK

        });
    }



    [HttpPost(ApiRoutes.TransactionsRoutes.InitWalletTransaction)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<TransactionInitResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> InitializeWalletTransaction([FromBody] WalletTransactionInitModel model)
    {

        if (model == null) return BadRequest("Model is null");

        if (model.ucid <= 0) return BadRequest("ucid is not valid");

        if (model.amount <= 0) return BadRequest("Amount is not valid");




        var orderModel = new WalletTransactionModel()
        {
            amount = model.amount,
            ucid = model.ucid,
            tranxRef = model.transRef,
            currencyId = "NGN"
        };

        var response = await _appService.PortfolioService.AddExistingClientWalletOrder(orderModel);

        if (response)
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionInitResponseModel>
            {
                data = new TransactionInitResponseModel
                {
                    tranxRef = model.transRef,
                    amount = model.amount
                },
                hasError = false,
                message = "Success",
                statusCode = StatusCodes.Status200OK

            });
        }
        else
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<TransactionInitResponseModel>
            {
                data = null,
                hasError = true,
                message = "Failed",
                statusCode = StatusCodes.Status500InternalServerError

            });
        }

    }

    [HttpGet(ApiRoutes.TransactionsRoutes.VerifyWalletTransaction)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<TransactionVerifyResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> VerifyWalletTransaction([FromRoute] string tranxRef)
    {
        var paystackKey = _appService.SettingsService.GetSetting("PAYSTACK_KEY");
        var paystackAPI = new PaystackPayment(paystackKey);

        var response = await paystackAPI.VerifyTransaction(tranxRef);

        if (!response.status)
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
            {
                data = new TransactionVerifyResponseModel
                {
                    status = false,
                    tranxRef = tranxRef
                },
                hasError = true,
                message = $"Unable to complete payment.->{response.message}",
                statusCode = StatusCodes.Status200OK

            });

        if (!response.data.status.ToLower().Equals("success"))
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
            {
                data = new TransactionVerifyResponseModel
                {
                    status = false,
                    tranxRef = tranxRef
                },
                hasError = true,
                message = $"Unable to complete payment.->{response.message}",
                statusCode = StatusCodes.Status200OK

            });

        //Transaction successful is we get here

        var amountPaid = (decimal)(response.data.amount / 100); //Always divide returned amount by 100 to get 
        var transactionRef = response.data.reference;

        var order = _appService.PortfolioService.GetExistingClientWalletOrder(transactionRef);

        if (order == null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
        {
            data = null,
            hasError = true,
            message = "No associated order found",
            statusCode = StatusCodes.Status200OK

        });
        if (!transactionRef.Equals(tranxRef)) return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
        {
            data = null,
            hasError = true,
            message = "Invalid transaction reference",
            statusCode = StatusCodes.Status200OK

        });

        if (amountPaid == 0 || amountPaid < order.Amount) return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
        {
            data = null,
            hasError = true,
            message = "Invalid transaction :: Amount paid is less than expected amount",
            statusCode = StatusCodes.Status200OK

        });


        try
        {
            var currencyMapping = _appService.MdmService.FetchBankByCurrency(order.IdCurrency);

            _appService.CashManagementService.WalletDepositOrWithdraw(order.Ucid, order.IdCurrency, order.Amount, currencyMapping.IdBankAccount,
                currencyMapping.IdCashMgtAccountLogement, tranxRef, "D");
            var transReponse = await _appService.PortfolioService.UpdateExistingClientWalletOrder(tranxRef);

            if (transReponse)
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
                {
                    data = new TransactionVerifyResponseModel
                    {
                        amount = order.Amount,
                        tranxRef = order.TransactionReference,
                        status = true
                    },
                    hasError = false,
                    message = $"Payment of {order.Amount.ToString("#,##.00")} was successful!",
                    statusCode = StatusCodes.Status200OK

                });

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
            {
                data = new TransactionVerifyResponseModel
                {
                    status = false,
                    tranxRef = tranxRef
                },
                hasError = true,
                message = $"Payment Transaction was successful however, we could not update your account, please contact administrator",
                statusCode = StatusCodes.Status200OK

            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<TransactionVerifyResponseModel>
            {
                hasError = true,
                message = $"Transaction failed ::{ex.Message}",
                statusCode = StatusCodes.Status200OK

            });
        }
    }

    [HttpGet(ApiRoutes.TransactionsRoutes.GetPaymentPublicKey)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
    public IActionResult GetPaymentPublicKey()
    {

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
        {
            data = _appService.SettingsService.GetSetting("PAYSTACK_PUBLIC_KEY"),
            hasError = false,
            message = "success",
            statusCode = StatusCodes.Status200OK
        });
    }



}




