namespace IbsRestApi.Entities.iMoneytor;

public partial class Portfolio
{
    public Portfolio()
    {
        PortfolioAccounts = new HashSet<PortfolioAccount>();
        PortfolioManagementFees = new HashSet<PortfolioManagementFee>();
        PortfolioOtherFeesMasters = new HashSet<PortfolioOtherFeesMaster>();
        PortfolioUnitHistories = new HashSet<PortfolioUnitHistory>();
        PortfolioValuationHistories = new HashSet<PortfolioValuationHistory>();
        ValuationHistories = new HashSet<ValuationHistory>();
    }

    public int IdPortfolio { get; set; }
    public int? IdPortfolioGroup { get; set; }
    public string? Portfolio1 { get; set; }
    public string? ContactPerson { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? IdState { get; set; }
    public string? Telephones { get; set; }
    public string? GsmNo { get; set; }
    public string? Email { get; set; }
    public bool? ApplyCompliance { get; set; }
    public bool? DoNotEarnComision { get; set; }
    public decimal? ManagementFees { get; set; }
    public decimal? IncomeFeesRate { get; set; }
    public string? MainAccount { get; set; }
    public string? ManagementFeesIncomeAccount { get; set; }
    public string? IncomeFeesAccountNo { get; set; }
    public string? Status { get; set; }
    public string? SfkaccountCode { get; set; }
    public bool? UnitBased { get; set; }
    public decimal? InitialUnitValue { get; set; }
    public decimal? TotalUnits { get; set; }
    public decimal? OfferPrice { get; set; }
    public decimal? BidPrice { get; set; }
    public decimal? NetAssetValue { get; set; }
    public decimal? BrokerageFee { get; set; }
    public bool? BearBrokersComision { get; set; }
    public string? FeesIncomeReserve { get; set; }
    public decimal? PfamgtFees { get; set; }
    public decimal? PfcmgtFees { get; set; }
    public decimal? PcmmgtFees { get; set; }
    public string? SurName { get; set; }
    public string? FirstName { get; set; }
    public decimal? InitialInvestmentAmount { get; set; }
    public string? IdReferedByBranch { get; set; }
    public string? ReferedByOfficer { get; set; }
    public bool? OnLineAccess { get; set; }
    public string? PinNo { get; set; }
    public string? AccountClass { get; set; }
    public bool? DocumentationWaved { get; set; }
    public bool? SearchConducted { get; set; }
    public bool? SearchOkay { get; set; }
    public string? SearchComments { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Sex { get; set; }
    public string? EmploymentStatus { get; set; }
    public int? IdEmployer { get; set; }
    public DateTime? AccountOpenDate { get; set; }
    public DateTime? AccountClosureDate { get; set; }
    public string? EquityValuationMedhod { get; set; }
    public string? RealEstateValuationMethod { get; set; }
    public string? FixedIncomeValuationMethod { get; set; }
    public string? ReportDeliveryMethod { get; set; }
    public bool? XMasGift { get; set; }
    public DateTime? ContractDate { get; set; }
    public int? ContractTenor { get; set; }
    public DateTime? ExpireDate { get; set; }
    public int? RenewalCount { get; set; }
    public DateTime? LastRenuwalDate { get; set; }
    public string? MgtFeesBasedOn { get; set; }
    public byte? DeductMgtFeesEvery { get; set; }
    public DateTime? NextMgtFeeDeductDate { get; set; }
    public DateTime? LastMgtFeeDeductDate { get; set; }
    public string? IncentiveBasedOn { get; set; }
    public int? IdIncentiveBenchmark { get; set; }
    public string? IncentiveCalcMethod { get; set; }
    public decimal? GuaranteeYield { get; set; }
    public byte? DeductIncentiveEvery { get; set; }
    public decimal? IncentiveRate { get; set; }
    public int? WaiverPeriod { get; set; }
    public DateTime? NextIncentiveDueDate { get; set; }
    public DateTime? LastIncentiveDueDate { get; set; }
    public decimal? CrIntRate { get; set; }
    public decimal? DrIntRate { get; set; }
    public decimal? MinCrBalance { get; set; }
    public string? EarlyTerminationPenalty { get; set; }
    public string? WaiverNotes { get; set; }
    public string? Comments { get; set; }
    public string? IncentiveIncomeActNo { get; set; }
    public int? IntFreeDaysOnDrBalance { get; set; }
    public string? InterestExpenseActNo { get; set; }
    public string? InterestIncomeActNo { get; set; }
    public decimal? RiskFactor { get; set; }
    public decimal? TimeFactor { get; set; }
    public string? MgtFeesPer { get; set; }
    public int? CompoundEvery { get; set; }
    public DateTime? LastCompoundDate { get; set; }
    public string? IdCurrency { get; set; }
    public bool? ApplyWitholdingTax { get; set; }
    public bool? ApplyVat { get; set; }
    public decimal? PenaltyMgtFeesRate { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public string? IdRelationshipManager { get; set; }
    public string? Pword { get; set; }
    public string? Cscsid { get; set; }
    public string? InvestorActNo { get; set; }
    public DateTime? ValuationDate { get; set; }
    public bool? ChargeFeesOnGrossNav { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public bool? DeliverReportByHold { get; set; }
    public bool? DeliverReportByPost { get; set; }
    public bool? DeliverReportByEMail { get; set; }
    public int? LockInDays { get; set; }
    public decimal? LockInPenaltyRate { get; set; }
    public string? ShortName { get; set; }
    public decimal? BuyComisionRate { get; set; }
    public decimal? SellComisionRate { get; set; }
    public int? RegistrarId { get; set; }
    public decimal? MinCashBalance { get; set; }
    public decimal? OriginalNav { get; set; }
    public bool? AlowDepositWithrawal { get; set; }
    public bool? DoNotAccrueDividend { get; set; }
    public bool? StopMgtFeesOnLoss { get; set; }
    public string? MothersMaidenName { get; set; }
    public string? MaritalStatus { get; set; }
    public string? IdStateOfOrigin { get; set; }
    public int? IdOccupation { get; set; }
    public string? RcNumber { get; set; }
    public string? IdIdentifyWith { get; set; }
    public string? Idnumber { get; set; }
    public bool? StableVav { get; set; }
    public byte? RebalanceEveryXmth { get; set; }
    public DateTime? LastDividendPayDate { get; set; }
    public int? Usid { get; set; }
    public bool? RequlatorFeesIsVatable { get; set; }
    public int? IdPortfolioCustodian { get; set; }
    public string? SensitivityLevel { get; set; }
    public decimal? Navchange { get; set; }
    public decimal? UnitPriceChage { get; set; }
    public decimal? FirstMinPurchase { get; set; }
    public decimal? MultiplePurchase { get; set; }
    public string? FundWebsite { get; set; }
    public string? IdInvestmentType { get; set; }
    public bool? TbillMarkToMarket { get; set; }
    public bool? PublishOnline { get; set; }
    public bool? RetailProduct { get; set; }
    public string? PayStackAccountCode { get; set; }

    public virtual ICollection<PortfolioAccount> PortfolioAccounts { get; set; }
    public virtual ICollection<PortfolioManagementFee> PortfolioManagementFees { get; set; }
    public virtual ICollection<PortfolioOtherFeesMaster> PortfolioOtherFeesMasters { get; set; }
    public virtual ICollection<PortfolioUnitHistory> PortfolioUnitHistories { get; set; }
    public virtual ICollection<PortfolioValuationHistory> PortfolioValuationHistories { get; set; }
    public virtual ICollection<ValuationHistory> ValuationHistories { get; set; }
}
