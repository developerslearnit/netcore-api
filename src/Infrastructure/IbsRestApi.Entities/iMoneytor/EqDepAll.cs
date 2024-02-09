namespace IbsRestApi.Entities.iMoneytor;

public partial class EqDepAll
{
    public int DepAllocation { get; set; }
    public int? DepositId { get; set; }
    public int? PortfolioId { get; set; }
    public decimal? QtyRequested { get; set; }
    public decimal? AmountDeposited { get; set; }
    public decimal? QtyReceived { get; set; }
    public decimal? QtyRefund { get; set; }
    public decimal? AmountRefunded { get; set; }
    public decimal? Interest { get; set; }
    public int? IdEquityMandateMaster { get; set; }
    
}
