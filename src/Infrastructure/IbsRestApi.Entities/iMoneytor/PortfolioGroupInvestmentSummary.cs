namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioGroupInvestmentSummary
{
    public Guid? Id { get; set; }
    public int? IdPortfolioGroup { get; set; }
    public string? IdInvestmentType { get; set; }
    public int? Id2link { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? Qty { get; set; }
    public decimal? AssetValue { get; set; }
    public decimal? CostOfAsset { get; set; }
}
