using OpenQA.Selenium;

namespace addressbookWebTests
{
    public class NavigationHelper : HelperBase
    {
        string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void OpenAddressbook()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContactsPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
