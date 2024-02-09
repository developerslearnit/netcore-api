namespace IbsRestApi.Entities.IbsMdm;

public partial class OnlineUserAccount
{
    public long IdOnlineUserAccount { get; set; }
    public string AccountCode { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PasswordSalt { get; set; } = null!;
    public int Ucid { get; set; }
    public bool IsActive { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public DateTime? LastDeactivatedDate { get; set; }
    public DateTime? LastPasswordResetDate { get; set; }
    public DateTime? NextPasswordChangeDate { get; set; }
    public int FailedPasswordTries { get; set; }
    public string? Email { get; set; }
    public string LoginPin { get; set; } = null!;
    public byte[]? ProfileImage { get; set; }
    public bool? AcceptTerms { get; set; }
}
