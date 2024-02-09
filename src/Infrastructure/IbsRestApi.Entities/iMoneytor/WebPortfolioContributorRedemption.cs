namespace IbsRestApi.Entities.iMoneytor;

public partial class WebPortfolioContributorRedemption
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
}
