using IbsRestApi.Application.WxIbsSecure;
using IbsRestApi.Communications.Model;

namespace IbsRestApi.Communications;
public interface IMailKitService
{
    Task<bool> SendAsync(EmailViewModel mailModel, SMTPSettingDTO _settings, CancellationToken cancellationToken);
}
