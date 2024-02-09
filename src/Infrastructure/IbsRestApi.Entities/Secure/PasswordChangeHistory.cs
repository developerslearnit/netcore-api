namespace IbsRestApi.Entities.Secure;

public partial class PasswordChangeHistory
{
    public long IdPasswordChangeHistory { get; set; }
    public string Username { get; set; } = null!;
    public string? Password { get; set; }
    public DateTime ChangeDate { get; set; }
}
