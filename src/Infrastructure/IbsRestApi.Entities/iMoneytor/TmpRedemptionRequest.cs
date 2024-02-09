namespace IbsRestApi.Entities.iMoneytor;

public partial class TmpRedemptionRequest
{
    public int RedemptionRequestId { get; set; }
    public int? PorfolioContributorId { get; set; }
    public decimal? NoOfUnits { get; set; }
    public decimal? OfferPrice { get; set; }
    public bool? Posted { get; set; }
    public int? IdredemptionContributorAccount { get; set; }
    public decimal? PenaltyAmount { get; set; }
    public decimal? SalesValue { get; set; }
    public decimal? NetSettlement { get; set; }
    public string? CertificateNo { get; set; }
    public bool? WaivePenalty { get; set; }
    public decimal? CostOfUnits { get; set; }
    public int? PortfolioId { get; set; }
    public decimal? EmployerAmt { get; set; }
    public decimal? EmployeeAmt { get; set; }
    public decimal? Avcamt { get; set; }
    public decimal? Avcunit { get; set; }
}
