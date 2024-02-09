namespace IbsRestApi.Entities.iMoneytor;

public partial class MoneyMarketExposureDetail
{
    public int IdMoneyMarketExposureDetails { get; set; }
    public int? IdMoneyMarketExposureMaster { get; set; }
    public int? IdCustomer { get; set; }
    public string? RiskRating { get; set; }
    public decimal? CustomerLimit { get; set; }
    public decimal? CustomerExposure { get; set; }
    public decimal? MoneyMarketLimit { get; set; }
    public decimal? MoneyMarketExposure { get; set; }
    public decimal? InvestibleAmount { get; set; }
    public string? Remarks { get; set; }
    public decimal? Int30Days { get; set; }
    public decimal? Int60Days { get; set; }
    public decimal? Int90Days { get; set; }
    public bool? ApplyWithTax { get; set; }
    public string? InterestMode { get; set; }
    public bool? InterestPaidUpfront { get; set; }
    public bool? CapitaliseUpfrontInterest { get; set; }
    public bool? ManualOverride { get; set; }
    public int? IdComplianceOverrideDetails { get; set; }
    public int? Ranking { get; set; }
    public int? NoOfDays { get; set; }
    public decimal? IntRate { get; set; }
    public decimal? Int180Days { get; set; }
    public decimal? Int15Days { get; set; }
    public decimal? DealAmount { get; set; }
    public decimal? UnUtilisedAmount { get; set; }
    public bool? Converted2Yield { get; set; }
    public string? IdDealType { get; set; }
    public decimal? Int15DaysYield { get; set; }
    public decimal? Int30DaysYield { get; set; }
    public decimal? Int60DaysYield { get; set; }
    public decimal? Int90DaysYield { get; set; }
    public decimal? Int180DaysYield { get; set; }
    public decimal? Int180aDays { get; set; }
    public decimal? Int180aDaysYield { get; set; }
    public decimal? Int180bDays { get; set; }
    public decimal? Int180bDaysYield { get; set; }
    public decimal? Int180cDays { get; set; }
    public decimal? Int180cDaysYield { get; set; }
    public decimal? Int180dDays { get; set; }
    public decimal? Int180dDaysYield { get; set; }
    public decimal? Int180eDays { get; set; }
    public decimal? Int180eDaysYield { get; set; }
    
    public int? IdSettlementModes { get; set; }
    public int? IdCustomerBranch { get; set; }
    public decimal? FaceValue { get; set; }
}
