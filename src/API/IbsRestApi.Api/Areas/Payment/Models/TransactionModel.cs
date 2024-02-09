namespace IbsRestApi.Api.Areas.Payment.Models;

public class TransactionModel
{
    public int ucid { get; set; }
    public string currencyId { get; set; }
    public int portfolioId { get; set; }
    public decimal amount { get; set; }
}


public class WalletTransactionInitModel
{
    public int ucid { get; set; }
    public decimal amount { get; set; }
    public string transRef { get; set; }
}



