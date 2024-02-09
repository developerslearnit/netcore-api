namespace IbsRestApi.Entities.iMoneytor;

public partial class LnPayAdjustment
{
    public int IdLnPayAdjustment { get; set; }
    public int? LoanId { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? ValueDate { get; set; }
    public byte? Reversed { get; set; }
    public int? ReversalId { get; set; }
    public DateTime? TransactionDate { get; set; }
    public string? VoucherNo { get; set; }
    public decimal? PrnAmount { get; set; }
    public decimal? IntAmount { get; set; }
    public decimal? QtyRedeemed { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? AdjustPrnInt { get; set; }
    public string? AdjustmentEffect { get; set; }
    public string? CapturedBy { get; set; }
    public string? Approvedby { get; set; }
}
