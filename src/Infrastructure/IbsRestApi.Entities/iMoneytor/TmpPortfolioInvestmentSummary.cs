namespace IbsRestApi.Entities.iMoneytor;

public partial class TmpPortfolioInvestmentSummary
{
    public int IdPortfolioInvestmentSummary { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? IdInvestmentType { get; set; }
    public decimal? AssetValue { get; set; }
    public decimal? CostOfAsset { get; set; }
    public decimal? PcentGainLoss { get; set; }
    public decimal? PcentOfTotal { get; set; }
}
