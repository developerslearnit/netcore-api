namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributorBeneficiary
{
    public int IdPortfolioContributorBeneficiary { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public string? Beneficiary { get; set; }
    public DateTime? DateOfBirth { get; set; }
}
