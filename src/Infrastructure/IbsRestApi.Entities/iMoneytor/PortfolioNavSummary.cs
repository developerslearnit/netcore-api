namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioNavSummary
{
    public int IdPortfolioValuationHistory { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? NetAssetVaule { get; set; }
    public decimal? TotalUnits { get; set; }
    public decimal? UnitValue { get; set; }
    public decimal? OfferPrice { get; set; }
    public decimal? BidPrice { get; set; }
    public decimal? DayNetIncome { get; set; }
    public decimal? DayNav { get; set; }
    public decimal? DayYield { get; set; }
    public decimal? MgtFeesBf { get; set; }
    public decimal? MtmnetAssetValue { get; set; }
    public decimal? DayWam { get; set; }
    
    public decimal Prov4Disposal { get; set; }
    public decimal EquityValue { get; set; }
}
