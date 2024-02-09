using IbsRestApi.Application.WxIbsSecure;
using IbsRestApi.Communications.Model;
using MailKit.Security;
using MimeKit;

namespace IbsRestApi.Communications;
public class MailKitService : IMailKitService
{
   
    public async Task<bool> SendAsync(EmailViewModel mailModel, SMTPSettingDTO _settings, CancellationToken cancellationToken)
    {
        try
        {
           
            if (_settings == null) return false;


            var email = new MimeMessage();

            email.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderAddress));
            email.Sender = new MailboxAddress(_settings.SenderName, _settings.SenderAddress);

            if (!mailModel.ToEMails.Contains(",") || !mailModel.ToEMails.Contains(";"))
            {
                email.To.Add(MailboxAddress.Parse(mailModel.ToEMails));
            }

            if (mailModel.ToEMails.Contains(","))
            {
                var splittedTos = mailModel.ToEMails.Split(",");

                foreach (var to in splittedTos)
                {
                    email.To.Add(MailboxAddress.Parse(to));
                }
            }

            if (mailModel.ToEMails.Contains(";"))
            {
                var splittedTos = mailModel.ToEMails.Split(";");

                foreach (var to in splittedTos)
                {
                    email.To.Add(MailboxAddress.Parse(to));
                }
            }

            if (!string.IsNullOrWhiteSpace(mailModel.CcEmails))
            {
                if (!mailModel.CcEmails.Contains(",") || !mailModel.CcEmails.Contains(";"))
                {
                    email.Cc.Add(MailboxAddress.Parse(mailModel.CcEmails));
                }


                if (mailModel.CcEmails.Contains(","))
                {
                    var splittedTos = mailModel.CcEmails.Split(",");

                    foreach (var to in splittedTos)
                    {
                        email.Cc.Add(MailboxAddress.Parse(to));
                    }
                }

                if (mailModel.CcEmails.Contains(";"))
                {
                    var splittedTos = mailModel.CcEmails.Split(";");

                    foreach (var to in splittedTos)
                    {
                        email.Cc.Add(MailboxAddress.Parse(to));
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(mailModel.BccEmails))
            {
                if (!mailModel.BccEmails.Contains(",") || !mailModel.BccEmails.Contains(";"))
                {
                    email.Bcc.Add(MailboxAddress.Parse(mailModel.BccEmails));
                }


                if (mailModel.BccEmails.Contains(","))
                {
                    var splittedTos = mailModel.BccEmails.Split(",");

                    foreach (var to in splittedTos)
                    {
                        email.Bcc.Add(MailboxAddress.Parse(to));
                    }
                }

                if (mailModel.BccEmails.Contains(";"))
                {
                    var splittedTos = mailModel.BccEmails.Split(";");

                    foreach (var to in splittedTos)
                    {
                        email.Bcc.Add(MailboxAddress.Parse(to));
                    }
                }
            }


            var body = new BodyBuilder();
            email.Subject = mailModel.Subject;
            body.HtmlBody = mailModel.Body;
            email.Body = body.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            var useStartTls = _settings.SecureEmail_StartTLS.HasValue ? _settings.SecureEmail_StartTLS.Value : false;

            if (_settings.EnableSSL)
            {
                await smtp.ConnectAsync(_settings.SMTPHost,int.Parse(_settings.SMTPPort), SecureSocketOptions.SslOnConnect, cancellationToken);
            }
            else if (useStartTls)
            {
                await smtp.ConnectAsync(_settings.SMTPHost, int.Parse(_settings.SMTPPort), SecureSocketOptions.StartTls, cancellationToken);
            }
            else
            {
                await smtp.ConnectAsync(_settings.SMTPHost, int.Parse(_settings.SMTPPort),false, cancellationToken);
            }

            await smtp.AuthenticateAsync(_settings.AuthUser, _settings.AuthPassWord, cancellationToken);
            await smtp.SendAsync(email, cancellationToken);
            await smtp.DisconnectAsync(true, cancellationToken);

            return true;
        }
        catch (Exception)
        {

            return false;
        }
        

    }
}

