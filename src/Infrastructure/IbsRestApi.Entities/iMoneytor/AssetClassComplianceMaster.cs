namespace IbsRestApi.Entities.iMoneytor;

public partial class AssetClassComplianceMaster
{
    public int IdAssetClassComplianceMaster { get; set; }
    public DateTime? CaptureDate { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public string? Narration { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public int? IdPortfolio { get; set; }
}
