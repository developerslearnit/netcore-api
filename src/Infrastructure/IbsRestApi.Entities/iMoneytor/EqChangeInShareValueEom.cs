namespace IbsRestApi.Entities.iMoneytor;

public partial class EqChangeInShareValueEom
{
    public int IdChangeInShareValueEom { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? Amount { get; set; }
    public string? VoucehrNo { get; set; }
    public bool? Reversed { get; set; }
    public int? ReversalId { get; set; }
    public string? Narration { get; set; }
    public string? PostedBy { get; set; }
    public int? IdChangeInShareValue { get; set; }
    public int? ShareId { get; set; }
}
