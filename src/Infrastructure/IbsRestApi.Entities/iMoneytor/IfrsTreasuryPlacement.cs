namespace IbsRestApi.Entities.iMoneytor;

public partial class IfrsTreasuryPlacement
{
    public int RpDpSchdId { get; set; }
    public int DealId { get; set; }
    public int? PortfolioId { get; set; }
    public string? DealTypeId { get; set; }
    public decimal? OpenBalance { get; set; }
    public decimal? Addition { get; set; }
    public decimal? Disposals { get; set; }
    public decimal? BookValue { get; set; }
    public decimal? IntRate { get; set; }
    public decimal? GrossRecd { get; set; }
    public decimal? WithTax { get; set; }
    public decimal? AcrBf { get; set; }
    public decimal? AcrPl { get; set; }
    public decimal? IntAdj { get; set; }
    public decimal? NetPl { get; set; }
    public decimal? AcrCf { get; set; }
    public decimal? Comments { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Description { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public int? NoOfDays { get; set; }
}
