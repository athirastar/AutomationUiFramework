using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationUiFramework.Drivers
{
    public static  class DriverFactory
    {
        public static IWebDriver GetDriver(string browser)
        {
            IBrowserDriver _initialize;
            switch (browser.ToLower())
            {
                case "chrome":
                    _initialize = new ChromeBrowserDriver();
                    break;

                case "firrefox":
                    _initialize = new ChromeBrowserDriver();
                    break;

                default:
                    throw new ArgumentException("The passed value not containing browser");
            }
            return _initialize.CreateDriver();
        }
    }
}
