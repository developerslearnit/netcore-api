namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributorLien
{
    public int IdPortfolioContributorLien { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? LienDate { get; set; }
    public string? Narration { get; set; }
    public string? CaptureBy { get; set; }
    public DateTime? CaptureDate { get; set; }
    public bool? Released { get; set; }
    public string? ReleasedBy { get; set; }
    public DateTime? ReleaseDate { get; set; }
    
    public int? Ucid { get; set; }
}
