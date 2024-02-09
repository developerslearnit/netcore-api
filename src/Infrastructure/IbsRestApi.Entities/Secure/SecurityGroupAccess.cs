namespace IbsRestApi.Entities.Secure;

public partial class SecurityGroupAccess
{
    public int IdSecurityGroupAccess { get; set; }
    public int? IdSecurityGroup { get; set; }
    public int? SecurityDetailId { get; set; }
    public int? AccessLevel { get; set; }
    public string? IdApplication { get; set; }

    public virtual SecurityGroup? IdSecurityGroupNavigation { get; set; }
}
