namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioDrCrDetail
{
    public int IdPortfolioDrCrDetail { get; set; }
    public int? IdPortfolioDrCrMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? Amount { get; set; }
    public string? Narration { get; set; }
    public string? PostedBy { get; set; }
    public DateTime? GlPostDate { get; set; }
    public string? VoucherNo { get; set; }
    public bool? Reversed { get; set; }
    public int? ReversalId { get; set; }
    public int? IdPortfolioDrCrInvoice { get; set; }
    
}
