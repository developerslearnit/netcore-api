namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioInvestmentPolicy
{
    public int IdInvestmentPolicy { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? IdRiskProfile { get; set; }
    public string? MgtMode { get; set; }
    public string? Objective { get; set; }
    public decimal? ReturnExpected { get; set; }
    public decimal? LossTolerance { get; set; }
    public DateTime? NextReviewDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? Capturedby { get; set; }
    public DateTime? CapturedDate { get; set; }
}
