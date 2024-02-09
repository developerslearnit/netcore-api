namespace IbsRestApi.Entities.iMoneytor;

public partial class LnMstAll
{
    public int LoanAllocationId { get; set; }
    public int? PortfolioId { get; set; }
    public int LoanId { get; set; }
    public decimal? Amount { get; set; }
    public decimal? QtyUnit { get; set; }
    public decimal? PrnReceived { get; set; }
    public decimal? IntReceived { get; set; }
    public DateTime? ValueDate { get; set; }
    
}
