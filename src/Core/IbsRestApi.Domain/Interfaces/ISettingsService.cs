using IbsRestApi.Application.AuthModels;
using IbsRestApi.Application.IbsMdm;
using IbsRestApi.Application.WxIbsSecure;

namespace IbsRestApi.Domain.Interfaces;

public interface ISettingsService
{
    void AddSetting(string key, string value);
    string GetSetting(string configKey);
    SMTPSettingDTO GetSMTPSettings();
    List<PaymentChannelViewModel> ListPaymentChannels();
    void LoadAllPaymentChannels();
    void LoadAppSetting();
    void LoadSMTPSettings();
    void LogApplicationError(ErrorLogViewModel errorModel);
    void SeedSettings(List<KeyValuePair<string, string>> model);
    BranchModel GetSeletectedBranch(Guid branchId);
    List<BranchModel> GetAllBarnches();
    Task<bool> AddEmailToken(string email, string token);
    Task<TokenValidationResponse> ValidateEmailToken(string email, string token);

}
