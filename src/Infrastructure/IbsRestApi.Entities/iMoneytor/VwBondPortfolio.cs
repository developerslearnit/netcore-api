namespace IbsRestApi.Entities.iMoneytor;

public partial class VwBondPortfolio
{
    public int? PortfolioId { get; set; }
    public string? BondType { get; set; }
    public string? Symbol { get; set; }
    public decimal? QtyUnit { get; set; }
    public decimal? QtySold { get; set; }
    public decimal? QtyBalance { get; set; }
}
