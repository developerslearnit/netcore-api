namespace IbsRestApi.Entities.iMoneytor;

public partial class FixedIncome
{
    public int IdValuation { get; set; }
    public string Asset { get; set; } = null!;
    public int? IdPortfolio { get; set; }
    public int? Id2link { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? YieldRate { get; set; }
    public decimal? InterestRate { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public string? AssetClass { get; set; }
    public decimal? AssetValue { get; set; }
    public decimal? CostOfAsset { get; set; }
    public decimal? DayInterest { get; set; }
}
