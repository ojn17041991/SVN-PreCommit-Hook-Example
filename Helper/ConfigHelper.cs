using System;
using System.Configuration;
using PreCommitHook.Enum;

namespace PreCommitHook.Helper
{
    public class ConfigHelper
    {
        public string GetSetting(string settingName)
        {
            return ConfigurationManager.AppSettings?[settingName] ?? string.Empty;
        }

        public bool GetTestsEnabled()
        {
            return Convert.ToBoolean(ConfigurationManager.AppSettings?["testsEnabled"] ?? "true");
        }

        public bool GetTestEnabled(string testName)
        {
            return (ConfigurationManager.AppSettings?[testName] ?? "false") == "true";
        }
    }
}
