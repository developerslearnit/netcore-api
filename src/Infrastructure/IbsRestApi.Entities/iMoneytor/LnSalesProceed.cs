namespace IbsRestApi.Entities.iMoneytor;

public partial class LnSalesProceed
{
    public int IdSalesProceed { get; set; }
    public int? IdLnTerminate { get; set; }
    public int? LoanId { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? CurrencyId { get; set; }
    public string? ReceiptNo { get; set; }
    public decimal? WitholdingTax { get; set; }
    public string? WithTaxReceiptNo { get; set; }
    public DateTime? TransactionDate { get; set; }
    public string? VoucherNo { get; set; }
    public string? ReceiptType { get; set; }
    public string? SourceBankId { get; set; }
    public string? SourceLocation { get; set; }
    public string? CheqNo { get; set; }
    public string? IdBankAccount { get; set; }
    public byte? Reversed { get; set; }
    public int? ReversalId { get; set; }
    public decimal? PrnAmount { get; set; }
    public decimal? IntAmount { get; set; }
    public decimal? QtyRedeemed { get; set; }
    public DateTime? SettlementDate { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    
}
