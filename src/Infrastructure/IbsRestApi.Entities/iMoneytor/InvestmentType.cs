namespace IbsRestApi.Entities.iMoneytor;

public partial class InvestmentType
{
    public InvestmentType()
    {
        PortfolioAccounts = new HashSet<PortfolioAccount>();
        ValuationHistories = new HashSet<ValuationHistory>();
    }

    public string IdInvestmentType { get; set; } = null!;
    public string? InvestmentType1 { get; set; }
    public decimal? RegulatoryMax { get; set; }
    public decimal? MaxPerIssuer { get; set; }
    public string? InvestmentClass { get; set; }
    public decimal? MaxPerIssue { get; set; }
    public string? IssuerBasedOn { get; set; }
    public string? IssueBasedOn { get; set; }
    public string? Arrangement { get; set; }
    public bool? DoNotUnitise { get; set; }
    

    public virtual ICollection<PortfolioAccount> PortfolioAccounts { get; set; }
    public virtual ICollection<ValuationHistory> ValuationHistories { get; set; }
}
