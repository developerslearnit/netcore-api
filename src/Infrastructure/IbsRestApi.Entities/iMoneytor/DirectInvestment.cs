namespace IbsRestApi.Entities.iMoneytor;

public partial class DirectInvestment
{
    public int IdDirectInvestment { get; set; }
    public int? IdPortfolio { get; set; }
    public int? InvestInIdPortfolio { get; set; }
    public int? IdPorfolioContributor { get; set; }
    public string? Narration { get; set; }
    public DateTime? InvestmentDate { get; set; }
    public decimal? Amount { get; set; }
    public decimal? NoOfUnits { get; set; }
    public decimal? GainLoss { get; set; }
    public decimal? AssetValue { get; set; }
    public string? CapturedBy { get; set; }
    public DateTime? CaptureDate { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
}
