namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaExh14
{
    public int RoaExh14Id { get; set; }
    public DateTime? EndDate { get; set; }
    public int? PortfolioId { get; set; }
    public string? Investment { get; set; }
    public decimal? Amount { get; set; }
    public decimal? Nbv { get; set; }
    public decimal? PeriodRental { get; set; }
    public decimal? AnnualRental { get; set; }
    public string? ExhibitId { get; set; }
    
}
