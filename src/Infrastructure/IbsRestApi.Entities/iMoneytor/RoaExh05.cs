namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaExh05
{
    public int RoaExh05Id { get; set; }
    public DateTime? EndDate { get; set; }
    public string? MaturityDate { get; set; }
    public int? PortfolioId { get; set; }
    public string? Investment { get; set; }
    public decimal? Amount { get; set; }
    public decimal? MarketValue { get; set; }
    public decimal? InterestRate { get; set; }
    public decimal? ActIncome { get; set; }
    public decimal? CummIncome { get; set; }
    public int? LoanTypeId { get; set; }
    public string? ExhibitId { get; set; }
    
}
