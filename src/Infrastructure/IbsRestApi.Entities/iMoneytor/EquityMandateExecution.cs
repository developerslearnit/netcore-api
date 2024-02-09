namespace IbsRestApi.Entities.iMoneytor;

public partial class EquityMandateExecution
{
    public int IdEquityMandateExecution { get; set; }
    public int IdEquityMandateToBrokers { get; set; }
    public string? BrokerId { get; set; }
    public DateTime? CaptureDate { get; set; }
    public DateTime? ExecutionDate { get; set; }
    public string? Narration { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public int? IdComplianceOverRideMaster { get; set; }
    public string? TransType { get; set; }
    public string? ContractNoteNo { get; set; }
    public decimal? ContractNoteValue { get; set; }
    
    public int? IdPortfolioCustodian { get; set; }
    public string? IdBankAccount { get; set; }
}
