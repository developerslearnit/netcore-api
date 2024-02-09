namespace IbsRestApi.Entities.iMoneytor;

public partial class EqRiSal
{
    public int SaleId { get; set; }
    public int? ShareId { get; set; }
    public int? RightId { get; set; }
    public string? Narration { get; set; }
    public DateTime ValueDate { get; set; }
    public decimal? UnitPrice { get; set; }
    public int? QtySold { get; set; }
    public decimal? SalesProceed { get; set; }
    public decimal? Commisions { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? BrokerId { get; set; }
    public DateTime? SettlementDate { get; set; }
    public string? CapturedBy { get; set; }
    public string? ReviewedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedDate { get; set; }
    
}
