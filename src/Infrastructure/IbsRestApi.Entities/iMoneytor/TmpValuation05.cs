namespace IbsRestApi.Entities.iMoneytor;

public partial class TmpValuation05
{
    public int IdTmpValuation05 { get; set; }
    public string? Description { get; set; }
    public DateTime? ValueDate { get; set; }
    public int? IdBenchMark { get; set; }
    public decimal? BenchRate { get; set; }
    public decimal? PortfolioRate { get; set; }
    public short? FontAttribute { get; set; }
    public int? PortfolioId { get; set; }
    public string? RepType { get; set; }
}
