namespace IbsRestApi.Entities.iMoneytor;

public partial class EqChangeInShareValue
{
    public int IdChangeInShareValue { get; set; }
    public int? ShareId { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? Amount { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? PostedBy { get; set; }
    public bool? Reversed { get; set; }
    public int? ReversalId { get; set; }
    public string? Comments { get; set; }
    public decimal? QtyUnit { get; set; }
    public decimal? CostOfShares { get; set; }
    public decimal? CurMrkPrice { get; set; }
    public decimal? PrvMrkPrice { get; set; }
    public int? IdChangeInShareValueEom { get; set; }
    
}
