using Azure.Core;
using IbsRestApi.Domain.Interfaces;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using System.IO;

namespace IbsRestApi.Api.Helpers;

public class APIHelpers : IAPIHelpers
{
    readonly IWebHostEnvironment _env;
    private readonly IAppService _appService;
    public APIHelpers(IWebHostEnvironment env, IAppService appService)
    {
        _env = env;
        _appService = appService;
    }
    public string BuildNewAccountTemplate(string pccNumber,
       string Telephone, string coyName, string FirstName, string password, string supportUrl, string email = null)
    {
        var _rootPath = _env.ContentRootPath;
        var coyFolder = _appService.SettingsService.GetSetting("CLIENT_EMAIL_TEMPLATE_FOLDER");
        var templatePath = Path.Combine(_rootPath, $"MailTemplates\\{coyFolder}\\NewAccountEmail.html");
        var body = string.Empty;
        using (StreamReader reader = new StreamReader(templatePath))
        {
            body = reader.ReadToEnd();
        }

        body = body
                .Replace("{pccNumber}", pccNumber)
                .Replace("{password}", password)
                .Replace("{telephone}", Telephone)
                .Replace("{coyName}", coyName)
                .Replace("{firstName}", FirstName)
                .Replace("{supportUrl}", supportUrl)
                .Replace("{url}", supportUrl)
                .Replace("{year}", DateTime.Now.Year.ToString())
                .Replace("{email}", email);


        return body;
    }

    public string BuildNewAccountInHouseNotificatitonTemplate(string pccNumber, string coyName, string FullName)
    {
        var _rootPath = _env.ContentRootPath;
        var coyFolder = _appService.SettingsService.GetSetting("CLIENT_EMAIL_TEMPLATE_FOLDER");
        var templatePath = Path.Combine(_rootPath, $"MailTemplates\\{coyFolder}\\NewAccountNotification.html");
        var body = string.Empty;
        using (StreamReader reader = new StreamReader(templatePath))
        {
            body = reader.ReadToEnd();
        }

        body = body
                .Replace("{pccNumber}", pccNumber)
                .Replace("{coyName}", coyName)
                .Replace("{fullName}", FullName)
                .Replace("{year}", DateTime.Now.Year.ToString());

        return body;
    }

    public string BuildNewRedeemptionNotificationTemplate(
       string coyName, string contactTelephone, string amount, string productName, string customerName = "")
    {
        var _rootPath = _env.ContentRootPath;
        var templatePath = Path.Combine(_rootPath, $"MailTemplates\\RedemptionNoticeInhouse.html");
        var body = string.Empty;
        using (StreamReader reader = new StreamReader(templatePath))
        {
            body = reader.ReadToEnd();
        }

        body = body
                .Replace("{amount}", amount)
                .Replace("{contactTelephone}", contactTelephone)
                .Replace("{coyName}", coyName)
                .Replace("{customerName}", customerName)
                .Replace("{product}", productName)
                .Replace("{year}", DateTime.Now.Year.ToString());

        return body;

    }

    public string BuildPasswordResetMobileTemplate(string token, string name, string coyName)
    {

        var _rootPath = _env.ContentRootPath;
        var coyFolder = _appService.SettingsService.GetSetting("CLIENT_EMAIL_TEMPLATE_FOLDER");
        var templatePath = Path.Combine(_rootPath, $"MailTemplates\\{coyFolder}\\forgotpassword_mobile.html");
        var body = string.Empty;
        using (StreamReader reader = new StreamReader(templatePath))
        {
            body = reader.ReadToEnd();
        }

        body = body
                .Replace("{token}", token)
                .Replace("{name}", name)
                .Replace("{coyName}", coyName)
                .Replace("{copYear}", DateTime.Now.Year.ToString());

        return body;
    }

