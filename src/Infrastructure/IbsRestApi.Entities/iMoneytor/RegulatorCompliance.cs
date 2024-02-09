namespace IbsRestApi.Entities.iMoneytor;

public partial class RegulatorCompliance
{
    public int IdRegulatorCompliance { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal? RegulatoryMax { get; set; }
    public decimal? MaxPerIssuer { get; set; }
    public string? InvestmentClass { get; set; }
    public decimal? MaxPerIssue { get; set; }
    public string? IssuerBasedOn { get; set; }
    public string? IssueBasedOn { get; set; }
    public string? Arrangement { get; set; }
    public string? IdVariableAssetClass { get; set; }
}
