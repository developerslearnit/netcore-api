namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributorRedemption
{
    public int IdPortfolioContributorRedemption { get; set; }
    public int? IdPorfolioContributor { get; set; }
    public int? IdPortfolioContributorAccount { get; set; }
    public decimal? NoOfUnits { get; set; }
    public decimal? OfferPrice { get; set; }
    public bool? Posted { get; set; }
    public int? IdRedemptionContributorAccount { get; set; }
    public decimal? PenaltyAmount { get; set; }
    public decimal? SalesValue { get; set; }
    public decimal? NetSettlement { get; set; }
    public string? CertificateNo { get; set; }
    public bool? WaivePenalty { get; set; }
    public decimal? CostOfUnits { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal? Tax { get; set; }
    

    public virtual PortfolioContributorAccount? IdPortfolioContributorAccountNavigation { get; set; }
}
