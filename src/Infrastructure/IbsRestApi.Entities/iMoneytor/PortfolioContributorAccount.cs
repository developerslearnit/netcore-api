namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributorAccount
{
    public PortfolioContributorAccount()
    {
        PortfolioContributorRedemptions = new HashSet<PortfolioContributorRedemption>();
    }

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
    public int? UniqueId { get; set; }
    public decimal? IncentiveDueNow { get; set; }
    public bool? Exported { get; set; }
    public decimal? CostOfUnits { get; set; }
    public string? BankBranchName { get; set; }
    public string? AccountNo { get; set; }
    public bool? CalculateRebate { get; set; }
    public int? LockInDays { get; set; }
    public decimal? GrossAmountReceived { get; set; }
    public bool? DeductStampDuty { get; set; }
    public decimal? StanpDutyAmount { get; set; }
    public bool? RedeemPlusProfit { get; set; }
    public bool? PortfolioDirectInvestment { get; set; }
    public int? IdPortfolioDirect { get; set; }
    public DateTime? AddPenalty2IncomeDate { get; set; }
    public string? IdCashMgtAccount { get; set; }
    public int? IdBorrowMaster { get; set; }
    public string? IdBankEft { get; set; }
    public decimal? Employer { get; set; }
    public decimal? Employee { get; set; }
    public decimal? AdditionalContribution { get; set; }
    public decimal? AdditionalContributionUnit { get; set; }
    public decimal? Otherpayment4 { get; set; }
    public decimal? Otherpayment5 { get; set; }
    public decimal? Otherpayment6 { get; set; }
    public decimal? Otherpayment7 { get; set; }
    public decimal? Otherpayment8 { get; set; }
    public decimal? Otherpayment9 { get; set; }
    public decimal? Otherpayment10 { get; set; }
    public decimal? Intrest { get; set; }
    public string? TransRefNo { get; set; }
    public string? PrintBatch { get; set; }
    public string? RedemptionType { get; set; }
    public bool? OverRideBankAccount { get; set; }
    
    public decimal? PenaltyRate { get; set; }
    public string? IdApplication { get; set; }

    public virtual PortfolioContributor? IdPortfolioContributorNavigation { get; set; }
    public virtual ICollection<PortfolioContributorRedemption> PortfolioContributorRedemptions { get; set; }
}
