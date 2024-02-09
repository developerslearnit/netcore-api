namespace IbsRestApi.Entities.Secure;

public partial class IbsSecuritySetting
{
    public long IdIbsSecuritySetting { get; set; }
    public string SettingKey { get; set; } = null!;
    public string SettingValue { get; set; } = null!;
}
