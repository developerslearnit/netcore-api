namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaMoneyMarketResult
{
    public int IdMoneyMarketResult { get; set; }
    public int? IdPortfolio { get; set; }
    public int? IdRoasummary { get; set; }
    public int? IdDealMaster { get; set; }
    public decimal? Principal { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? InterestRate { get; set; }
    public decimal? TotalInterest { get; set; }
    public int? Tenor { get; set; }
    public string? Status { get; set; }
    public int? NoOfDays { get; set; }
    public decimal? WeightedAverage { get; set; }
    public decimal? WeightReturns { get; set; }
    public DateTime? EndDate { get; set; }
    
}
