using OpenQA.Selenium;

namespace OrangeHRM.PageObjects.Admin
{
    public class AdminNavigationPage : BasePage
    {
        public void NavigateToTab(string categoryName, string menuItemName)
        {
            var categoryTabXPathLocator = $"//*[contains(@class,'oxd-topbar-body-nav-tab') and span/text()='{categoryName}']";
            
            //category xpath
            var categoryXPathLocator = new MyWebElement(By.XPath($"{categoryTabXPathLocator}"));
            
            categoryXPathLocator.Click();

            var menuItemXPathLocator = new MyWebElement(By.XPath($"{categoryTabXPathLocator}//*[@role='menuitem' and text()='{menuItemName}']"));

            menuItemXPathLocator.Click();
        }
    }
}
