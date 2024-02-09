namespace IbsRestApi.Entities.iMoneytor;

public partial class ViewPortfolioPerformance
{
    public int IdPortfolioValuationHistory { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? NetAssetVaule { get; set; }
    public decimal? TotalUnits { get; set; }
    public decimal? UnitValue { get; set; }
    public decimal? Principal { get; set; }
}
