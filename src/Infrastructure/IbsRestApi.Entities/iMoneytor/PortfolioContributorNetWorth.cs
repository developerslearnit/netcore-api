namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributorNetWorth
{
    public int IdPortfolioContrinutorNetWorth { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? NetWorthDate { get; set; }
    public string? InvestmentModule { get; set; }
    public int? Id2link { get; set; }
    public string? IdSubInvestmentType { get; set; }
    public string? IdInvestmentType { get; set; }
    public int? NoOfDays { get; set; }
    public decimal? MarketPrice { get; set; }
    public decimal? QtyOwned { get; set; }
    public decimal? AssetValue { get; set; }
    public decimal? AssetCost { get; set; }
    public decimal? FeesAccrued { get; set; }
    public decimal? InterestAccrued { get; set; }
    public decimal? WtaxAmount { get; set; }
    public decimal? NetAssetValue { get; set; }
    public DateTime? MaturityDate { get; set; }
    public int? Ucid { get; set; }
}
