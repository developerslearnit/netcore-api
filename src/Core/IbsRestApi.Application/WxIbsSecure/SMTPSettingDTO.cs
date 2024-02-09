namespace IbsRestApi.Application.WxIbsSecure;

public class SMTPSettingDTO
{
    public long ID { get; set; }
    public string ID_Application { get; set; }
    public Nullable<bool> SecureEmail_Always { get; set; }
    public Nullable<bool> SecureEmail_StartTLS { get; set; }
    public string SMTPHost { get; set; }
    public string SMTPPort { get; set; }
    public string SenderAddress { get; set; }
    public string SenderName { get; set; }
    public string ReplyToAddress { get; set; }
    public string MailType { get; set; }
    public bool EnableSSL { get; set; }
    public string AuthUser { get; set; }
    public string AuthPassWord { get; set; }
    public bool IsError { get; set; }
    public bool UseSMTP { get; set; }
}
