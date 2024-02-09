namespace IbsRestApi.Entities.Secure;

public partial class WxPreference
{
    public int IdWxPreferences { get; set; }
    public string? Name { get; set; }
    public bool? StrongPassword { get; set; }
    public int? MinPasswordLenght { get; set; }
    public int? DaysB4warnPwdExpire { get; set; }
    public int? MaxPwdsSaved { get; set; }
    public int? ConsecutiveBadLogin { get; set; }
    public int? LoginTimeout { get; set; }
    public int? UseActiveDirectory { get; set; }
    public bool? DisAllowLogins { get; set; }
    public bool? AutoAssignLognId { get; set; }
    public int? DeactivationWaitTime { get; set; }
    public int? RenewPasswordEvery { get; set; }
    public string? PortalUrl { get; set; }
    public string? ReCrystalUrl { get; set; }
    public bool? EncryptCrystal { get; set; }
    public string? ComplianceMailList { get; set; }
    public string? OperationsMailList { get; set; }
    public string? MgtMailList { get; set; }
    public string? ItmailList { get; set; }
    public bool? AutoNotification { get; set; }
    public bool? KycVerificationRequired { get; set; }
    public bool? SendEmailImmediately { get; set; }
    public string? CrystalReportFolder { get; set; }
}
