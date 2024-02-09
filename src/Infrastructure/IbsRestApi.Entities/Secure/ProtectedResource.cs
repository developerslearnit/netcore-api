namespace IbsRestApi.Entities.Secure;

public partial class ProtectedResource
{
    public int IdProtectedResource { get; set; }
    public string ControllerName { get; set; } = null!;
    public string ActionName { get; set; } = null!;
    public string? AreaName { get; set; }
    public string? IdApplication { get; set; }
}
