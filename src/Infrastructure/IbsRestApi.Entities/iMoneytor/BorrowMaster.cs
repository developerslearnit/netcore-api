namespace IbsRestApi.Entities.iMoneytor;

public partial class BorrowMaster
{
    public BorrowMaster()
    {
        BorrowAmortSchedules = new HashSet<BorrowAmortSchedule>();
        BorrowReceipts = new HashSet<BorrowReceipt>();
        BorrowTerminates = new HashSet<BorrowTerminate>();
        BorrowingTransactionFees = new HashSet<BorrowingTransactionFee>();
    }

    public int IdBorrowMaster { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public string? IdBorrowType { get; set; }
    public string? IdBranch { get; set; }
    public string? IdProductLine { get; set; }
    public string? IdLocation { get; set; }
    public string? IdCurrency { get; set; }
    public decimal? CurExRate { get; set; }
    public string? Description { get; set; }
    public decimal? FaceAmount { get; set; }
    public decimal? BorrowAmount { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public string? CalculationMethod { get; set; }
    public string? InterestMode { get; set; }
    public decimal? InterestRate { get; set; }
    public bool? InterestPaidUpfront { get; set; }
    public int? NoOfDays { get; set; }
    public byte? CompoundIntType { get; set; }
    public int? NoOfMonths { get; set; }
    public string? RePayGap { get; set; }
    public int? MoratoriumDays { get; set; }
    public decimal? MoratoriumInterest { get; set; }
    public bool? CapitaliseMoratorium { get; set; }
    public decimal? RentalAmount { get; set; }
    public DateTime? FirstPaymentDueDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? ManagementFeesRate { get; set; }
    public decimal? ManagementFees { get; set; }
    public decimal? LegalFeesRate { get; set; }
    public decimal? LegalFees { get; set; }
    public decimal? AvailmentFeesRate { get; set; }
    public decimal? AvailmentFees { get; set; }
    public decimal? OtherFeesRate { get; set; }
    public decimal? OtherFees { get; set; }
    public decimal? TotalFess { get; set; }
    public bool? CapitaliseFees { get; set; }
    public bool? ApplyVat { get; set; }
    public decimal? VatAmount { get; set; }
    public bool? ApplyWithTax { get; set; }
    public decimal? WithholdTaxAmount { get; set; }
    public string? RePaymentType { get; set; }
    public string? Status { get; set; }
    public decimal? InterestAmount { get; set; }
    public string? Notes { get; set; }
    public int? OriginalIdBorrowMaster { get; set; }
    public int? RollOverFromId { get; set; }
    public int? RollOverToId { get; set; }
    public decimal? PurchaseOptionRate { get; set; }
    public decimal? PurchaseOption { get; set; }
    public decimal? ResidualRate { get; set; }
    public decimal? ResidualValue { get; set; }
    public decimal? Amt2Withdraw { get; set; }
    public decimal? Amt2Add { get; set; }
    public string? StockExchangeId { get; set; }
    public bool? Discountable { get; set; }
    public decimal? ComisionRate { get; set; }
    public decimal? CommisionAmount { get; set; }
    public string? InvestmentType { get; set; }
    public DateTime? SettlementDate { get; set; }
    public string? BrokerId { get; set; }
    public decimal? EffectiveYield { get; set; }
    public bool? CapitaliseUpfrontInterest { get; set; }
    public string? BorrowNumber { get; set; }
    public int? IdMoneyMarketQoutation2BorrowSlip { get; set; }
    public int? IdPortfolioContributorBranch { get; set; }
    public decimal? NewMatureValue { get; set; }
    public long? Utid { get; set; }
    public bool? TreasuryBill { get; set; }
    public decimal? TbQtyBought { get; set; }
    public decimal? TbQtySold { get; set; }
    public string? CapturedBy { get; set; }
    public DateTime? CapturedDate { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public short? RollOverCount { get; set; }
    public string? ExtBorrowNumber { get; set; }
    public decimal? Com1Rate { get; set; }
    public decimal? Com2Rate { get; set; }
    public int? IdPortfolioOwner { get; set; }
    public bool? FeesPosted { get; set; }
    public int? IdCro { get; set; }
    public int? Id2Cr { get; set; }
    public bool? ChargeMgtFeesOnInterest { get; set; }
    public decimal? DeductStampDuty { get; set; }
    public bool? StampDutyPosted { get; set; }
    public string? MaturityTreatment { get; set; }
    public bool? OverRideInteresRate { get; set; }
    public string? AutoRollOverType { get; set; }
    public int? Ucid { get; set; }
    public bool? CalcBestFaceValue { get; set; }
    public decimal? BestFaceValue { get; set; }
    public string? DeductInterestEvery { get; set; }
    public decimal? CustodyFees { get; set; }
    public decimal? CustodyFeeRate { get; set; }
    public decimal? OtherDeduction { get; set; }
    public string? Agent01 { get; set; }
    public string? Agent02 { get; set; }
    public decimal? WhtRate { get; set; }
    public int? RolOverTenor { get; set; }
    public decimal? RolOverIntRate { get; set; }
    public bool? SuppressAutoRollOver { get; set; }
    public int? IdSignature { get; set; }

    public virtual BorrowType? IdBorrowTypeNavigation { get; set; }
    public virtual ICollection<BorrowAmortSchedule> BorrowAmortSchedules { get; set; }
    public virtual ICollection<BorrowReceipt> BorrowReceipts { get; set; }
    public virtual ICollection<BorrowTerminate> BorrowTerminates { get; set; }
    public virtual ICollection<BorrowingTransactionFee> BorrowingTransactionFees { get; set; }
}
