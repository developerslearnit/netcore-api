namespace IbsRestApi.Entities.Secure;

public partial class Otprepository
{
    public Guid RequestId { get; set; }
    public string Code { get; set; } = null!;
    public string AccountCode { get; set; } = null!;
    public DateTime ExpiryDate { get; set; }
    public bool Used { get; set; }
    public string Email { get; set; } = null!;
}
