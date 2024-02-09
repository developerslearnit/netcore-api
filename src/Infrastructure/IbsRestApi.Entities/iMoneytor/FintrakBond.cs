namespace IbsRestApi.Entities.iMoneytor;

public partial class FintrakBond
{
    public int? IdPortfolio { get; set; }
    public decimal? Interest2Date { get; set; }
    public decimal? CostOfAsset { get; set; }
    public decimal? AssetValue { get; set; }
    public int? Id2link { get; set; }
    public string? Symbol { get; set; }
    public DateTime? EndDate { get; set; }
    public string? IdTreatmentType { get; set; }
    public decimal? CleanAmount { get; set; }
    public decimal? CostPrice { get; set; }
    public decimal? FixedInterestRate { get; set; }
    public DateTime? IntStartDate { get; set; }
    public DateTime? IntEndDate { get; set; }
    public decimal? NorminalCost { get; set; }
    public decimal? Premdiscount { get; set; }
    public decimal? Interestaccured { get; set; }
    public int LoanId { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? Marketvalue { get; set; }
    public decimal? DailywriteoffIn { get; set; }
    public string? Narration { get; set; }
    public DateTime? ExpectedDate { get; set; }
    public DateTime? EffectiveDate { get; set; }
}
