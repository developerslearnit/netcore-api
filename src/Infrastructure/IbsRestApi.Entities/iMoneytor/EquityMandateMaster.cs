namespace IbsRestApi.Entities.iMoneytor;

public partial class EquityMandateMaster
{
    public int IdEquityMandateMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? CaptureDate { get; set; }
    public string? Narration { get; set; }
    public string? CapturedBy { get; set; }
    public string? ReviewedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public decimal? AmountToInvest { get; set; }
    public DateTime? ExpireDate { get; set; }
    public decimal? QtyUnitsToSell { get; set; }
    public string? TransactionType { get; set; }
    public string? MarketType { get; set; }
    
}
