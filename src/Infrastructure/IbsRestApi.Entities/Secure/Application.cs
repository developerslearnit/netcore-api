namespace IbsRestApi.Entities.Secure;

public partial class Application
{
    public int IdApplication { get; set; }
    public string ApplicationCode { get; set; } = null!;
    public string ApplicationName { get; set; } = null!;
    public string ApplicationUri { get; set; } = null!;
}
