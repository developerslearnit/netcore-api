namespace IbsRestApi.Entities.iMoneytor;

public partial class LnSymbolReceiptDetail
{
    public int IdLnSymbolReceiptDetails { get; set; }
    public int? IdLnSymbolReceipt { get; set; }
    public int? LoanId { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? RepaymentRate { get; set; }
    public decimal? PrnAmount { get; set; }
    public decimal? IntAmount { get; set; }
    public decimal? QtyRedeemed { get; set; }
    public decimal? IntAdjustment { get; set; }
    public decimal? IntExpected { get; set; }
    public decimal? PrnExpected { get; set; }
    
    public decimal? ShortFallExcess { get; set; }
}
