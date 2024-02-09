namespace IbsRestApi.Entities.iMoneytor;

public partial class DealType
{
    public string IdDealType { get; set; } = null!;
    public string? DealType1 { get; set; }
    public string? CalculationMethod { get; set; }
    public string? DealMainActNo { get; set; }
    public string? DealIncomeActNo { get; set; }
    public string? DealAccrualActNo { get; set; }
    public string? IdInvestmentType { get; set; }
    public string? PencomCode { get; set; }
    public bool? TreatAsCall { get; set; }
    public string? DbBorrowingName { get; set; }
    public string? IdCashForeCastClass { get; set; }
    public string? IdOutCashForeCastClass { get; set; }
    
    public int? Upid { get; set; }
    public bool? TreatAsTreasuryBill { get; set; }
    public int? IdSettlementModes { get; set; }
    public bool? TreatAsCommercialPaper { get; set; }
    public bool? InterestStartTommorrow { get; set; }
}
