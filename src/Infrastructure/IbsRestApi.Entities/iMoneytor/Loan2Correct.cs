namespace IbsRestApi.Entities.iMoneytor;

public partial class Loan2Correct
{
    public int IdLoan2Correct { get; set; }
    public int? LoanId { get; set; }
    public int? LoanQtyUnit { get; set; }
    public DateTime? Capturedate { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public string? Reason4Correction { get; set; }
    public string? OldSymbol { get; set; }
    public string? NewSymbol { get; set; }
    public decimal? OldInterestRate { get; set; }
    public decimal? NewInterestRate { get; set; }
    public string? OldPrincpalType { get; set; }
    public string? NewPrincpalType { get; set; }
    public decimal? PostedInterest2Date { get; set; }
    public decimal? NewInterest2Date { get; set; }
    public decimal? DiffInterest2Post { get; set; }
    public string? Status { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public string? Comments { get; set; }
    public DateTime? NewMaturityDate { get; set; }
}
