namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioInterestAllocation
{
    public int IdPortfolioInterestAllocation { get; set; }
    public int? IdPortfolioInterestMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal? InterestAmount { get; set; }
    
}
