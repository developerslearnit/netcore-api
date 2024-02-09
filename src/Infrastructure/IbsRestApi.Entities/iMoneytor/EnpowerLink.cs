namespace IbsRestApi.Entities.iMoneytor;

public partial class EnpowerLink
{
    public int IdEnpowerLink { get; set; }
    public string? SqlServerName { get; set; }
    public string? EnpowerDbName { get; set; }
    public string? UnitPriceTable { get; set; }
    public string? GlexportTable { get; set; }
    public string? ContributionTable { get; set; }
    public string? NavisionTable { get; set; }
    public bool? DoNotExportToExternalGl { get; set; }
}
