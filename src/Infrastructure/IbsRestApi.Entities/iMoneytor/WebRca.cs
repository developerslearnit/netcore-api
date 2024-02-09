namespace IbsRestApi.Entities.iMoneytor;

public partial class WebRca
{
    public int IdPortfolioContributorRedemption { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public int? IdPortfolio { get; set; }
    public int? IdPortfolioContributorAccount { get; set; }
    public decimal? NoOfUnits { get; set; }
    public decimal? OfferPrice { get; set; }
    public bool? Posted { get; set; }
    public int? IdRedemptionContributorAccount { get; set; }
    public decimal? PenaltyAmount { get; set; }
    public decimal? SalesValue { get; set; }
    public decimal? NetSettlement { get; set; }
    public string? CertificateNo { get; set; }
    public string? Status { get; set; }
}
