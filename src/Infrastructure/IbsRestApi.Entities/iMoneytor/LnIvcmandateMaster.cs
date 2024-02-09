namespace IbsRestApi.Entities.iMoneytor;

public partial class LnIvcmandateMaster
{
    public int IdIvcmasterMandate { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? ExpireDate { get; set; }
    public string? Narration { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? MandateType { get; set; }
    
}
