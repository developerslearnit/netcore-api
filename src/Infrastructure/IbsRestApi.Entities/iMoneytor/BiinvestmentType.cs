namespace IbsRestApi.Entities.iMoneytor;

public partial class BiinvestmentType
{
    public string IdInvestmentType { get; set; } = null!;
    public string? InvestmentType { get; set; }
    public decimal? RegulatoryMax { get; set; }
    public decimal? MaxPerIssuer { get; set; }
    public string? InvestmentClass { get; set; }
    public decimal? MaxPerIssue { get; set; }
    public string? IssuerBasedOn { get; set; }
    public string? IssueBasedOn { get; set; }
    
    public string? Arrangement { get; set; }
}
