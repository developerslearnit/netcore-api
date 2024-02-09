namespace IbsRestApi.Entities.iMoneytor;

public partial class EqBonRef
{
    public int RefundId { get; set; }
    public int? ShareId { get; set; }
    public string? CertificateNo { get; set; }
    public string? Narration { get; set; }
    public DateTime? RefundDate { get; set; }
    public decimal? QtyRefund { get; set; }
    
}
