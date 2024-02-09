namespace IbsRestApi.Entities.iMoneytor;

public partial class RpEqSchd
{
    public int EqSchdId { get; set; }
    public int? ShareId { get; set; }
    public int? PortfolioId { get; set; }
    public int? ShareBf { get; set; }
    public int? ShareAdd { get; set; }
    public int? ShareDisp { get; set; }
    public int? ShareCf { get; set; }
    public decimal? CostBf { get; set; }
    public decimal? CostAdd { get; set; }
    public decimal? CostDisp { get; set; }
    public decimal? CostCf { get; set; }
    public decimal? MarketPrice { get; set; }
    public decimal? MarketValue { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? ShareType { get; set; }
    public decimal? NetAssetValue { get; set; }
    
}
