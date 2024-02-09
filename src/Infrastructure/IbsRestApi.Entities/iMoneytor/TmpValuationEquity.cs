namespace IbsRestApi.Entities.iMoneytor;

public partial class TmpValuationEquity
{
    public int IdValEquity { get; set; }
    public int? IdPortfolio { get; set; }
    public int? Id2link { get; set; }
    public string? SecurityName { get; set; }
    public decimal? Qty { get; set; }
    public decimal? CurMrkPrice { get; set; }
    public decimal? MarketValue { get; set; }
    public decimal? AssetValue { get; set; }
    public decimal? GainLoss { get; set; }
    public decimal? PercGrowth { get; set; }
    public decimal? PercOfTotal { get; set; }
    public decimal? DividendExpctd { get; set; }
}
