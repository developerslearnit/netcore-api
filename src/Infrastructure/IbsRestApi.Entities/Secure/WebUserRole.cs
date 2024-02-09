namespace IbsRestApi.Entities.Secure;

public partial class WebUserRole
{
    public int WebUserRoleId { get; set; }
    public int? WebUserId { get; set; }
    public int? SecurityRoleId { get; set; }
}
