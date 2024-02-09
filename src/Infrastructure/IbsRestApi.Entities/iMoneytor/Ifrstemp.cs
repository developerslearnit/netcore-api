namespace IbsRestApi.Entities.iMoneytor;

public partial class Ifrstemp
{
    public string? Portfolio { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? FaceValue { get; set; }
    public decimal? CleanPrice { get; set; }
    public DateTime? IssueDate { get; set; }
    public int? PremiumDiscount { get; set; }
    public decimal? CouponRate { get; set; }
    public decimal? Price { get; set; }
    public int? RpLnSchdId { get; set; }
    public int? LoanId { get; set; }
    public string? Symbol { get; set; }
    public string? Narration { get; set; }
    public int? PortfolioId { get; set; }
    public int? LoanTypeId { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public int? Tenor { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? OpenBalance { get; set; }
    public decimal? Addition { get; set; }
    public decimal? Disposals { get; set; }
    public decimal? CloseBalance { get; set; }
    public decimal? IntRate { get; set; }
    public decimal? GrossRecd { get; set; }
    public decimal? WithTax { get; set; }
    public decimal? AcrBf { get; set; }
    public decimal? AcrPl { get; set; }
    public decimal? IntAdj { get; set; }
    public decimal? NetPl { get; set; }
    public decimal? AcrCf { get; set; }
    public decimal? MrkPrice { get; set; }
    public decimal? QtyUnit { get; set; }
    public decimal? MarketValue { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
}
