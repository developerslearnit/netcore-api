namespace IbsRestApi.Entities.iMoneytor;

public partial class DealPostDateCheque
{
    public int IdDealPostDateCheque { get; set; }
    public int? IdDealMaster { get; set; }
    public string? ChequeNo { get; set; }
    public string? SourceIdBank { get; set; }
    public string? SourceLocation { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? PresentDate { get; set; }
    public decimal? Amount { get; set; }
    public bool? Presented { get; set; }
    public bool? Suspended { get; set; }
    public bool? Requisition { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    public int? IdReceipt { get; set; }
    
    public long? Utid { get; set; }
}
