using OpenQA.Selenium;

namespace OrangeHRM.PageObjects.Admin.UserManagement
{
    public class AddUserPage : BasePage
    {
        public MyWebElement _userRoleDropDown = new MyWebElement(By.XPath("//*[contains(@class,'oxd-input-group') and .//text()='User Role']//*[contains(@class, 'oxd-select-text--active')]"));
        public MyWebElement _employeeNameDropDown = new MyWebElement(By.XPath("//*[contains(@class,'oxd-input-group') and .//text()='Employee Name']//*[contains(@class, 'oxd-autocomplete-text-input')]/input"));
        public MyWebElement _employeeNameOption = new MyWebElement(By.XPath("//*[@role='option'][1]"));
        public MyWebElement _statusDropDown = new MyWebElement(By.XPath("//*[contains(@class,'oxd-input-group') and .//text()='Status']//*[contains(@class, 'oxd-select-text-input')]"));
        public MyWebElement _usernameTextBox = new MyWebElement(By.XPath("//*[contains(@class,'oxd-input-group') and .//text()='Username']/div/input"));
        public MyWebElement _passwordTextBox = new MyWebElement(By.XPath("//*[contains(@class,'oxd-input-group') and .//text()='Password']/div/input"));
        public MyWebElement _confirmPasswordTextBox = new MyWebElement(By.XPath("//*[contains(@class,'oxd-input-group') and .//text()='Confirm Password']/div/input"));
        public MyWebElement _saveButton = new MyWebElement(By.XPath("//*[@type='submit']"));

        public void SelectUserRole(string userRole)
        {
            var _userRoleOption = new MyWebElement(By.XPath($"//*[@role='option' and .//text()='{userRole}']"));

            _userRoleDropDown.Click();
            _userRoleOption.Click();
        }

        public void EnterEmployeeName(string employeeName)
        {
            _employeeNameDropDown.SendKeys(employeeName);
            Thread.Sleep(4000);//TODO change it later
            _employeeNameOption.Click();
        }

        public void SelectStatus(string status)
        {
            var _statusOption = new MyWebElement(By.XPath($"//*[@role='option' and .//text()='{status}']"));

            _statusDropDown.Click();
            _statusOption.Click();
        }

        public void EnterUsername(string username) => _usernameTextBox.SendKeys(username);

        public void EnterPassword(string password) => _passwordTextBox.SendKeys(password);

        public void EnterConfirmPassword(string password) => _confirmPasswordTextBox.SendKeys(password);

        public void ClickSaveButton() => _saveButton.Click();
    }
}
