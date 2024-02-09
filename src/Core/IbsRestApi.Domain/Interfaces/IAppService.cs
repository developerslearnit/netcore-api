namespace IbsRestApi.Domain.Interfaces;

public interface IAppService
{
    /// <summary>
    /// Authentication service
    /// </summary>
    IAuthService Auth { get; }
    ISetupService SetupService { get; }
    IMdmService MdmService { get; }
    IPortfolioService PortfolioService { get; }
    ISettingsService SettingsService { get; }
    ICashManagementService CashManagementService { get; }
    IFileStorageService FileStorageService { get; }
    IKycService KycService { get; }
}
