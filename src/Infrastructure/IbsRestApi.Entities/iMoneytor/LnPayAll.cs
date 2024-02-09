namespace IbsRestApi.Entities.iMoneytor;

public partial class LnPayAll
{
    public int PayAllocationId { get; set; }
    public int? LoanId { get; set; }
    public int PaymentId { get; set; }
    public int PortfolioId { get; set; }
    public decimal? Amount { get; set; }
    public decimal? PrnAmount { get; set; }
    public decimal? IntAmount { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? WitholdingTax { get; set; }
    public string? PaymentType { get; set; }
    public decimal? QtyRedeemed { get; set; }
    public decimal? ProfitLossOnDisposal { get; set; }
    public decimal? SalesProceed { get; set; }
    public decimal? IntAdjustment { get; set; }
    
}
