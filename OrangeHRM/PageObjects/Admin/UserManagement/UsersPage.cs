using OpenQA.Selenium;

namespace OrangeHRM.PageObjects.Admin.UserManagement
{
    public class UsersPage : BasePage
    {
        private MyWebElement _allRows = new MyWebElement(By.XPath("//*[@class='oxd-table-card']"));
        private MyWebElement _allRowsUsernames = new MyWebElement(By.XPath("//*[@class='oxd-table-card']//*[contains(@class,'oxd-table-cell')][count(//*[@role='columnheader' and text()='Username']/preceding-sibling::*)+1]/div"));
        private MyWebElement _allRowsStatuses = new MyWebElement(By.XPath("//*[@class='oxd-table-card']//*[contains(@class,'oxd-table-cell')][count(//*[@role='columnheader' and text()='Status']/preceding-sibling::*)+1]/div"));
        private MyWebElement _allRowsUserRoles = new MyWebElement(By.XPath("//*[@class='oxd-table-card']//*[contains(@class,'oxd-table-cell')][count(//*[@role='columnheader' and text()='User Role']/preceding-sibling::*)+1]/div"));
        private MyWebElement _recordsFound = new MyWebElement(By.XPath("//*[contains(@class,'orangehrm-horizontal-padding')]/span"));
        private MyWebElement _addButton = new MyWebElement(By.XPath("//*[@type='button' and .//text()=' Add ']"));
        private MyWebElement _lastRowTrashIcon = new MyWebElement(By.XPath("//*[@class='oxd-table-card'][last()]//*[contains(@class,'oxd-table-cell')][count(//*[@role='columnheader' and text()='Actions']/preceding-sibling::*)+1]/div/button[./i[contains(@class,'bi-trash')]]"));
        private MyWebElement _lastRowUsername = new MyWebElement(By.XPath("//*[@class='oxd-table-card'][last()]//*[contains(@class,'oxd-table-cell')][count(//*[@role='columnheader' and text()='Username']/preceding-sibling::*)+1]/div"));
        private MyWebElement _confirmDeletionButton = new MyWebElement(By.XPath("//*[@type='button' and text()=' Yes, Delete ']"));
        private MyWebElement _searchByFieldTextField = new MyWebElement(By.XPath("//*[contains(@class,'oxd-input') and .//text()='Username']/div/input"));
        private MyWebElement _searchButton = new MyWebElement(By.XPath("//*[@type='submit']"));
        public MyWebElement _userRoleDropDown = new MyWebElement(By.XPath("//*[contains(@class,'oxd-input-group') and .//text()='User Role']//*[contains(@class, 'oxd-select-text--active')]"));
        public MyWebElement _statusDropDown = new MyWebElement(By.XPath("//*[contains(@class,'oxd-input-group') and .//text()='Status']//*[contains(@class, 'oxd-select-text-input')]"));

        public int CountAllRows() => _allRows.GetAmountOfElements();

        public string GetRecordsFoundText() => _recordsFound.Text;

        public void ClickAddButton() => _addButton.Click();

        public void DeleteLastElement()
        {
            _lastRowTrashIcon.Click();
            _confirmDeletionButton.Click();
        }

        public void EnterTextInUserNameField(string username) => _searchByFieldTextField.SendKeys(username);

        public void SearchForUser() => _searchButton.Click();

        public string GetLastRawUsername() => _lastRowUsername.Text;

        public string GetRowsUsernameText(int index) => _allRowsUsernames.GetElementAt(index).Text;

        public string GetRowsStatusText(int index) => _allRowsStatuses.GetElementAt(index).Text;

        public string GetRowsUserRolesText(int index) => _allRowsUserRoles.GetElementAt(index).Text;


        public void EditAppropriateUser(string username)
        {
            var usernameXPathLocator = new MyWebElement(By.XPath($"//*[@class='oxd-table-card'][.//text()='{username}']//*[contains(@class,'oxd-table-cell')][count(//*[@role='columnheader' and text()='Actions']/preceding-sibling::*)+1]/div/button[./i[contains(@class,'bi-pencil-fill')]]"));

            usernameXPathLocator.Click();
        }

        public void SelectUserRole(string userRole)
        {
            var _userRoleOption = new MyWebElement(By.XPath($"//*[@role='option' and .//text()='{userRole}']"));

            _userRoleDropDown.Click();
            _userRoleOption.Click();
        }

        public void SelectStatus(string status)
        {
            var _statusOption = new MyWebElement(By.XPath($"//*[@role='option' and .//text()='{status}']"));

            _statusDropDown.Click();
            _statusOption.Click();
        }
    }
}
