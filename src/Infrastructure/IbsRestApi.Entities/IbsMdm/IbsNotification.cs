namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsNotification
{
    public int IdNotifications { get; set; }
    public string? IdApplication { get; set; }
    public string? NotificationType { get; set; }
    public string? HtmlMessage { get; set; }
    public string? IdNotifyClass { get; set; }
    public string? MailSubject { get; set; }
    public bool? IsHtml { get; set; }
}
