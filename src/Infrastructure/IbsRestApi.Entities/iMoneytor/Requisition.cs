namespace IbsRestApi.Entities.iMoneytor;

public partial class Requisition
{
    public int IdRequisition { get; set; }
    public int? IdDealMaster { get; set; }
    public DateTime? RequestDate { get; set; }
    public string? Payee { get; set; }
    public string? Being { get; set; }
    public string? RequestType { get; set; }
    public decimal? Amount { get; set; }
    public string? Status { get; set; }
    public string? VoucherNo { get; set; }
    public int? ReversalId { get; set; }
    public int? LoanId { get; set; }
    public string? BrokerId { get; set; }
    public DateTime? SettlementDate { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    public int? IdDealTerminateTracker { get; set; }
    
    public long? Utid { get; set; }
    public string? CapturedBy { get; set; }
}
