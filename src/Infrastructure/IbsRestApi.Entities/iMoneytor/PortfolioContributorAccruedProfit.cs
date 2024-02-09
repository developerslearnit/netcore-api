namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributorAccruedProfit
{
    public int IdContributorAccruedProfit { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public int? IdPortfolioContributorAccount { get; set; }
    public int? IdRedemptionContributorAccount { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? Units2Sell { get; set; }
    public decimal? TotalUnits { get; set; }
    public decimal? NetIncome { get; set; }
    public decimal? MgtFees { get; set; }
    public decimal? Profit2Share { get; set; }
    public decimal? HoldersProfit { get; set; }
}