    public string BuildPasswordResetTemplate(string resetLink, string name, string portalName)
    {

        var _rootPath = _env.ContentRootPath;
        var templatePath = Path.Combine(_rootPath, $"MailTemplates\\forgotpassword.html");
        var body = string.Empty;
        using (StreamReader reader = new StreamReader(templatePath))
        {
            body = reader.ReadToEnd();
        }

        body = body
                .Replace("{resetLink}", resetLink)
                .Replace("{name}", name)
                .Replace("{coyName}", portalName)
                .Replace("{copYear}", DateTime.Now.Year.ToString());

        return body;
    }


    public string BuildReceiptTemplate(string totalAmount, string productPurchased,
        string orderRef, string coyName)
    {
        var _rootPath = _env.ContentRootPath;
        var templatePath = Path.Combine(_rootPath, $"MailTemplates\\Receipt.html");
        var body = string.Empty;
        using (StreamReader reader = new StreamReader(templatePath))
        {
            body = reader.ReadToEnd();
        }

        body = body.Replace("{totalAmount}", totalAmount)
         .Replace("{productPurchased}", productPurchased)
         .Replace("{Date}", DateTime.Now.ToString("dd-MMM-yyyy"))
         .Replace("{orderRef}", orderRef)
         .Replace("{coyName}", coyName)
         .Replace("{copYear}", DateTime.Now.Year.ToString());

        return body;
    }

    public string BuildLiquidationNoticeTemplate(string templateName, string amount,
        string contactTelephone, string coyName, string customerName = "")
    {
        var _rootPath = _env.ContentRootPath;
        var coyFolder = _appService.SettingsService.GetSetting("CLIENT_EMAIL_TEMPLATE_FOLDER");
        var templatePath = Path.Combine(_rootPath, $"MailTemplates\\{coyFolder}\\{templateName}.html");
        var body = string.Empty;
        using (StreamReader reader = new StreamReader(templatePath))
        {
            body = reader.ReadToEnd();
        }

        body = body
                .Replace("{amount}", amount)
                .Replace("{contactTelephone}", contactTelephone)
                .Replace("{coyName}", coyName)
                .Replace("{customerName}", customerName)
                .Replace("{year}", DateTime.Now.Year.ToString());

        return body;
    }

    public string BuildPasswordResetConfirmationTemplate(string name, string portalName)
    {

        var _rootPath = _env.ContentRootPath;
        var coyFolder = _appService.SettingsService.GetSetting("CLIENT_EMAIL_TEMPLATE_FOLDER");
        var templatePath = Path.Combine(_rootPath, $"MailTemplates\\{coyFolder}\\SuccessfulResetPassword.html");
        var body = string.Empty;
        using (StreamReader reader = new StreamReader(templatePath))
        {
            body = reader.ReadToEnd();
        }

        body = body
                .Replace("{name}", name)
                .Replace("{portalName}", portalName)
                .Replace("{copYear}", DateTime.Now.Year.ToString());

        return body;
    }

    public string BuildEmailConfirmationTemplate(string clientName, string customerName, string otp)
    {
        var _rootPath = _env.ContentRootPath;
        var coyFolder = _appService.SettingsService.GetSetting("CLIENT_EMAIL_TEMPLATE_FOLDER");
        var templatePath = Path.Combine(_rootPath, $"MailTemplates\\{coyFolder.ToLower()}\\emailconfirm.html");
        var body = string.Empty;
        using (StreamReader reader = new StreamReader(templatePath))
        {
            body = reader.ReadToEnd();
        }

        body = body
                .Replace("{clientName}", clientName)
                .Replace("{otp}", otp);

        return body;
    }

    public async Task<string> UploadUserAvatar(IFormFile file)
    {
        var _rootPath = _env.WebRootPath;

        var uploadPath = Path.Combine(_rootPath, "avatars");

        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        var fileName = Path.GetFileName(file.FileName);

        var uploadFullPath = Path.Combine(uploadPath, fileName);

        using (var ms = new MemoryStream())
        {
            await file.CopyToAsync(ms);
            var content = ms.ToArray();
            await File.WriteAllBytesAsync(uploadFullPath, content);
        }

        return uploadFullPath;

    }
}
