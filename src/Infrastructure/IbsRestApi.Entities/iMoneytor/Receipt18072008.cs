namespace IbsRestApi.Entities.iMoneytor;

public partial class Receipt18072008
{
    public int IdReceipt { get; set; }
    public int? IdDealMaster { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? Valuedate { get; set; }
    public string? ReceiptFrom { get; set; }
    public string? Being { get; set; }
    public decimal? Amount { get; set; }
    public string? ReceiptType { get; set; }
    public string? SourceBankId { get; set; }
    public string? SourceLocation { get; set; }
    public string? CheqNo { get; set; }
    public string? IdBankAccount { get; set; }
    public string? ReceiptNo { get; set; }
    public int? ReversalId { get; set; }
    public DateTime? ReversalDate { get; set; }
    public byte? Replaced { get; set; }
    public string? Status { get; set; }
    public string? VoucherNo { get; set; }
    public decimal? Principal { get; set; }
    public decimal? Interest { get; set; }
    public decimal? InterestAdjustment { get; set; }
    public DateTime? SettlementDate { get; set; }
    public decimal? WithHoldTax { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    public int? IdDealTerminate { get; set; }
}
