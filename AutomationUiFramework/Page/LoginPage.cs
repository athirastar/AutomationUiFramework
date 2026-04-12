using AutomationUiFramework.Helper;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationUiFramework.Page
{
    public class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Locators
        private By loginFrameLocator = By.XPath("//form[@id='loginFrm']");
        private By UserNameLocator = By.XPath("//input[@id='loginFrm_loginname']");
        private By PasswordLocator = By.XPath("//input[@id='loginFrm_password']");
        private By LoginLocator = By.XPath("//button[@title='Login']");
        private IWebElement LoginFrame => WaitHelper.WaitForElementVisible(driver, loginFrameLocator);
        private IWebElement LoginUserName => WaitHelper.WaitForElementVisible(driver, UserNameLocator);
        private IWebElement LoginPassword => WaitHelper.WaitForElementVisible(driver, PasswordLocator);
        private IWebElement LoginButton => WaitHelper.WaitForElementClickable(driver, LoginLocator);

        public void ValidateLoginPage()
        {
            LoginFrame.Displayed.Should().BeTrue();
        }

        public void EnterCredentials(string userName, string password)
        {
            LoginUserName.Clear();
            LoginUserName.SendKeys(userName);
            LoginPassword.Clear();
            LoginPassword.SendKeys(password);
        }
        public void ClickLogin()
        {
            LoginButton.Click();
        }
        public bool LoginPageStatus(string expectedText)
        {
            return driver.Url.Contains(expectedText);
        }

        public void LoginText(string expectedText)
        {
            string actualText = LoginButton.Text;
            actualText.Should().NotBeNullOrWhiteSpace().Equals(expectedText);
        }
    }
}
