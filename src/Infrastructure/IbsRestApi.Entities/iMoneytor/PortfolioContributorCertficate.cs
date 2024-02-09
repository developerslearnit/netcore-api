namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributorCertficate
{
    public int IdPortfolioContributorCertificate { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public int? ShareId { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal? QtyUnit { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public int? UniqueId { get; set; }
    
}
