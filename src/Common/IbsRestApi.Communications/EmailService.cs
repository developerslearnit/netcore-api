using IbsRestApi.Common;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;

namespace IbsRestApi.Communications;

public class SMTPDetails
{
    public string SMTPHost { get; set; }

    public int SMTPPort { get; set; }

    public bool EnableSSL { get; set; }

    public bool UseDefaultCredentials { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

}
public class EmailService : IEmailService
{

    private readonly string _apiKey;
    private readonly string _fromEmail;
    private readonly string _fromDisplayName;
    private readonly IConfiguration _config;
    /// <summary>
    /// Initiate Sendgrid email notifications
    /// </summary>
    /// <param name="apiKey"></param>
    /// <param name="fromEmail"></param>
    /// <param name="fromDisplayName"></param>
    public EmailService(string apiKey, string fromEmail, string fromDisplayName)
    {
        _apiKey = apiKey;
        _fromEmail = fromEmail;
        _fromDisplayName = fromDisplayName;
    }


    /// <summary>
    /// Initialize SMTP Email notification
    /// </summary>
    /// <param name="fromEmail"></param>
    /// <param name="fromDisplayName"></param>
    /// <param name="smtpInfo"></param>
    /// 

    readonly SMTPDetails _smtpInfo;
    public EmailService(string fromEmail, string fromDisplayName, SMTPDetails smtpInfo, IConfiguration config)
    {
        _fromEmail = fromEmail;
        _fromDisplayName = fromDisplayName;
        _smtpInfo = smtpInfo;
        _config = config;
    }


    /// <summary>
    /// Send mail via sendgrid to a single recipient
    /// </summary>
    /// <param name="subject"></param>
    /// <param name="toEmail"></param>
    /// <param name="body"></param>
    /// <param name="attachmentName"></param>
    /// <param name="attachment"></param>
    /// <param name="cc"></param>
    /// <param name="bcc"></param>
    /// <returns></returns>
    public async Task<bool> SendMail(string subject, string toEmail, string body, string attachmentName = null, string attachment = null, string cc = null, string bcc = null)
    {
        var mailClient = new SendGridClient(_apiKey);
        var message = new SendGridMessage()
        {
            From = new EmailAddress(_fromEmail, _fromDisplayName),
            Subject = subject,
            HtmlContent = body
        };

        if (!string.IsNullOrWhiteSpace(attachment))
        {
            message.AddAttachment(attachmentName, attachment);
        }

        message.AddTo(new EmailAddress(toEmail));

        if (!string.IsNullOrWhiteSpace(cc)) { message.AddBcc(new EmailAddress(cc)); }

        if (!string.IsNullOrWhiteSpace(bcc)) { message.AddBcc(new EmailAddress(bcc)); }

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;


        ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) =>
{
    return true;
};

        var response = await mailClient.SendEmailAsync(message);

        return response.StatusCode.ToString() == "Accepted" ? true : false;
    }


    /// <summary>
    /// Send mail via sendgrid to a multiple recipients
    /// </summary>
    /// <param name="subject"></param>
    /// <param name="toEmails"></param>
    /// <param name="body"></param>
    /// <param name="attachmentName"></param>
    /// <param name="attachment"></param>
    /// <param name="cc"></param>
    /// <param name="bcc"></param>
    /// <returns></returns>
    public async Task<bool> SendMail(string subject, List<string> toEmails, string body, string attachmentName = null, string attachment = null, List<string> cc = null, List<string> bcc = null)
    {
        var mailClient = new SendGridClient(_apiKey);
        var message = new SendGridMessage()
        {
            From = new EmailAddress(_fromEmail, _fromDisplayName),
            Subject = subject,
            HtmlContent = body
        };

        if (!string.IsNullOrWhiteSpace(attachment))
        {
            message.AddAttachment(attachmentName, attachment);
        }
        List<EmailAddress> toEmailList = new List<EmailAddress>();
        foreach (var item in toEmails)
        {
            toEmailList.Add(new EmailAddress(item));
        }
        message.AddTos(toEmailList);

        List<EmailAddress> ccEmails = new List<EmailAddress>();
        List<EmailAddress> bccEmails = new List<EmailAddress>();
        if (cc != null)
        {
            if (cc.Count > 0)
            {
                foreach (var item in cc)
                {
                    ccEmails.Add(new EmailAddress(item));
                }

                message.AddCcs(ccEmails);
            }
        }
        if (bcc != null)
        {
            if (bcc.Count > 0)
            {
                foreach (var item in bcc)
                {
                    bccEmails.Add(new EmailAddress(item));
                }

                message.AddBccs(bccEmails);
            }
        }

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;


        ServicePointManager.ServerCertificateValidationCallback +=
(sender, certificate, chain, errors) =>
{
    return true;
};

        var response = await mailClient.SendEmailAsync(message);

        return response.StatusCode.ToString() == "Accepted" ? true : false;
    }


