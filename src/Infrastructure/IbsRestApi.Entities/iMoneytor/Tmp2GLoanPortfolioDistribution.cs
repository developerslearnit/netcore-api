namespace IbsRestApi.Entities.iMoneytor;

public partial class Tmp2GLoanPortfolioDistribution
{
    public int Id { get; set; }
    public int? PortfolioId { get; set; }
    public string? BondType { get; set; }
    public string? Symbol { get; set; }
    public decimal? QtyBalance { get; set; }
    public decimal? NorminalValue { get; set; }
}
