namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioIntCalculator
{
    public int IdPortfolioIntCalculator { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal? Amount { get; set; }
    public decimal? Balance { get; set; }
    public DateTime? BeginDate { get; set; }
    public decimal? InterestRate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? NoOfDays { get; set; }
    public decimal? InterestAccrued { get; set; }
    public int? IdPortfolioAccount { get; set; }
    
}
