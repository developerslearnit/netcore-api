namespace IbsRestApi.Entities.iMoneytor;

public partial class BondAmortStraightLine
{
    public int? IdPortfolio { get; set; }
    public decimal? AssetValue { get; set; }
    public int? Id2link { get; set; }
    public string? Symbol { get; set; }
    public decimal? NorminalCost { get; set; }
    public decimal? Interest2Date { get; set; }
    public decimal? Premdiscount { get; set; }
    public string? IdTreatmentType { get; set; }
    public int LoanId { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? DailywriteoffIn { get; set; }
    public DateTime? EndDate { get; set; }
    public int? DaysToMat { get; set; }
    public int? DaysInVal { get; set; }
    public decimal? Amortised { get; set; }
    public decimal? Unamortised { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public decimal? CleanAmount { get; set; }
    public decimal? CostPrice { get; set; }
    public decimal? FixedInterestRate { get; set; }
    public string? IdInvestmentType { get; set; }
}
