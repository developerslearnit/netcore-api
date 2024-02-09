namespace IbsRestApi.Api.Areas.Payment.Models;

public class TransactionInitResponseModel
{
    public int portfolioId { get; set; }
    public decimal amount { get; set; }
    public string tranxRef { get; set; }
    public DateTime? transactionDate { get; set; }
}
