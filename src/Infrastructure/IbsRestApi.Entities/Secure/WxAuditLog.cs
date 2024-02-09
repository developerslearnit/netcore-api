namespace IbsRestApi.Entities.Secure;

public partial class WxAuditLog
{
    public int IdAuditLog { get; set; }
    public string UserId { get; set; } = null!;
    public string? ProcName { get; set; }
    public string? Filename { get; set; }
    public string? Fieldname { get; set; }
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
    public string? ComputerName { get; set; }
    public string? Primafield { get; set; }
    public DateTime? Changetimestamp { get; set; }
    public string? Udf01 { get; set; }
    public string? Udf02 { get; set; }
}
