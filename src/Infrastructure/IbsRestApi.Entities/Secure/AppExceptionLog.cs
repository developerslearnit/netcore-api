namespace IbsRestApi.Entities.Secure;

public partial class AppExceptionLog
{
    public long IdErrorLog { get; set; }
    public string? ErrorType { get; set; }
    public string? ErrorSource { get; set; }
    public string ErrorMessage { get; set; } = null!;
    public string LoggedInUser { get; set; } = null!;
    public string? ErrorXml { get; set; }
    public DateTime TimeUtc { get; set; }
    public string? ControllerName { get; set; }
    public string? ActionName { get; set; }
    public string? AreaName { get; set; }
}
