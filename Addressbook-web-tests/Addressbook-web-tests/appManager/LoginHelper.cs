using OpenQA.Selenium;

namespace addressbookWebTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) 
        {
            this.driver = manager.Driver;
        }
        public void Login(AccountData account)
        {
            ClickTextBox("user", account.Username);
            ClickTextBox("pass", account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
