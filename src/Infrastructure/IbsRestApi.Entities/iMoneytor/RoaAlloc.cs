namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaAlloc
{
    public int RoaAllocId { get; set; }
    public DateTime? EndDate { get; set; }
    public int? PortfolioId { get; set; }
    public string? ExhibitId { get; set; }
    public decimal? TargetAmount { get; set; }
    public decimal? ActualAmount { get; set; }
    
}
