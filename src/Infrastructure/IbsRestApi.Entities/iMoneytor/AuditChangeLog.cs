namespace IbsRestApi.Entities.iMoneytor;

public partial class AuditChangeLog
{
    public long AuditLogId { get; set; }
    public string EntityName { get; set; } = null!;
    public string PropertyName { get; set; } = null!;
    public string PrimaryKeyValue { get; set; } = null!;
    public string OldValue { get; set; } = null!;
    public string NewValue { get; set; } = null!;
    public string ActionPerformed { get; set; } = null!;
    public string ActionFullDescription { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string? RemoteIpaddress { get; set; }
    public DateTime? AuditDate { get; set; }
    public string? IdApplication { get; set; }
}
