namespace IbsRestApi.Entities.Secure;

public partial class SecurityGroup
{
    public SecurityGroup()
    {
        SecurityGroupAccesses = new HashSet<SecurityGroupAccess>();
        SecurityGroupMembers = new HashSet<SecurityGroupMember>();
    }

    public int IdSecurityGroup { get; set; }
    public string? IdApplication { get; set; }
    public string? GroupName { get; set; }
    public DateTime? CreateDate { get; set; }
    public DateTime? ExpireDate { get; set; }
    public string? Notes { get; set; }

    public virtual ICollection<SecurityGroupAccess> SecurityGroupAccesses { get; set; }
    public virtual ICollection<SecurityGroupMember> SecurityGroupMembers { get; set; }
}
