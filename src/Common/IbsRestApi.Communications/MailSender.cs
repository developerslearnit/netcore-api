using IbsRestApi.Common;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Domain.Services;
using Microsoft.Extensions.Configuration;

namespace IbsRestApi.Communications;

public class MailSender : IMailSender
{
    private readonly IAppService _appService;
    private readonly IConfiguration _config;
    public MailSender(IAppService appService, IConfiguration config)
    {
        _appService = appService;
        _config = config;
    }

    public async Task SendMail(string subject, string toEmail, string body)
    {
        var smtpSettings = _appService.SettingsService.GetSMTPSettings();
        if (smtpSettings != null)
        {
            if (smtpSettings.UseSMTP)
            {

                if (smtpSettings.UseSMTP)
                {
                    var smtpDetails = new SMTPDetails()
                    {
                        EnableSSL = smtpSettings.EnableSSL,
                        Password = smtpSettings.AuthPassWord,
                        SMTPHost = smtpSettings.SMTPHost,
                        SMTPPort = int.Parse(smtpSettings.SMTPPort),
                        UseDefaultCredentials = string.IsNullOrWhiteSpace(smtpSettings.AuthPassWord),
                        Username = smtpSettings.AuthUser,
                    };


                    var smtpMailService = new EmailService(smtpSettings.SenderAddress, smtpSettings.SenderName, smtpDetails, _config);

                    smtpMailService.SendMail(subject, toEmail, body, "", "", "");
                }
                else
                {
                    var sendgridAPIKey = _appService.SettingsService.GetSetting("SENDGRID_KEY");

                    var sendGridMailService = new EmailService(sendgridAPIKey, smtpSettings.SenderAddress, smtpSettings.SenderName);

                    await sendGridMailService.SendMail(subject, toEmail, body, "", "", "", "");
                }
            }
        }
    }
}

