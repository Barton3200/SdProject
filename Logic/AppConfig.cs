using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {
    public static class AppConfig {
        static string GetSetting(string key) {
            return ConfigurationManager.AppSettings.Get(key);
        }
        public static string GetActiveConnectionString() {
            return GetSetting("activeConnectionString");
        }
    }
}
