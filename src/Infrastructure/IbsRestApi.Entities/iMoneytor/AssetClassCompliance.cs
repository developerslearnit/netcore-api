namespace IbsRestApi.Entities.iMoneytor;

public partial class AssetClassCompliance
{
    public int IdAssetClassCompliance { get; set; }
    public string? IdVariableAssetClass { get; set; }
    public decimal? TargetInvPercent { get; set; }
    public decimal? MaxInvPercent { get; set; }
    public decimal? MinInvPercent { get; set; }
    public int? IdAssetClassComplianceMaster { get; set; }
    public string? IdInvestmentType { get; set; }
}
