using Allure.NUnit.Attributes;
using AutomationUiFramework.Drivers;
using AutomationUiFramework.Page;
using NUnit.Framework;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationUiFramework.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly DriverContext _context;
        public LoginSteps(DriverContext context)
        {
            _context = context;
        }

        [Given("user is on login page")]
        public void UserIsOnLoginPage()
        {
            _context.LoginPage.ValidateLoginPage();
        }

        [AllureOwner("athira")]
        [When("user logs in with {string} and {string}")]
        public void UserEnterCredentials(string userName, string password)
        {
            _context.LoginPage.EnterCredentials(userName, password);
        }

        [AllureOwner("athira")]
        [Then("user should see {string} text")]
        public void ThenUserShouldSeeText(string text)
        {
            _context.LoginPage.LoginText(text);
        }

        [AllureOwner("athira")]
        [When("user click on Login button")]
        public void WhenUserClickOnLoginButton()
        {
            _context.LoginPage.ClickLogin();
        }

        [AllureOwner("athira")]
        [When("login should show the status with {string}")]
        public void WhenLoginShouldShowTheStatusWith(string expectedText)
        {
            _context.LoginPage.LoginPageStatus(expectedText);
        }
    }
}
