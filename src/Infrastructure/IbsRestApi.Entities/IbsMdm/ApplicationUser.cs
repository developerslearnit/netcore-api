namespace IbsRestApi.Entities.IbsMdm;

public partial class ApplicationUser
{
    public int IdUser { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PasswordSalt { get; set; } = null!;
    public bool? IsActive { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public bool OnlineStatus { get; set; }
    public DateTime? LastDeactivatedDate { get; set; }
    public DateTime? LastReactivatedDate { get; set; }
    public DateTime? LastPasswordResetDate { get; set; }
    public string Email { get; set; } = null!;
    public Guid UniqueId { get; set; }
    public DateTime? NextPasswordChangeDate { get; set; }
    public int FailedPasswordTries { get; set; }
}
