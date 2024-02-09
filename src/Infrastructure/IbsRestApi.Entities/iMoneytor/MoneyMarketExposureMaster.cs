namespace IbsRestApi.Entities.iMoneytor;

public partial class MoneyMarketExposureMaster
{
    public int IdMoneyMarketExposureMaster { get; set; }
    public int? IdPortfolioCashForecastMaster { get; set; }
    public string? IdCurrency { get; set; }
    public string? Narration { get; set; }
    public DateTime? ExposureDate { get; set; }
    public decimal? FundAvailable { get; set; }
    public bool? ApplyWithTax { get; set; }
    public string? InterestMode { get; set; }
    public bool? InterestPaidUpfront { get; set; }
    public bool? CapitaliseUpfrontInterest { get; set; }
    public string? PrepairedBy { get; set; }
    public string? ReviewedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public decimal? Fund4MoneyMarket { get; set; }
    public int? IdPortfolio { get; set; }
    public bool? ManualOverRide { get; set; }
    public int? IdComplianceOverRideMaster { get; set; }
    public string? IdInvestmentType { get; set; }
    public DateTime? ValuationDateUsed { get; set; }
    public string? IdDealType { get; set; }
    
    public decimal? Fund4Others { get; set; }
}
