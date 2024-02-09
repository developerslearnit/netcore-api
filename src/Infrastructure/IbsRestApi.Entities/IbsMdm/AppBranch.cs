namespace IbsRestApi.Entities.IbsMdm;

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
}
