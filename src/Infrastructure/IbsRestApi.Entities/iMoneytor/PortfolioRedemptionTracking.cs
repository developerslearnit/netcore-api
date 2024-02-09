namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioRedemptionTracking
{
    public int IdPortfolioRedemptionTracking { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public int? IdPortfolioContributorAccount { get; set; }
    public DateTime? CaptureDate { get; set; }
    public DateTime? Send2RegistraDate { get; set; }
    public DateTime? ReceivedFromRegistraDate { get; set; }
    public string? ResponseCode { get; set; }
    public DateTime? SendForPaymentDate { get; set; }
    public string? Status { get; set; }
    
}
