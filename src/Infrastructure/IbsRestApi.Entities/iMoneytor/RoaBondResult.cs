namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaBondResult
{
    public int IdBondResult { get; set; }
    public int? IdRoasummary { get; set; }
    public int? IdPortfolio { get; set; }
    public int? LoanId { get; set; }
    public decimal? Principal { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? InterestRate { get; set; }
    public decimal? ProfitLoss { get; set; }
    public int? Tenor { get; set; }
    public string? Status { get; set; }
    public int? NoOfDays { get; set; }
    public decimal? WeightedAverage { get; set; }
    public decimal? WeightReturns { get; set; }
    public DateTime? EndDate { get; set; }
    
}
