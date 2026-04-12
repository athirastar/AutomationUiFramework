using AutomationUiFramework.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationUiFramework.Drivers
{
    public class DriverContext
    {
        public IWebDriver Driver { get; set; }

        public LoginPage LoginPage { get; set; }
    }
}
