using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        public static Random r = new Random();

        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData("administrator", "root");

            ProjectData project = new ProjectData()
            {
                Name = $"Test num {r.Next(0, 999)}",
                Description = "Place for description",
            };

            application.Login.Login(account);
            application.Navigate.OpenProjectMenu();

            List<ProjectData> oldData = application.Project.GetProjectList(account);

            application.Project.Create(project, account);

            List<ProjectData> newData = application.Project.GetProjectList(account);

            Assert.AreEqual(oldData.Count + 1, newData.Count);

            oldData.Add(project);

            oldData.Sort();
            newData.Sort();

            Assert.AreEqual(oldData, newData);
        }
    }
}