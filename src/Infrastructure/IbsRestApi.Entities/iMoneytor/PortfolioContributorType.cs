namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributorType
{
    public PortfolioContributorType()
    {
        PortfolioContributors = new HashSet<PortfolioContributor>();
    }

    public int IdPortfolioContributorType { get; set; }
    public string? PortfolioContributorType1 { get; set; }
    public decimal? MinDeposit { get; set; }
    public decimal? MaxDeposit { get; set; }
    public decimal? MaxBalance { get; set; }

    public virtual ICollection<PortfolioContributor> PortfolioContributors { get; set; }
}
