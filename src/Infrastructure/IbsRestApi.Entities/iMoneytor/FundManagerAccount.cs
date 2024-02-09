namespace IbsRestApi.Entities.iMoneytor;

public partial class FundManagerAccount
{
    public int IdFundManagerAccount { get; set; }
    public string? BrokerId { get; set; }
    public string? InvestmentModule { get; set; }
    public int? IdDealMaster { get; set; }
    public int? LoanId { get; set; }
    public int? ShareId { get; set; }
    public int? RightId { get; set; }
    public int? DepositId { get; set; }
    public int? UniqueId { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? ValueDate { get; set; }
    public int? Quantity { get; set; }
    public decimal? UnitCost { get; set; }
    public decimal? Amount { get; set; }
    public string? Payee { get; set; }
    public string? Being { get; set; }
    public string? InstrumentType { get; set; }
    public string? SourceBankId { get; set; }
    public string? SourceLocation { get; set; }
    public string? ChequeNo { get; set; }
    public string? IdBankAccount { get; set; }
    public string? ReceiptNo { get; set; }
    public string? IdCurrency { get; set; }
    public decimal? CurExRate { get; set; }
    public string? VoucherNo { get; set; }
    public int? ReversalId { get; set; }
    public bool? Reversed { get; set; }
    public DateTime? ReversalDate { get; set; }
    public string? Status { get; set; }
    public DateTime? SettlementDate { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    
}
