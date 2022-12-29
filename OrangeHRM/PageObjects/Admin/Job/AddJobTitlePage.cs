using OpenQA.Selenium;

namespace OrangeHRM.PageObjects.Admin.Job
{
    public class AddJobTitlePage : BasePage
    {
        public MyWebElement _jobTitleTextBox = new MyWebElement(By.XPath("//*[contains(@class,'oxd-input-group') and .//text()='Job Title']/div/input"));
        public MyWebElement _jobDescriptionTextBox = new MyWebElement(By.XPath("//*[contains(@class,'oxd-input-group') and div/label/text()='Job Description']/div/textarea"));
        public MyWebElement _saveButton = new MyWebElement(By.XPath("//*[@type='submit']"));

        public void EnterJobTitle(string jobTitle) => _jobTitleTextBox.SendKeys(jobTitle);

        public void EnterJobDescription(string jobDescription) => _jobDescriptionTextBox.SendKeys(jobDescription);

        public void ClickSaveButton() => _saveButton.Click();
    }
}
