namespace IbsRestApi.Entities.iMoneytor;

public partial class NetBondValueAiico
{
    public int Loanid { get; set; }
    public string? Title { get; set; }
    public string? Symbol { get; set; }
    public decimal? FixedInterestRate { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? FaceValue { get; set; }
    public decimal? PrnCostSold { get; set; }
    public decimal? NorminalCost { get; set; }
    public decimal? Amount { get; set; }
    public decimal? CleanAmount { get; set; }
    public decimal? AssetValue { get; set; }
    public decimal? Interest2Date { get; set; }
    public DateTime? ValuationDate { get; set; }
    public int? IdPortfolio { get; set; }
}
