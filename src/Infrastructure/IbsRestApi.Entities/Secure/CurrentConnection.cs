namespace IbsRestApi.Entities.Secure;

public partial class CurrentConnection
{
    public int CurrentConnectionId { get; set; }
    public string? SessionId { get; set; }
    public string? UserType { get; set; }
    public int? WebUserId { get; set; }
    public string? UserName { get; set; }
    public string? Ipaddress { get; set; }
    public string? BrowserType { get; set; }
    public string? BrowserVersion { get; set; }
    public string? BrowserPlatform { get; set; }
    public string? CurrentPage { get; set; }
    public DateTime? SessionBegan { get; set; }
    public DateTime? LastActivity { get; set; }
    public DateTime? SessionEnd { get; set; }
}
