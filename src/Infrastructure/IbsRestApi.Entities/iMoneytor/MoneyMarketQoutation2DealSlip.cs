namespace IbsRestApi.Entities.iMoneytor;

public partial class MoneyMarketQoutation2DealSlip
{
    public int IdMoneyMarketQoutation2DealSlip { get; set; }
    public int? IdMoneyMarketExposureMaster { get; set; }
    public int? IdCustomer { get; set; }
    public decimal? InvestibleAmount { get; set; }
    public string? Remarks { get; set; }
    public bool? Convert2Deal { get; set; }
    public int? IdDealMaster { get; set; }
    public bool? ApplyWithTax { get; set; }
    public string? InterestMode { get; set; }
    public bool? InterestPaidUpfront { get; set; }
    public bool? CapitaliseUpfrontInterest { get; set; }
    public int? NoOfDays { get; set; }
    public decimal? IntRate { get; set; }
    public int? IdMoneyMarketExposureDetails { get; set; }
    public decimal? EffectiveYield { get; set; }
    public decimal? InterestAmount { get; set; }
    public decimal? DealAmount { get; set; }
    public string? BrokerId { get; set; }
    public string? IdDealType { get; set; }
    public DateTime? BookingDate { get; set; }
    public int? IdCustomerBranch { get; set; }
    public int? IdTransMarket { get; set; }
    
    public int? RollOverFromDealId { get; set; }
    public string? RollOverType { get; set; }
    public decimal? Amt2Withdraw { get; set; }
    public decimal? Amt2Add { get; set; }
    public decimal? FaceValue { get; set; }
    public string? CompoundIntType { get; set; }
    public decimal? WithholdTaxAmount { get; set; }
    public int? IdSettlementModes { get; set; }
    public decimal? Wam { get; set; }
    public decimal? BestFaceValue { get; set; }
    public decimal? ManagementFeesRate { get; set; }
    public string? IdTbillTreatmentType { get; set; }
    public int? IdPortfolioCustodian { get; set; }
    public string? IdBankAccount { get; set; }
    public decimal? ExRate { get; set; }
}
