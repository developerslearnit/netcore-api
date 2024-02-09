namespace IbsRestApi.Entities.Secure;

public partial class ResetRequest
{
    public int ResetRequestId { get; set; }
    public int? WebUserId { get; set; }
    public string? Hash { get; set; }
    public DateTime? RequestDate { get; set; }
}
