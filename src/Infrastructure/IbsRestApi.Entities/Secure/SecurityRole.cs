namespace IbsRestApi.Entities.Secure;

public partial class SecurityRole
{
    public int SecurityRoleId { get; set; }
    public string? RoleName { get; set; }
    public int? AccessLevel { get; set; }
}
