namespace IbsRestApi.Entities.iMoneytor;

public partial class EqDivReceivableMaster
{
    public int IdEqDivReceivableMaster { get; set; }
    public int? ShareId { get; set; }
    public int? DeclaredId { get; set; }
    public string? Narration { get; set; }
    public decimal? QtyUnit { get; set; }
    public decimal? DivRate { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? VoucherNo { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public int? ReversalId { get; set; }
    public bool? Reversed { get; set; }
    public DateTime? ReversalDate { get; set; }
    
    public string? CapturedBy { get; set; }
}
