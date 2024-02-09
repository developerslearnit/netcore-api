namespace IbsRestApi.Entities.Secure;

public partial class WebUser
{
    public WebUser()
    {
        SecurityGroupMembers = new HashSet<SecurityGroupMember>();
    }

    public int WebUserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? EmailAddress { get; set; }
    public string? MobilePhone { get; set; }
    public string? PassHash { get; set; }
    public int? AccessLevel { get; set; }
    public string? AccountCode { get; set; }
    public string? Password { get; set; }
    public string? PasswordSalt { get; set; }
    public int? Ucid { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public DateTime? LastDeactivatedDate { get; set; }
    public DateTime? LastPasswordResetDate { get; set; }
    public DateTime? NextPasswordChangeDate { get; set; }
    public int? FailedPasswordTries { get; set; }
    public bool? Request4Reset { get; set; }
    public DateTime? Request4ResetDate { get; set; }
    public int? IdUserDepartment { get; set; }
    public byte[]? PassportPhoto { get; set; }
    public bool? OnlineStatus { get; set; }
    public Guid? UniqueId { get; set; }
    public DateTime? LastReactivatedDate { get; set; }
    public bool? UserIsManager { get; set; }
    public string? SensivityLevel { get; set; }
    public DateTime? LogoutDate { get; set; }
    public DateTime? DisableDate { get; set; }
    public bool? Disabled { get; set; }

    public virtual ICollection<SecurityGroupMember> SecurityGroupMembers { get; set; }
}
