namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioInterestMaster
{
    public int IdPortfolioInterestMaster { get; set; }
    public DateTime? CaptureDate { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? Narration { get; set; }
    public decimal? InterestAmount { get; set; }
    public string? CaptureBy { get; set; }
    public string? ApprovedBy { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? BulkAccountNo { get; set; }
    public string? PortfolioAccountNo { get; set; }
    public string? VoucherNo { get; set; }
    
}
