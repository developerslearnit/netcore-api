namespace IbsRestApi.Communications;

public interface IMailSender
{
    Task SendMail(string subject, string toEmail, string body);
}
