namespace IbsRestApi.Entities.Secure;

public partial class AppConfigSetting
{
    public int ConfigId { get; set; }
    public string ConfigKey { get; set; } = null!;
    public string ConfigValue { get; set; } = null!;
}
