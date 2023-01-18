using OpenQA.Selenium;

namespace OrangeHRM.PageObjects
{
    public class BasePage
    {
        public void NavigateToCategory(string categoryName)
        {
            var categoryXPathLocator = new MyWebElement(By.XPath($"//*[@class='oxd-main-menu-item-wrapper' and .//text()='{categoryName}']"));

            categoryXPathLocator.Click();
        }
    }
}
