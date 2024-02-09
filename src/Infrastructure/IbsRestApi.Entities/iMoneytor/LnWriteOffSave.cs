namespace IbsRestApi.Entities.iMoneytor;

public partial class LnWriteOffSave
{
    public int? IdLnWriteOff { get; set; }
    public int? LoanId { get; set; }
    public DateTime? WriteOffDate { get; set; }
    public decimal? Amount { get; set; }
    public bool? Posted { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    public bool? DisposalPosted { get; set; }
    public bool? Reversed { get; set; }
    public int? ReversalId { get; set; }
    
    public decimal? OpenBalace { get; set; }
    public decimal? Eiramount { get; set; }
    public decimal? CloseBalance { get; set; }
}
