namespace IbsRestApi.Entities.iMoneytor;

public partial class LnChangeInBondValue
{
    public int IdChangeInBondValue { get; set; }
    public int? LoanId { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? QtyUnit { get; set; }
    public decimal? CostOfBond { get; set; }
    public decimal? CurMrkPrice { get; set; }
    public decimal? PrvMrkPrice { get; set; }
    public decimal? Amount { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? PostedBy { get; set; }
    public bool? Reversed { get; set; }
    public int? ReversalId { get; set; }
}
