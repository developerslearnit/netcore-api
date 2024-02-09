namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributorDependant
{
    public int IdPortfolioContributorDependant { get; set; }
    public int IdPortfolioContributor { get; set; }
    public string? AccountCode { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get; set; }
    public string? MobileNo { get; set; }
    public string? Email { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? IdState { get; set; }
    public string? IdCountry { get; set; }
    public string? Title { get; set; }
    public string? Gender { get; set; }
    public string? IdIdentifyWith { get; set; }
    public DateTime? DateOpened { get; set; }
}
