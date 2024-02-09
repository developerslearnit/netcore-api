namespace IbsRestApi.Entities.iMoneytor;

public partial class FixedInterestPaymentMaster
{
    public int IdFixedInterestPaymentMaster { get; set; }
    public string? IdInvestmentType { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? DueDate { get; set; }
    public string? Narration { get; set; }
    public string? IdProductType { get; set; }
    public int? RecordCount { get; set; }
    public decimal? TotalAmount { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? CapturedBy { get; set; }
    public DateTime? CaptureDate { get; set; }
    public string? VerifiedBy { get; set; }
    public DateTime? VerifiedDate { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public string? IdBankAccount { get; set; }
    public string? IdCurrency { get; set; }
    public string? ApprovedByHead { get; set; }
    public DateTime? ApprovedByHeadDate { get; set; }
    public string? DisbursedBy { get; set; }
    public DateTime? DisburesedDate { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
}
