namespace IbsRestApi.Entities.IbsMdm;

public partial class Smtpsetting
{
    public long Id { get; set; }
    public string IdApplication { get; set; } = null!;
    public bool? SecureEmailAlways { get; set; }
    public bool? SecureEmailStartTls { get; set; }
    public string? Smtphost { get; set; }
    public string? Smtpport { get; set; }
    public string? SenderAddress { get; set; }
    public string? SenderName { get; set; }
    public string? ReplyToAddress { get; set; }
    public string? MailType { get; set; }
    public bool? EnableSsl { get; set; }
    public string? AuthUser { get; set; }
    public string? AuthPassWord { get; set; }
}
