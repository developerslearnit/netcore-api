namespace IbsRestApi.Entities.iMoneytor;

public partial class LoanMandateMaster
{
    public int IdLoanMandateMaster { get; set; }
    public string? TransType { get; set; }
    public string? BrokerId { get; set; }
    public DateTime? MandateDate { get; set; }
    public DateTime? ExpireDate { get; set; }
    public string? Narration { get; set; }
    public short? PrintCount { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public int? IdComplianceOverRideMaster { get; set; }
    public string? ReviewedBy { get; set; }
    public decimal? Amount { get; set; }
    public int? IdPortfolio { get; set; }
    
    public string? Reference { get; set; }
    public DateTime? SettlementDate { get; set; }
}
