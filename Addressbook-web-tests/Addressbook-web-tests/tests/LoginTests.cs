using NUnit.Framework;

namespace addressbookWebTests
{
    [TestFixture]
    class LoginTests : TestBase
    {
        [Test]
        public void LoginValidCredentials()
        {
            //prepare
            app.Auth.Logout();
            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginInvalidCredentials()
        {
            //prepare
            app.Auth.Logout();
            //action
            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);
            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
