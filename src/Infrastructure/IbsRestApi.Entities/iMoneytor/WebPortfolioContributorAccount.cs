namespace IbsRestApi.Entities.iMoneytor;

public partial class WebPortfolioContributorAccount
{
    public int IdPortfolioContributorAccount { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? Amount { get; set; }
    public decimal? UnitValue { get; set; }
    public decimal? NoOfUnits { get; set; }
    public string? TransactionType { get; set; }
    public string? ChequeNo { get; set; }
    public string? IdBank { get; set; }
    public string? IdBankAccount { get; set; }
    public string? CertficateStatus { get; set; }
    public decimal? CertificateUnits { get; set; }
    public int? Reversed { get; set; }
    public int? ReversalId { get; set; }
    public string? Status { get; set; }
    public int? IdPortfolio { get; set; }
    public string? CertificateNo { get; set; }
    public string? PaymentType { get; set; }
    public string? Narration { get; set; }
    public decimal? PenaltyCharge { get; set; }
    public decimal? UnitsSold { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    public string? IdCurrency { get; set; }
    public string? Comments { get; set; }
    public string? CapturedBy { get; set; }
    public short? Days2Clear { get; set; }
    public DateTime? ReceiptDate { get; set; }
    public int? IdPortfolioContributorBulkAccount { get; set; }
    public int? IdImpPrtContributoAccount { get; set; }
}
