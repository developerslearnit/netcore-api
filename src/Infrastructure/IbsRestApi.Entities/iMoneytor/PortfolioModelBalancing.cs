namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioModelBalancing
{
    public int IdPortfolioModelBalancing { get; set; }
    public DateTime? BalancingDate { get; set; }
    public int? IdPortfolio { get; set; }
    public int? IdCustomer { get; set; }
    public string? InvestmentModule { get; set; }
    public int? ShareId { get; set; }
    public decimal? QtyOwned { get; set; }
    public decimal? CurrentMarketValue { get; set; }
    public decimal? ComittedCashAmount { get; set; }
    public decimal? SectorPercent { get; set; }
    public decimal? SecurityPercent { get; set; }
    public decimal? CashAvailable { get; set; }
    public decimal? SectorUnUsed { get; set; }
    public decimal? SecurityUnUsed { get; set; }
    public string? ActionToTake { get; set; }
    public decimal? BalancingAmount { get; set; }
    public decimal? BalancingQty { get; set; }
    public string? Status { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Comments { get; set; }
    
}
