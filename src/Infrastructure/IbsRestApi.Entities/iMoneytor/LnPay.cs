namespace IbsRestApi.Entities.iMoneytor;

public partial class LnPay
{
    public int PaymentId { get; set; }
    public int? LoanId { get; set; }
    public string? PaymentType { get; set; }
    public string? Narration { get; set; }
    public decimal Amount { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? RepaymentRate { get; set; }
    public string CurrencyId { get; set; } = null!;
    public string? ReceiptNo { get; set; }
    public decimal? WitholdingTax { get; set; }
    public string? WithTaxReceiptNo { get; set; }
    public byte? Reversed { get; set; }
    public int? ReversalId { get; set; }
    public DateTime? TransactionDate { get; set; }
    public string? VoucherNo { get; set; }
    public string? ReceiptType { get; set; }
    public string? SourceBankId { get; set; }
    public string? SourceLocation { get; set; }
    public string? CheqNo { get; set; }
    public string? IdBankAccount { get; set; }
    public decimal? PrnAmount { get; set; }
    public decimal? IntAmount { get; set; }
    public decimal? QtyRedeemed { get; set; }
    public int? IdTerminate { get; set; }
    public DateTime? SettlementDate { get; set; }
    public decimal? ProfitLossOnDisposal { get; set; }
    public decimal? SalesProceed { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    public int? IdLnSymbolReceipt { get; set; }
    public decimal? IntAdjustment { get; set; }
    
    public DateTime? CouponDueDate { get; set; }
    public string? CapturedBy { get; set; }
}
