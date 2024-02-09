namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaExh09
{
    public int RoaExh09Id { get; set; }
    public DateTime? EndDate { get; set; }
    public int? PortfolioId { get; set; }
    public string? Investment { get; set; }
    public decimal? Amount { get; set; }
    public decimal? Balance { get; set; }
    public decimal? InterestRate { get; set; }
    public decimal? ActIncome { get; set; }
    public decimal? CummIncome { get; set; }
    public string? MortgageTypeId { get; set; }
    public string? ExhibitId { get; set; }
    
}
