namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributorMandate
{
    public int IdPortfolioContributorMandate { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public string? Description { get; set; }
    public string? PhotoFileName { get; set; }
    public string? SignatureFileName { get; set; }
    
}
