using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    class AccountCreationTests : TestBase
    {
        [SetUp]
        public void setUpConfig()
        {
            string localPath = TestContext.CurrentContext.TestDirectory + @"\config_inc.php";
            application.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open(localPath, FileMode.Open))
            {
                application.Ftp.Upload("/config_inc.php", localFile);
            }
        }

        public static Random r = new Random();

        [Test]
        public void TestAccontRegistration()
        {
            int uniqueNumber = r.Next(0, 999);
            AccountData account = new AccountData()
            {
                Name = $"testuser{uniqueNumber}",
                Password = "password",
                Email = $"testuser{uniqueNumber}@localhost.localdomain"
            };

            List<AccountData> accounts = application.Admin.GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);

            if (existingAccount != null)
            {
                application.Admin.DeleteAccount(existingAccount);
            }
            

            application.James.Delete(account);
            application.James.Add(account);

            application.Registration.Register(account);
        }

        [TearDown]
        public void restoreConfig()
        {
            application.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}