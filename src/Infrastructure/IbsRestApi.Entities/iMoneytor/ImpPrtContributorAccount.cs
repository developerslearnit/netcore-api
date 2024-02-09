namespace IbsRestApi.Entities.iMoneytor;

public partial class ImpPrtContributorAccount
{
    public int IdImpPrtContributoAccount { get; set; }
    public string? AccountCode { get; set; }
    public string? ProductCode { get; set; }
    public string? ReceiptType { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? ReceiptDate { get; set; }
    public int? DaysToClear { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? Amount { get; set; }
    public string? Narration { get; set; }
    public string? ChequeNo { get; set; }
    public string? IdReferedByBranch { get; set; }
    public string? AgentCode { get; set; }
    public string? AgentName { get; set; }
    public string? Status { get; set; }
    public bool? CompleteOnImport { get; set; }
    public string? CapturedBy { get; set; }
    public DateTime? DateCaptured { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? DateApproved { get; set; }
    public string? Comments { get; set; }
    public string? IdBankAccount { get; set; }
    public int? UniqueId { get; set; }
    public decimal? Employer { get; set; }
    public decimal? Employee { get; set; }
    public decimal? AdditionalContribution { get; set; }
    public decimal? AdditionalContributionUnit { get; set; }
    public decimal? Otherpayment4 { get; set; }
    public decimal? Otherpayment5 { get; set; }
    public decimal? Otherpayment6 { get; set; }
    public decimal? Otherpayment7 { get; set; }
    public decimal? Otherpayment8 { get; set; }
    public decimal? Otherpayment9 { get; set; }
    public decimal? Otherpayment10 { get; set; }
    public decimal? Intrest { get; set; }
    public string? TransRefNo { get; set; }
}
