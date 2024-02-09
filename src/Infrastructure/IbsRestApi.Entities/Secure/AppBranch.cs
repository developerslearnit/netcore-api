namespace IbsRestApi.Entities.Secure;

public partial class AppBranch
{
    public Guid IdBranches { get; set; }
    public string? BranchName { get; set; }
    public string? ServerName { get; set; }
    public string? DatabaseName { get; set; }
    public string? DbUsername { get; set; }
    public string? DbPassword { get; set; }
    public string? IdApplication { get; set; }
    public string? MoneyBookDatabase { get; set; }
    public bool? OnlineAccess { get; set; }
    public string? BranchCode { get; set; }
    public int Dbid { get; set; }
    public string? GrpLifeDbName { get; set; }
    public string? MultiPlanDbName { get; set; }
    public string? TakaFulDbName { get; set; }
    public string? Sensitivity { get; set; }
}
