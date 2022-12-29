using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Drawing;

namespace OrangeHRM
{
    //implement IWebElement
    public class MyWebElement : IWebElement
    {
        //property for locator to use it if needed
        protected By By { get; set; }

        //protected property for IWebElement returns value using IWebDriverExtension method GetWebElementWhenExist
        //after that we can be sure that element is always in a stable state and prevent possible exceptions
        protected IWebElement WebElement => WebDriverFactory.Driver.GetWebElementWhenExist(By);

        //start of default IWebElement properties
        public string TagName => WebElement.TagName;

        public string Text => WebElement.Text;

        public bool Enabled => WebElement.Enabled;

        public bool Selected => WebElement.Enabled;

        public Point Location => WebElement.Location;

        public Size Size => WebElement.Size;

        public bool Displayed => WebElement.Displayed;
        //finish of default IWebElement properties

        //constructor to initialize an instance of our custom element
        public MyWebElement(By by)
        {
            By = by;
        }

        //start of default IWebElement methods
        public void Clear() => WebElement.Clear();

        public void Click()
        {
            //here is simple example why we need this wrapper
            try
            {
                WebElement.Click();
            }
            catch (ElementClickInterceptedException) //here we can handle if click is intercepted and scroll element into view
            {
                ScrollIntoView();
                WebElement.Click();
            }
        }

        public IWebElement FindElement(By by) => WebElement.FindElement(By);

        public ReadOnlyCollection<IWebElement> FindElements(By by) => WebElement.FindElements(By);

        public string GetAttribute(string attributeName) => WebElement.GetAttribute(attributeName);

        public string GetCssValue(string propertyName) => WebElement.GetCssValue(propertyName);

        public string GetDomAttribute(string attributeName) => WebElement.GetDomAttribute(attributeName);

        public string GetDomProperty(string propertyName) => WebElement.GetDomProperty(propertyName);

        public ISearchContext GetShadowRoot() => WebElement.GetShadowRoot();

        public void SendKeys(string text) => WebElement.SendKeys(text);

        public void Submit() => WebElement.Submit();
        //finish of default IWebElement methods

        //method to scroll element into view using JavaScript
        public void ScrollIntoView() => WebDriverFactory.JavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView()", WebElement);

        //method to get value of class attribute
        public string GetValueOfClassAttribute() => GetAttribute("class");

        //method to get amount of all elements
        public int GetAmountOfElements() => FindElements(By).Count();

        //method to get element with apropriate index
        public IWebElement GetElementAt(int i) => FindElements(By).ElementAt(i);

        //method to simulate double click via Actions
        public void DoubleClickViaActions() => WebDriverFactory.Actions.DoubleClick(WebElement).Perform();

        //method to simulate right click via Actions
        public void RightClickViaActions() => WebDriverFactory.Actions.ContextClick(WebElement).Perform();

        //method to simulate click via Actions
        public void DynamicClickViaActions() => WebDriverFactory.Actions.Click(WebElement).Perform();
    }
}
