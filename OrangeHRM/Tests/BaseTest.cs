using Allure.Net.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OrangeHRM.Data;
using OrangeHRM.Helpers;
using OrangeHRM.PageObjects;

namespace OrangeHRM
{
    public class BaseTest
    {
        private string _pageUrl;

        public BaseTest(string pageUrl)
        {
            _pageUrl = pageUrl;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverFactory.Driver.Manage().Window.Size = new System.Drawing.Size(1200, 800);

            WebDriverFactory.Driver.Navigate().GoToUrl(_pageUrl);
            GenericPages.LoginPage.EnterUserName(TestSettings.Username);
            GenericPages.LoginPage.EnterPassword(TestSettings.Password);
            GenericPages.LoginPage.ClickLoginButton();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                TakeScreenshot();
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            WebDriverFactory.QuitDriver();
        }

        private void TakeScreenshot()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var screenshotPath = ScreenshotHelper.TakeScreenshot(WebDriverFactory.Driver, testName);
            TestContext.AddTestAttachment(screenshotPath);

            var screenshot = ScreenshotHelper.GetScreenshotAsArrayOfBytes(WebDriverFactory.Driver);
            AllureLifecycle.Instance.AddAttachment(testName, "image/png", screenshot);
        }
    }
}
