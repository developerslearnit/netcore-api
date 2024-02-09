namespace IbsRestApi.Entities.iMoneytor;

public partial class Loan2Convert
{
    public int IdLoan2Convert { get; set; }
    public int? LoanId { get; set; }
    public string? OldIdTreatmentType { get; set; }
    public int? LoanQtyUnit { get; set; }
    public DateTime? Capturedate { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public string? Reason4Conversion { get; set; }
    public string? NewIdTreatmentType { get; set; }
    public decimal? PostedPremDisc2Date { get; set; }
    public decimal? NewPremDisc2Date { get; set; }
    public decimal? DiffPremDisc2Post { get; set; }
    public string? Status { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public string? Comments { get; set; }
    public string? WriteOffType { get; set; }
    public decimal? AmortYieldRate { get; set; }
    public bool? YieldOverRidePurchase { get; set; }
    public bool? YieldOverRideAmorise { get; set; }
    public bool? AmortiseInFullCoupon { get; set; }
    public string? VoucherNo { get; set; }
}
