namespace IbsRestApi.Entities.iMoneytor;

public partial class Myportfolioaccount
{
    public int IdPortfolioAccount { get; set; }
    public int? IdPortfolio { get; set; }
    public string? IdInvestmentType { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? Amount { get; set; }
    public string? Narration { get; set; }
    public string? IdCurrency { get; set; }
    public decimal? CurExRate { get; set; }
    public string? VoucherNo { get; set; }
    public string? TrackCode { get; set; }
    public int? ReversalId { get; set; }
    public short? Injection { get; set; }
    public DateTime? SettlementDate { get; set; }
    public string? SourceBankId { get; set; }
    public string? SorceLocation { get; set; }
    public string? ChequeNo { get; set; }
    public string? IdBankAccount { get; set; }
    public string? ReceiptNo { get; set; }
    public string? ReceiptPaymentType { get; set; }
    public string? TransactionType { get; set; }
    public int? IdPortfolioContributorAccount { get; set; }
    public bool? CalculateRebate { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    
    public string? IdCashForeCastClass { get; set; }
}