    /// <summary>
    /// Send mail via SMTP to a single recipient
    /// </summary>
    /// <param name="subject"></param>
    /// <param name="toEmail"></param>
    /// <param name="body"></param>
    /// <param name="attachment"></param>
    /// <param name="cc"></param>
    /// <param name="bcc"></param>
    public void SendMail(string subject, string toEmail, string body, string attachment = null, string cc = null, string bcc = null)
    {
        var mailMessage = new MailMessage()
        {
            From = new MailAddress(_fromEmail, _fromDisplayName),
            Subject = subject,
            IsBodyHtml = true,
            Body = body
        };

        mailMessage.To.Add(new MailAddress(toEmail));

        if (!string.IsNullOrWhiteSpace(cc))
        {
            mailMessage.CC.Add(new MailAddress(cc));
        }

        if (!string.IsNullOrWhiteSpace(bcc))
        {
            mailMessage.Bcc.Add(new MailAddress(bcc));
        }

        if (!string.IsNullOrWhiteSpace(attachment))
        {
            mailMessage.Attachments.Add(new System.Net.Mail.Attachment(attachment));
        }




        var smtpClient = new SmtpClient()
        {
            Port = _smtpInfo.SMTPPort,
            Host = _smtpInfo.SMTPHost,
            EnableSsl = _smtpInfo.EnableSSL,
            UseDefaultCredentials = _smtpInfo.UseDefaultCredentials
        };
        var password = _smtpInfo.Password;
        _ = bool.TryParse(_config["SMTPPasswordEncrypted"], out var useEncryption);
        if (useEncryption)
        {
            password = EncryptionAlg.DecryptStringAES(_smtpInfo.Password);
        }

        if (_smtpInfo.UseDefaultCredentials == false)
        {
            smtpClient.Credentials = new NetworkCredential(_smtpInfo.Username, password);
        }

        smtpClient.Send(mailMessage);

    }

    /// <summary>
    /// Send mail via SMTP to a multiple recipients
    /// </summary>
    /// <param name="subject"></param>
    /// <param name="toEmails"></param>
    /// <param name="body"></param>
    /// <param name="attachment"></param>
    /// <param name="cc"></param>
    /// <param name="bcc"></param>
    public void SendMail(string subject, List<string> toEmails, string body, string attachment = null, List<string> cc = null, List<string> bcc = null)
    {
        var mailMessage = new MailMessage()
        {
            From = new MailAddress(_fromEmail),
            Subject = subject,
            IsBodyHtml = true,
            Body = body
        };


        foreach (var item in toEmails)
        {
            mailMessage.To.Add(new MailAddress(item));
        }

        if (cc != null)
        {
            foreach (var item in cc)
            {
                mailMessage.CC.Add(new MailAddress(item));
            }

        }

        if (bcc != null)
        {
            foreach (var item in bcc)
            {
                mailMessage.Bcc.Add(new MailAddress(item));
            }

        }

        if (!string.IsNullOrWhiteSpace(attachment))
        {
            mailMessage.Attachments.Add(new System.Net.Mail.Attachment(attachment));
        }



        var smtpClient = new SmtpClient()
        {
            Port = _smtpInfo.SMTPPort,
            Host = _smtpInfo.SMTPHost,
            EnableSsl = _smtpInfo.EnableSSL,
            UseDefaultCredentials = _smtpInfo.UseDefaultCredentials
        };
        var password = _smtpInfo.Password;
        var useEncryption = _config.GetValue<bool>("SMTPPasswordEncrypted");
        if (useEncryption)
        {
            password = EncryptionAlg.DecryptStringAES(_smtpInfo.Password);
        }
        if (_smtpInfo.UseDefaultCredentials == false)
        {
            smtpClient.Credentials = new NetworkCredential(_smtpInfo.Username, password);
        }

        smtpClient.Send(mailMessage);
    }
}
