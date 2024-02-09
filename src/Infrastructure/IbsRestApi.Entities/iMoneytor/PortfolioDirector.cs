namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioDirector
{
    public int IdPortfolioDirectors { get; set; }
    public int? IdPortfolio { get; set; }
    public string? Title { get; set; }
    public string? LastName { get; set; }
    public string? OtherNames { get; set; }
    public DateTime? DateOfBirth { get; set; }
}
