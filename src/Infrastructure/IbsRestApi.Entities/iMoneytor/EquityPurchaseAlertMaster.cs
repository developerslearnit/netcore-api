namespace IbsRestApi.Entities.iMoneytor;

public partial class EquityPurchaseAlertMaster
{
    public int IdEquityPurchaseAlertMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public int? ShareId { get; set; }
    public string? Narration { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? AlertPrice { get; set; }
    public DateTime? AlertDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    
}
