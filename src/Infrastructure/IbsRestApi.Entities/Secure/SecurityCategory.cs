namespace IbsRestApi.Entities.Secure;

public partial class SecurityCategory
{
    public int SecurityCategoryId { get; set; }
    public int? WebUserId { get; set; }
    public string? Category { get; set; }
    public int? AccessLevel { get; set; }
    public int? SecurityRoleId { get; set; }
    public string? IdApplication { get; set; }
}
