namespace IbsRestApi.Entities.iMoneytor;

public partial class IfrsTbhfsHft
{
    public int? PortfolioId { get; set; }
    public string? Portfolio { get; set; }
    public int? IdPortfolioGroup { get; set; }
    public string? IdPortfolioGroupName { get; set; }
    public string? Narration { get; set; }
    public string? TreatmentType { get; set; }
    public DateTime? ValueDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? CleanPrice { get; set; }
    public DateTime? IssueDate { get; set; }
    public int? PremiumDiscount { get; set; }
    public double? CouponRate { get; set; }
    public decimal? Price { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? MaturityDate2 { get; set; }
    public decimal? OpenBalance { get; set; }
    public decimal? Addition { get; set; }
    public decimal? Disposals { get; set; }
    public decimal? CloseBalance { get; set; }
    public decimal? Received { get; set; }
    public double? AccruedBf { get; set; }
    public decimal? AccruedPrd { get; set; }
    public decimal? AccruedCf { get; set; }
    public decimal? MarketValue { get; set; }
}
