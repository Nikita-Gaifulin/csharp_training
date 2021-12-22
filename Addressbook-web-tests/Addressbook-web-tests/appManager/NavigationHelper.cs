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
            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContactsPage()
        {
            if (driver.Url == baseURL + "/addressbook/edit.php"
                && IsElementPresent(By.Name("photo")))
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/"
                && IsElementPresent(By.Name("selected[]")))
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
