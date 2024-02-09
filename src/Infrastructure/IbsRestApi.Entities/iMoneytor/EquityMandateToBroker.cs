namespace IbsRestApi.Entities.iMoneytor;

public partial class EquityMandateToBroker
{
    public int IdEquityMandateToBrokers { get; set; }
    public int? IdEquityMandateMaster { get; set; }
    public string? BrokerId { get; set; }
    public DateTime? MandateDate { get; set; }
    public int? NoOfDays { get; set; }
    public DateTime? ExpireDate { get; set; }
    public string? Narration { get; set; }
    public short? PrintCount { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? ReviewedBy { get; set; }
    public bool? Revised { get; set; }
    public int? RevisedFromId { get; set; }
    public int? IdComplianceOverRideMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public string? MandateType { get; set; }
    
    public string? ReferenceNo { get; set; }
    public decimal? Amount { get; set; }
}
