using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbsRestApi.Common;
public static class AppConfigSettings
{
    private static IConfiguration _config;
    public static void AppSettingsConfigure(IConfiguration config)
    {
        _config = config;
    }

    public static string Setting(string key)
    {
        return _config.GetSection(key).Value;
    }
}
