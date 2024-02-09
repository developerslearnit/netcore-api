namespace IbsRestApi.Entities.iMoneytor;

public partial class MoneyMarketResult
{
    public int IdMoneyMarketResult { get; set; }
    public int? IdMoneyMarketBerawData { get; set; }
    public string? TransId { get; set; }
    public string? Customerid { get; set; }
    public string? Ourremarks { get; set; }
    public string? Mmbenbank { get; set; }
    public decimal? Principal { get; set; }
    public DateTime? Dealdate { get; set; }
    public DateTime? Valuedate { get; set; }
    public DateTime? Maturitydate { get; set; }
    public decimal? Interestrate { get; set; }
    public decimal? Totinterestamt { get; set; }
    public int? Tenor { get; set; }
    public string? Status { get; set; }
    public int? NoOfDays { get; set; }
    public decimal? WeightedAverage { get; set; }
    public decimal? WeightReturns { get; set; }
    public DateTime? EndDate { get; set; }
}
