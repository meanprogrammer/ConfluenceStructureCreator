using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class AppSettingsHelper
    {
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }
    }
}
