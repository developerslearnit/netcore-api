namespace IbsRestApi.Entities.iMoneytor;

public partial class EquityResult
{
    public int IdEquityResult { get; set; }
    public string? TransId { get; set; }
    public int? ShareId { get; set; }
    public decimal? Nominal { get; set; }
    public decimal? NetAmountCost { get; set; }
    public DateTime? ValueDate { get; set; }
    public int? Bonus { get; set; }
    public decimal? QtySold { get; set; }
    public decimal? TotalQty { get; set; }
    public decimal? CurrentPrice { get; set; }
    public decimal? MarketValue { get; set; }
    public decimal? SalesProceed { get; set; }
    public decimal? Dividend { get; set; }
    public decimal? TotalValue { get; set; }
    public decimal? Gain { get; set; }
    public decimal? FlatDiff { get; set; }
    public int? NoOfDays { get; set; }
    public decimal? WeightedAverage { get; set; }
    public decimal? WeightReturns { get; set; }
    public DateTime? EndDate { get; set; }
    public int? SalesId { get; set; }
}
