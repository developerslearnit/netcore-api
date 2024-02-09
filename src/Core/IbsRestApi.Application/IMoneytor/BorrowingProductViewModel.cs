namespace IbsRestApi.Application.IMoneytor;

public class BorrowingProductViewModel
{
    public int dealId { get; set; }
    public int clientId { get; set; }
    public string productName { get; set; }
    public string currency { get; set; }
    public string description { get; set; }
    public decimal curExchangeRate { get; set; }
    public decimal faceAmount { get; set; }
    public decimal borrowAmount { get; set; }
    public DateTime transactionDate { get; set; }
    public DateTime effectiveDate { get; set; }
    public decimal interestRate { get; set; }
    public int numofDays { get; set; }
    public decimal rentalAmount { get; set; }
    public DateTime firstPaymentDate { get; set; }
    public DateTime maturityDate { get; set; }
    public int productId { get; set; }
    public string FormattedEffectiveDate { get { return this.effectiveDate.ToString("dd/MM/yyyy"); } }
}
