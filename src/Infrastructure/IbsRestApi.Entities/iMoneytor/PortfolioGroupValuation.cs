namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioGroupValuation
{
    public int IdPortfolioGroupValuation { get; set; }
    public int? IdPortfolioGroupClassification { get; set; }
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
}
