namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioInterestSharing
{
    public int IdPortfolioInterestSharing { get; set; }
    public int? IdPortfolioInterestMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? Balance { get; set; }
    public int? NoOfDays { get; set; }
    public int? Factor { get; set; }
    public decimal? Wac { get; set; }
    public decimal? Amount { get; set; }
    
}
