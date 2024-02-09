namespace IbsRestApi.Entities.Secure;

public partial class PasswordResetRequest
{
    public long RequestId { get; set; }
    public string Token { get; set; } = null!;
    public DateTime ExpiryDate { get; set; }
    public string Email { get; set; } = null!;
    public bool IsUsed { get; set; }
}
