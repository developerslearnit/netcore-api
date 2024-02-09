namespace IbsRestApi.Entities.iMoneytor;

public partial class EquityBrokersDrCrRequisition
{
    public int IdEquityBrokersDrCrRequisition { get; set; }
    public string? BrokerId { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? RequestType { get; set; }
    public string? IdCurrency { get; set; }
    public string? TransactionType { get; set; }
    public int? IdPortfolio { get; set; }
    public bool? Reversed { get; set; }
    public int? ReversalId { get; set; }
    
}
