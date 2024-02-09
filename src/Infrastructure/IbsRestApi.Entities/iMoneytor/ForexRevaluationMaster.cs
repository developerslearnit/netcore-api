namespace IbsRestApi.Entities.iMoneytor;

public partial class ForexRevaluationMaster
{
    public int IdForexRevaluationMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public string? Narration { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? Amount { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? PostedBy { get; set; }
    public bool? Reversed { get; set; }
    public int? ReversalId { get; set; }
    public string? Comments { get; set; }
    
}
