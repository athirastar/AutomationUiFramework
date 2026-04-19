using Allure.Net.Commons;
using Allure.ReqnrollPlugin;
using AutomationUiFramework.ConfigData;
using AutomationUiFramework.Drivers;
using AutomationUiFramework.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using System.Text;

namespace AutomationUiFramework.Hooks
{
    [Binding]
    public sealed class TestHooks
    {
        private readonly DriverContext _context;
        private readonly ScenarioContext _scenarioContext;
        public TestHooks(DriverContext context, ScenarioContext scenarioContext)
        {
            _context = context;
            _scenarioContext = scenarioContext;
        }
        [BeforeScenario]
        public void Setup()
        {
            DriverManager.Init(ConfigReader.Get("Browser"));
            _context.Driver = DriverManager.Driver;
            //DriverManager.Driver.Navigate().GoToUrl(ConfigReader.Get("BaseUrl"));
            _context.Driver.Navigate().GoToUrl(ConfigReader.Get("BaseUrl"));
            _context.LoginPage = new LoginPage(_context.Driver);
            var owner = _scenarioContext.ScenarioInfo.Tags
           .FirstOrDefault(t => t.StartsWith("owner:", StringComparison.OrdinalIgnoreCase))
            ?.Split(':')[1];
            AllureLifecycle.Instance.UpdateTestCase(tc =>
            {
                tc.name = _scenarioContext.ScenarioInfo.Title;
                if (!string.IsNullOrEmpty(owner))
                {
                    tc.labels.Add(Label.Owner(owner));
                }
            });
        }
        [BeforeStep]
        public void BeforeStep()
        {
            var stepInfo = _scenarioContext.StepContext.StepInfo;

            string stepName = $"{stepInfo.StepDefinitionType} {stepInfo.Text}";
        }

        [AfterStep]
        public void AfterStep()
        {
            // Screenshot only when step fails
            if (_scenarioContext.TestError != null)
            {
                AttachScreenshot("Step Failure Screenshot");
            }
        }


        [AfterScenario]
        public void TearDown()
        {
            if (_scenarioContext.TestError != null)
            {
                AttachScreenshot("Final Screenshot");
                AllureApi.AddAttachment(
             "Error",
             "text/plain",
               Encoding.UTF8.GetBytes(_scenarioContext.TestError.ToString())
              );
            }

            DriverManager.Quit();
        }
        private void AttachScreenshot(string name)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)_context.Driver)
                    .GetScreenshot()
                    .AsByteArray;

                AllureApi.AddAttachment(
                    name,
                    "image/png",
                    screenshot
                );
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }
    }
}