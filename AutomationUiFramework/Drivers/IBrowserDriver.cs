using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationUiFramework.Drivers
{
    public interface IBrowserDriver
    {
        public IWebDriver CreateDriver();
    }
}
