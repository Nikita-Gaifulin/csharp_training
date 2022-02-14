using OpenQA.Selenium;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager) : base(manager) { }

        public void OpenProjectMenu()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.2/manage_proj_page.php");
            //doesnt work
            //driver.FindElement(By.XPath("//a[@href= '/mantisbt-2.25.2/manage_overview_page.php']")).Click();
            //driver.FindElement(By.XPath("//a[@href= '/mantisbt-2.25.2/manage_proj_page.php']")).Click();
        }
    }
}