namespace IbsRestApi.Entities.iMoneytor;

public partial class ShareMandateDetail
{
    public int IdShareMandateDetail { get; set; }
    public int? ShareId { get; set; }
    public decimal? MaxPrice { get; set; }
    public decimal? Qty { get; set; }
    public decimal? QtyReceived { get; set; }
    public string? Cscsid { get; set; }
    public string? InvestorAccountNo { get; set; }
    public decimal? Consideration { get; set; }
    public decimal? StampDuty { get; set; }
    public decimal? Commission { get; set; }
    public decimal? Vat { get; set; }
    public decimal? SecFees { get; set; }
    public decimal? NseCscsfees { get; set; }
    public decimal? OtherFees { get; set; }
    public decimal? Premuim { get; set; }
    public decimal? Discount { get; set; }
    public decimal? TransactionCost { get; set; }
    public decimal? TotalCost { get; set; }
    public string? BrokerId { get; set; }
    public decimal? ActualCost { get; set; }
    public string? TransactionType { get; set; }
    public DateTime? CaptureDate { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public int? DeliveryDays { get; set; }
    public DateTime? MandateDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public bool? FreePrice { get; set; }
    public string? Remarks { get; set; }
    public int? IdPortfolioGroup { get; set; }
    public decimal? ComRate { get; set; }
    public int? IdSellTriger { get; set; }
    public int? IdEquityMandateDetails { get; set; }
    public int? IdEquityMandateToBrokers { get; set; }
    public int? IdComplianceOverrideDetails { get; set; }
    
    public bool? OverrideCharges { get; set; }
    public int? IdPortfolioCustodian { get; set; }
}
