using OpenQA.Selenium;

namespace OrangeHRM.PageObjects.Admin.Job
{
    public class JobTitlesPage : BasePage
    {
        private MyWebElement _allRows = new MyWebElement(By.XPath("//*[@class='oxd-table-card']"));
        private MyWebElement _allRowsJobTitles = new MyWebElement(By.XPath("//*[@class='oxd-table-card']//*[contains(@class,'oxd-table-cell')][count(//*[@role='columnheader' and text()='Job Titles']/preceding-sibling::*)+1]/div"));
        private MyWebElement _allRowsJobDescriptions = new MyWebElement(By.XPath("//*[@class='oxd-table-card']//*[contains(@class,'oxd-table-cell')][count(//*[@role='columnheader' and text()='Job Description']/preceding-sibling::*)+1]/div"));
        private MyWebElement _recordsFound = new MyWebElement(By.XPath("//*[contains(@class,'orangehrm-horizontal-padding')]/span"));
        private MyWebElement _addButton = new MyWebElement(By.XPath("//*[@type='button' and .//text()=' Add ']"));
        private MyWebElement _lastRowTrashIcon = new MyWebElement(By.XPath("//*[@class='oxd-table-card'][last()]//*[contains(@class,'oxd-table-cell')][count(//*[@role='columnheader' and text()='Actions']/preceding-sibling::*)+1]/div/button[./i[contains(@class,'bi-trash')]]"));
        private MyWebElement _lastRowJobTitle = new MyWebElement(By.XPath("//*[@class='oxd-table-card'][last()]//*[contains(@class,'oxd-table-cell')][count(//*[@role='columnheader' and text()='Job Titles']/preceding-sibling::*)+1]/div"));
        private MyWebElement _confirmDeletionButton = new MyWebElement(By.XPath("//*[@type='button' and text()=' Yes, Delete ']"));
        private MyWebElement _sortJobTitlesButton = new MyWebElement(By.XPath("//*[@role='columnheader' and text()='Job Titles']/div/i"));
        private MyWebElement _sortASCButton = new MyWebElement(By.XPath("//*[@class='oxd-table-header-sort-dropdown-item' and .//text()='Ascending']"));
        private MyWebElement _sortDESCButton = new MyWebElement(By.XPath("//*[@class='oxd-table-header-sort-dropdown-item' and .//text()='Decending']"));

        public int CountAllRows() => _allRows.GetAmountOfElements();

        public string GetRecordsFoundText() => _recordsFound.Text;

        public void ClickAddButton() => _addButton.Click();

        public void DeleteLastElement()
        {
            _lastRowTrashIcon.Click();
            _confirmDeletionButton.Click();
        }

        public string GetLastRawUsername() => _lastRowJobTitle.Text;

        public string GetRowsJobTitleText(int index) => _allRowsJobTitles.GetElementAt(index).Text;

        public string GetRowsJobDescriptionText(int index) => _allRowsJobDescriptions.GetElementAt(index).Text;

        public void EditAppropriateJob(string jobTitleName)
        {
            var jobTitleXPathLocator = new MyWebElement(By.XPath($"//*[@class='oxd-table-card'][.//text()='{jobTitleName}']//*[contains(@class,'oxd-table-cell')][count(//*[@role='columnheader' and text()='Actions']/preceding-sibling::*)+1]/div/button[./i[contains(@class,'bi-pencil-fill')]]"));

            jobTitleXPathLocator.Click();
        }

        public void SortJobTitlesAsc()
        {
            _sortJobTitlesButton.Click();
            _sortASCButton.Click();
        }

        public void SortJobTitlesDesc()
        {
            _sortJobTitlesButton.Click();
            _sortDESCButton.Click();
        }
    }
}
