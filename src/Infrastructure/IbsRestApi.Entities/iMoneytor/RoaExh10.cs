namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaExh10
{
    public int RoaExh10Id { get; set; }
    public DateTime? EndDate { get; set; }
    public int? PortfolioId { get; set; }
    public string? Investment { get; set; }
    public decimal? Amount { get; set; }
    public decimal? Balance { get; set; }
    public decimal? InterestRate { get; set; }
    public decimal? ActIncome { get; set; }
    public decimal? CummIncome { get; set; }
    public int? LeaseTypeId { get; set; }
    public string? ExhibitId { get; set; }
    
}
