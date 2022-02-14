using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData("administrator", "root");
            ProjectData project = new ProjectData()
            {
                Name = "Test",
                Description = "Create Test Automatically",
            };
            application.Login.Login(account);
            application.Navigate.OpenProjectMenu();
            List<ProjectData> oldData = application.Project.GetProjectList();

            application.Project.Create(project, account);

            List<ProjectData> newData = application.Project.GetProjectList();

            Assert.AreEqual(oldData.Count + 1, newData.Count);

            oldData.Add(project);

            oldData.Sort();
            newData.Sort();

            Assert.AreEqual(oldData, newData);
        }
    }
}