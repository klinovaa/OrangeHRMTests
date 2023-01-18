using OpenQA.Selenium;

namespace OrangeHRM.Helpers
{
    public static class ScreenshotHelper
    {
        public static string TakeScreenshot(IWebDriver driver, string screenshotName)
        {
            //get name of the file with screenshots
            var name = screenshotName.Length <= 46 ? screenshotName : screenshotName.Substring(0, 46);
            var fileNameBase = $"{name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";

            //get directory path where screenshot will be saved
            var screenshotsDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\DriverErrorScreenshots";

            //check whether the directory exist and in case no - create it
            if (!Directory.Exists(screenshotsDirectory))
            {
                Directory.CreateDirectory(screenshotsDirectory);
            }

            //convert IWebDriver to ITakeScreenshot and call GetScreenshot() method that returns object with type Screenshot
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            //combine screenshot name with path where screenshot name should be saved
            var screenshotFilePath = Path.Combine(screenshotsDirectory, fileNameBase);

            //save file to directory
            screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);

            return screenshotFilePath;
        }

        public static byte[] GetScreenshotAsArrayOfBytes(IWebDriver driver)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;

            return screenshot;
        }
    }
}
