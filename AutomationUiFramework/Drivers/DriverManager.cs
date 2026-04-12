using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationUiFramework.Drivers
{
    public sealed class DriverManager
    {
        private static Lazy<IWebDriver> _lazyDriver;

        private DriverManager() { }

        public static void Init(string browser)
        {
            if (_lazyDriver == null)
            {
                _lazyDriver = new Lazy<IWebDriver>(() =>
                    DriverFactory.GetDriver(browser)
                );
            }
        }

        public static IWebDriver Driver
        {
            get
            {
                if (_lazyDriver == null)
                    throw new Exception("Driver not initialized. Call Init() first.");

                return _lazyDriver.Value;
            }
        }

        public static void Quit()
        {
            if (_lazyDriver != null && _lazyDriver.IsValueCreated)
            {
                _lazyDriver.Value.Quit();
                _lazyDriver = null;
            }
        }
    }
}
