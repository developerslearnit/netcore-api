namespace IbsRestApi.Api.Helpers;

public interface IAPIHelpers
{
    string BuildLiquidationNoticeTemplate(string templateName, string amount, string contactTelephone, string coyName, string customerName = "");
    string BuildNewAccountInHouseNotificatitonTemplate(string pccNumber, string coyName, string FullName);
    string BuildNewAccountTemplate(string pccNumber, string Telephone, string coyName, string FirstName, string password, string supportUrl,string email=null);
    string BuildNewRedeemptionNotificationTemplate(string coyName, string contactTelephone, string amount, string productName, string customerName = "");
    string BuildPasswordResetConfirmationTemplate(string name, string portalName);
    string BuildPasswordResetMobileTemplate(string token, string name, string coyName);
    string BuildPasswordResetTemplate(string resetLink, string name, string portalName);
    string BuildReceiptTemplate(string totalAmount, string productPurchased, string orderRef, string coyName);
    string BuildEmailConfirmationTemplate(string clientName,string customerName, string otp);
    Task<string> UploadUserAvatar(IFormFile file);

}
