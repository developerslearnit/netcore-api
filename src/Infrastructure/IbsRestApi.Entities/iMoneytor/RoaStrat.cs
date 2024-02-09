namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaStrat
{
    public int RoaStratId { get; set; }
    public int? PortfolioId { get; set; }
    public string StratLinkCode { get; set; } = null!;
    public string Title { get; set; } = null!;
    public decimal? StrategyRate { get; set; }
    public string? CompareType { get; set; }
    public string OkRemarks { get; set; } = null!;
    public string BadRemarks { get; set; } = null!;
    public string? ExhibitId { get; set; }
    
}
