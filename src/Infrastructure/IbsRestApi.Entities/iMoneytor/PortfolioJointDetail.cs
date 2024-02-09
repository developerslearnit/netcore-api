namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioJointDetail
{
    public int IdPortfolioJointDetails { get; set; }
    public int? IdPortfolio { get; set; }
    public string? FullName { get; set; }
    public string? Sex { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? GsmNo { get; set; }
    public string? Email { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? IdState { get; set; }
    public bool? CopyMeEmail { get; set; }
    
}
