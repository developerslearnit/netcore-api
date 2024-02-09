namespace IbsRestApi.Entities.Secure;

public partial class AlertNotification
{
    public int IdAlertNotification { get; set; }
    public string? IdOriginAppId { get; set; }
    public string? IdApplication { get; set; }
    public DateTime? AlertDate { get; set; }
    public int? FromWebUserId { get; set; }
    public string? ToWebUsers { get; set; }
    public string? AlertSubject { get; set; }
    public string? TheMessage { get; set; }
    public string? PageName { get; set; }
    public string? UniqueRecId { get; set; }
    public bool? Treated { get; set; }
    public DateTime? TreatedDate { get; set; }
    public bool? Replied { get; set; }
    public int? RepliedWebUserId { get; set; }
    public int? Dbid { get; set; }
}
