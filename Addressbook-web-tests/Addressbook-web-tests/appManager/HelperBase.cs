using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace addressbookWebTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }
        public void ClickTextBox(string elementsTag, string elementsName)
        {
            driver.FindElement(By.Name(elementsTag)).Click();
            driver.FindElement(By.Name(elementsTag)).Clear();
            driver.FindElement(By.Name(elementsTag)).SendKeys(elementsName);
        }

        public void ClickDropdownList(string elementsTag, string elementsName)
        {
            driver.FindElement(By.Name(elementsTag)).Click();
            new SelectElement(driver.FindElement(By.Name(elementsTag))).SelectByText(elementsName);
        }
    }
}