namespace IbsRestApi.Entities.Secure;

public partial class SecurityAccessGrid
{
    public int IdSecurityAccessGrid { get; set; }
    public int? WebUserId { get; set; }
    public string? IdApplication { get; set; }
    public int? SecurityDetailId { get; set; }
    public int? AccessLevel { get; set; }
    public int? IdSecurityGroup { get; set; }
}
