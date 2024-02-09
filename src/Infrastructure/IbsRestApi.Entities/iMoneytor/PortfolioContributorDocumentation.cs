namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributorDocumentation
{
    public int IdPortfolioContributorDocumentation { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public int? IdDocumentMaster { get; set; }
    public bool? Submited { get; set; }
    public DateTime? SubmitionDate { get; set; }
    public string? Capturedby { get; set; }
}
