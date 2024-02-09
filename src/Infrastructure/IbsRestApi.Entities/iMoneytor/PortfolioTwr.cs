namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioTwr
{
    public long IdPortfolioTwr { get; set; }
    public int? IdPortfolio { get; set; }
    public int? Id2link { get; set; }
    public string? IdAssetType { get; set; }
    public string? InvestmentClass { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? Purchase { get; set; }
    public decimal? Dividend { get; set; }
    public decimal? Sales { get; set; }
    public decimal? Bmv { get; set; }
    public decimal? Emv { get; set; }
    public decimal? DayReturn { get; set; }
    public decimal? Hpr { get; set; }
    public decimal? Twr { get; set; }
}
