namespace IbsRestApi.Entities.IbsMdm;

public partial class AuditTrail
{
    public long IdLogTrail { get; set; }
    public string IdApplication { get; set; } = null!;
    public string ApplicationUser { get; set; } = null!;
    public DateTime ActionDate { get; set; }
    public string Ipaddress { get; set; } = null!;
    public string Action { get; set; } = null!;
    public string InitialValue { get; set; } = null!;
    public string CurrentValue { get; set; } = null!;
    public string FormName { get; set; } = null!;
    public string Url { get; set; } = null!;
}
