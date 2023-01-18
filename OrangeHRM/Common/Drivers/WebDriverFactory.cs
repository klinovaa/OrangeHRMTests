using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OrangeHRM.Data;
using System.Collections.Concurrent;

namespace OrangeHRM
{
    public class WebDriverFactory
    {
        private static readonly ConcurrentDictionary<string, IWebDriver> DriverCollection = new(); //collection created to isolate threads for possible parallelization

        public static IWebDriver Driver
        {
            get
            {
                if (!DriverCollection.Keys.Contains(TestContextValues.ExecutableClassName)) //if driver is not initialized yet we do it
                {
                    InitializeDriver();
                }

                return DriverCollection.First(pair => pair.Key == TestContextValues.ExecutableClassName).Value; //return driver for needed test class
            }
            
            private set => DriverCollection.TryAdd(TestContextValues.ExecutableClassName, value); //new driver will be assigned only if DriverCollection doesn't contain value by this key
        }

        public static Actions Actions => new Actions(Driver);

        public static IJavaScriptExecutor JavaScriptExecutor => (IJavaScriptExecutor)Driver;

        public static void QuitDriver() => Driver.Quit();

        private static void InitializeDriver()
        {
            Driver = TestSettings.Browser switch
            {
                Data.Enums.Browsers.Chrome => new ChromeDriver(),
                Data.Enums.Browsers.Edge => new EdgeDriver(),
                _ => throw new InvalidOperationException(),
            };

            Driver.Manage().Window.Maximize();
        }
    }
}
