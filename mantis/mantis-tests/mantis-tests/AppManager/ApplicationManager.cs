using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public static ThreadLocal<ApplicationManager> application = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=en");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            baseURL = "http://localhost";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Login = new LoginLogoutHelper(this);
            Navigate = new NavigationHelper(this);
            Project = new ProjectHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!application.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.25.2/mantisbt-2.25.2/login_page.php";
                application.Value = newInstance;
            }
            return application.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public RegistrationHelper Registration { get; set; }
        public MailHelper Mail { get; set; }
        public LoginLogoutHelper Login { get; set; }
        public NavigationHelper Navigate { get; set; }
        public ProjectHelper Project { get; set; }
    }
}