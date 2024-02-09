namespace IbsRestApi.Entities.iMoneytor;

public partial class CorporateClientSignatory
{
    public int IdCorporateClientSignatory { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public string? FullName { get; set; }
    public string? Designation { get; set; }
    public string? MobileNo { get; set; }
    public string? Email { get; set; }
    public string? Bvn { get; set; }
}
