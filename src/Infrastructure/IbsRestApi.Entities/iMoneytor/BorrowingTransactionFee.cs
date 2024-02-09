namespace IbsRestApi.Entities.iMoneytor;

public partial class BorrowingTransactionFee
{
    public int IdBorrowingTransactionFees { get; set; }
    public int? IdBorrowMaster { get; set; }
    public string? FeesType { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount { get; set; }
    public bool? Posted2cash { get; set; }
    public bool? Posted2Gl { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public bool? Reversed { get; set; }
    public int? ReversalId { get; set; }
    public DateTime? ValueDate { get; set; }
    public long? Utid { get; set; }
    public DateTime? CashPostDate { get; set; }

    public virtual BorrowMaster? IdBorrowMasterNavigation { get; set; }
}
