namespace IbsRestApi.Entities.iMoneytor;

public partial class EqDepRefAlloc
{
    public int IdEqDepRefAlloc { get; set; }
    public int? RefundId { get; set; }
    public int? PortfolioId { get; set; }
    public int? QtyUnit { get; set; }
    public decimal? Amount { get; set; }
    public decimal? InterestAmount { get; set; }
    public int? DepositId { get; set; }
    
}
