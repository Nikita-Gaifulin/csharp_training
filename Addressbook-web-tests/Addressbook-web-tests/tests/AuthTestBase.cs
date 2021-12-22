using NUnit.Framework;

namespace addressbookWebTests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
        }
    }
}
