namespace IbsRestApi.Entities.iMoneytor;

public partial class LnTerminateAllocation
{
    public int IdLnTerminateAllocation { get; set; }
    public int? IdLnTerminate { get; set; }
    public int? LoanId { get; set; }
    public int? PortfolioId { get; set; }
    public decimal? QtySold { get; set; }
    public decimal? CostPrice { get; set; }
    public decimal? SalesProceed { get; set; }
    public decimal? ProfitLoss { get; set; }
    public decimal? IntAmount { get; set; }
    public decimal? PremDisc2Post { get; set; }
    public decimal? ManualSalesCoupon { get; set; }
    public decimal? PremDiscSold { get; set; }
    
    public decimal? PremDiscSold2 { get; set; }
    public decimal? PremDisc2Reverse { get; set; }
    public decimal? Interest2Reverse { get; set; }
    public decimal? UnRealiseGainLoss { get; set; }
    public decimal? CostOfBond { get; set; }
}
