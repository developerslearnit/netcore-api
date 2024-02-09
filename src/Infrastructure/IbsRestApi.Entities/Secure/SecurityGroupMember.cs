namespace IbsRestApi.Entities.Secure;

public partial class SecurityGroupMember
{
    public int IdGroupMenber { get; set; }
    public string? IdApplication { get; set; }
    public int? IdSecurityGroup { get; set; }
    public int? WebUserId { get; set; }

    public virtual SecurityGroup? IdSecurityGroupNavigation { get; set; }
    public virtual WebUser? WebUser { get; set; }
}
