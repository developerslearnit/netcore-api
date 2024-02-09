namespace IbsRestApi.Entities.iMoneytor;

public partial class TmpLnSymbolReceipt
{
    public int IdLnSymbolReceipt { get; set; }
    public string? Symbol { get; set; }
    public string? PaymentType { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? ValueDate { get; set; }
    public DateTime? TransactionDate { get; set; }
    public string CurrencyId { get; set; } = null!;
    public string? ReceiptNo { get; set; }
    public decimal? WitholdingTax { get; set; }
    public byte? Reversed { get; set; }
    public int? ReversalId { get; set; }
    public string? ReceiptType { get; set; }
    public string? SourceBankId { get; set; }
    public string? SourceLocation { get; set; }
    public string? CheqNo { get; set; }
    public string? IdBankAccount { get; set; }
    public decimal? PrnAmount { get; set; }
    public decimal? IntAmount { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
}
