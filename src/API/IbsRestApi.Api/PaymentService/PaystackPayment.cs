using Paystack.Net.SDK.Models;
using System.Text.Json;

namespace IbsRestApi.Api.PaymentService;

public class PaystackConstant
{
    public const string BASE_URL = "https://api.paystack.co/";

    public const string AUTHORIZATION_TYPE = "Bearer";

    public const string REQUEST_MEDIA_TYPE = "application/json";

}

public class PaystackPayment
{
    private readonly string _secretKey;
    public PaystackPayment(string secretKey)
    {
        this._secretKey = secretKey;
    }

    /// <summary>
    /// Verifies transaction by reference number
    /// </summary>
    /// <param name="reference"></param>
    /// <returns>TransactionVerificationResponseModel</returns>

    public async Task<TransactionResponseModel> VerifyTransaction(string reference)
    {
        var client = HttpFactory.InitHttpClient(PaystackConstant.BASE_URL)
                  .AddAuthorizationHeader(PaystackConstant.AUTHORIZATION_TYPE, _secretKey)
                  .AddMediaType(PaystackConstant.REQUEST_MEDIA_TYPE)
                  .AddHeader("cache-control", "no-cache");

        var response = await client.GetAsync($"transaction/verify/{reference}");

        var json = await response.Content.ReadAsStringAsync();


        return JsonSerializer.Deserialize<TransactionResponseModel>(json);
    }

   


}
