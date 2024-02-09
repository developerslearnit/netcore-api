namespace IbsRestApi.Entities.iMoneytor;

public partial class ExistingClientOrder
{
    public int InvestOrderId { get; set; }
    public int Ucid { get; set; }
    public string IdCurrency { get; set; } = null!;
    public int IdPortfolio { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public string TransactionReference { get; set; } = null!;
    public bool TransactionStatus { get; set; }
    public int? Tenor { get; set; }
}
