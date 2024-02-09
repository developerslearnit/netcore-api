namespace IbsRestApi.Entities.iMoneytor;

public partial class OnlinePortfolio
{
    public int ID { get; set; }
    public int IdPortfolio { get; set; }
    public string PortfolioName { get; set; }
    public string Description { get; set; } = null!;
    public string PortfolioImage { get; set; } = null!;
    public decimal? MinSubAmount { get; set; }
    public string? ProductType { get; set; }
    public string? BankCode { get; set; }
    public string? AccountNumber { get; set; }
    public string? PayStackAccountCode { get; set; }
    public string? Benefits { get; set; }
    public string? RiskLevel { get; set; }
    public string? MinimumHoldingPeriod { get; set; }
    public string? Trustees { get; set; }
    public string? IncomeDistribution { get; set; }
    public string? FundType { get; set; }
    public string? InvestmentObjective { get; set; }
    public decimal? MinimumAdditionalInvestment { get; set; }
    public string? RedemptionPeriod { get; set; }
    public string? YeildDescription { get; set; }
    public string ID_BorrowType { get; set; }
}
