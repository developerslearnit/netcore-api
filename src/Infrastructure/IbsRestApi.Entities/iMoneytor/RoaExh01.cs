namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaExh01
{
    public int RoaExh01Id { get; set; }
    public DateTime? EndDate { get; set; }
    public int? PortfolioId { get; set; }
    public string? Investment { get; set; }
    public decimal? Amount { get; set; }
    public decimal? InterestRate { get; set; }
    public decimal? ActIncome { get; set; }
    public decimal? BankCharges { get; set; }
    public decimal? CummIncome { get; set; }
    public string? Remarks { get; set; }
    public string? ExhibitId { get; set; }
    
}
