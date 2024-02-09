namespace IbsRestApi.Entities.iMoneytor;

public partial class RpLnSchd
{
    public int RpLnSchdId { get; set; }
    public int? LoanId { get; set; }
    public int? PortfolioId { get; set; }
    public int? LoanTypeId { get; set; }
    public decimal? OpenBalance { get; set; }
    public decimal? Addition { get; set; }
    public decimal? Disposals { get; set; }
    public decimal? CloseBalance { get; set; }
    public decimal? IntRate { get; set; }
    public decimal? GrossRecd { get; set; }
    public decimal? WithTax { get; set; }
    public decimal? AcrBf { get; set; }
    public decimal? AcrPl { get; set; }
    public decimal? IntAdj { get; set; }
    public decimal? NetPl { get; set; }
    public decimal? AcrCf { get; set; }
    public decimal? MarketValue { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    
}
