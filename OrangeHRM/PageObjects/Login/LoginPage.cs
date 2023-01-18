using OpenQA.Selenium;

namespace OrangeHRM.PageObjects.Login
{
    public class LoginPage
    {
        private MyWebElement _usernameTextBox = new MyWebElement(By.XPath("//*[@name='username']"));
        private MyWebElement _passwordTextBox = new MyWebElement(By.XPath("//*[@name='password']"));
        private MyWebElement _loginButton = new MyWebElement(By.XPath("//*[@type='submit']"));

        public void EnterUserName(string username) => _usernameTextBox.SendKeys(username);

        public void EnterPassword(string password) => _passwordTextBox.SendKeys(password);

        public void ClickLoginButton() => _loginButton.Click();
    }
}
