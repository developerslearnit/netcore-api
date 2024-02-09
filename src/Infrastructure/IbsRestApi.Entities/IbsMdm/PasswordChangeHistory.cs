namespace IbsRestApi.Entities.IbsMdm;

public partial class PasswordChangeHistory
{
    public long IdPasswordChangeHistory { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime ChangeDate { get; set; }
}
