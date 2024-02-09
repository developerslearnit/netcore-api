namespace IbsRestApi.Entities.iMoneytor;

public partial class NetBondValueAiicoNew
{
    public int LoanId { get; set; }
    public string? Symbol { get; set; }
    public decimal? NorminalCost { get; set; }
    public int? LoanTypeId { get; set; }
    public string? InvestType { get; set; }
    public decimal? Qtyunit { get; set; }
    public decimal? Consideration { get; set; }
    public decimal? IssueRate { get; set; }
    public decimal? AssetValue { get; set; }
    public decimal? Interest2Date { get; set; }
    public DateTime? ValuationDate { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal CostPrice { get; set; }
    public decimal PrnCostSold { get; set; }
    public decimal TotalCost { get; set; }
    public decimal? FaceValue { get; set; }
}
