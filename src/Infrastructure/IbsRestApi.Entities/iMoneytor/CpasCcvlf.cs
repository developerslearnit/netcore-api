namespace IbsRestApi.Entities.iMoneytor;

public partial class CpasCcvlf
{
    public int IdValuation { get; set; }
    public int? IdPortfolio { get; set; }
    public string? Symbol { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? Qty { get; set; }
    public decimal? UnitCost { get; set; }
    public decimal? CurMrkPrice { get; set; }
    public decimal? AssetValue { get; set; }
    public decimal? GainLoss { get; set; }
    public decimal? CostOfAsset { get; set; }
    public decimal? IntRate { get; set; }
    public decimal? Interest2Date { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? WriteOffAmount { get; set; }
    public decimal? Amortized2Date { get; set; }
    public decimal? UnAmortized2Date { get; set; }
    public string? PremiumDiscount { get; set; }
    public decimal? DailyInterest { get; set; }
    public decimal? DailyAmortise { get; set; }
    public string? InvestmentModule { get; set; }
}
