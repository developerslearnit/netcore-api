namespace IbsRestApi.Entities.IbsMdm;

public partial class MessageServer
{
    public int IdMessageServer { get; set; }
    public string? IdApplication { get; set; }
    public DateTime? CreationDate { get; set; }
    public string? EmailAddress { get; set; }
    public string? EmailSubject { get; set; }
    public string? EMailMessage { get; set; }
    public bool? EMailIsHtml { get; set; }
    public string? EmailAttachment { get; set; }
    public string? EmailccAddress { get; set; }
    public string? FromEmailAddress { get; set; }
    public string? SenderDisplayName { get; set; }
    public DateTime? EmailSentDate { get; set; }
    public string? EmailResponse { get; set; }
    public string? EMailStatus { get; set; }
    public string? SmsGsmNo { get; set; }
    public string? SmsMessage { get; set; }
    public DateTime? SmsSentDate { get; set; }
    public string? SmsResponse { get; set; }
    public string? SmsStatus { get; set; }
    public string? Comments { get; set; }

    public virtual IbsApplication? IdApplicationNavigation { get; set; }
}
