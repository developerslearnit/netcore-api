namespace IbsRestApi.Entities.iMoneytor;

public partial class LnIvcmandateDetail
{
    public int IdIvcmandateDetails { get; set; }
    public int? IdIvcmasterMandate { get; set; }
    public string? Symbol { get; set; }
    public decimal? QtyRequested { get; set; }
    public decimal? MaxCleanPrice { get; set; }
    public decimal? QtyReceived { get; set; }
    public decimal? TargetYield { get; set; }
    public string? EnforceBy { get; set; }
    
}
