namespace IbsRestApi.Communications;

public interface IEmailService
{
    Task<bool> SendMail(string subject, string toEmail, string body, string attachmentName = null, string attachment = null, string cc = null, string bcc = null);

    Task<bool> SendMail(string subject, List<string> toEmails, string body, string attachmentName = null, string attachment = null, List<string> cc = null, List<string> bcc = null);

    void SendMail(string subject, string toEmail, string body, string attachment = null, string cc = null, string bcc = null);

    void SendMail(string subject, List<string> toEmails, string body, string attachment = null, List<string> cc = null, List<string> bcc = null);
}
