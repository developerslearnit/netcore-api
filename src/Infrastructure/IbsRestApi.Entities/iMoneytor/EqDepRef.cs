namespace IbsRestApi.Entities.iMoneytor;

public partial class EqDepRef
{
    public int RefundId { get; set; }
    public int? DepositId { get; set; }
    public string? Narration { get; set; }
    public decimal? QtyRefund { get; set; }
    public decimal? RefundAmount { get; set; }
    public decimal? Interest { get; set; }
    public DateTime? RefundDate { get; set; }
    public string? BankId { get; set; }
    public string? ChequeNo { get; set; }
    public string? VoucherNo { get; set; }
    public int? ReversalId { get; set; }
    public string? Comments { get; set; }
    public DateTime? SettlementDate { get; set; }
    public string? Status { get; set; }
    
    public string? CapturedBy { get; set; }
}
