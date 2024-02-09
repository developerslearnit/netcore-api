namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioClosure
{
    public int IdPortfolioClosure { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? CaptureDate { get; set; }
    public DateTime? ClosureDate { get; set; }
    public string? Reason { get; set; }
    public decimal? PenaltyAmount { get; set; }
    public string? Status { get; set; }
    public string? Commets { get; set; }
    public decimal? NetAssetValue { get; set; }
    public decimal? Amount2Deduct { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    
}
