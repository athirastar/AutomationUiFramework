using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationUiFramework.Drivers
{
    public sealed class DriverManager
    {
        private static Lazy<IWebDriver> _lazyDriver; //Holding Iwebdriver instance in Lazy<T> Means thread local initialization means multiple thread try to access driver at a same time and we want only once instance to be created 

        private DriverManager() { } // it prevents creating instance from any of the class

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
            //provide controlled access to the webdriver instance
            get
            {
                if (_lazyDriver == null)
                    throw new Exception("Driver not initialized. Call Init() first.");

                return _lazyDriver.Value; // create the driver if not created
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
