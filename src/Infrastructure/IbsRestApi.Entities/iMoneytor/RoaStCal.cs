namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaStCal
{
    public int RoaStraCalcId { get; set; }
    public DateTime? EndDate { get; set; }
    public int? PortfolioId { get; set; }
    public string Title { get; set; } = null!;
    public decimal? Amount { get; set; }
    public decimal? TotalAmount { get; set; }
    public string? ExhibitId { get; set; }
    public string? Remarks { get; set; }
    
}
