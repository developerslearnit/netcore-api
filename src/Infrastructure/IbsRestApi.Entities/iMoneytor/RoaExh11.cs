namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaExh11
{
    public int RoaExh11Id { get; set; }
    public DateTime? EndDate { get; set; }
    public int? PortfolioId { get; set; }
    public string? Investment { get; set; }
    public string? ShareType { get; set; }
    public string? Issue { get; set; }
    public int? NoOfShares { get; set; }
    public decimal? AverageCost { get; set; }
    public decimal? TotalCost { get; set; }
    public decimal? MarketPrice { get; set; }
    public decimal? MarketValue { get; set; }
    public decimal? DivDeclared { get; set; }
    public decimal? Dividend { get; set; }
    public string? ExhibitId { get; set; }
    public decimal? ProfLoss { get; set; }
    
}
