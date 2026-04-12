using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationUiFramework.ConfigData
{
    public class ConfigReader
    {
        private static IConfiguration _config;

        static ConfigReader()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string Get(string key)
        {
            return _config[key];
        }
    }
}
