using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssues : TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            { 
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                Id = "1"
            };
            IssueData issueData = new IssueData()
            {
                Summary = "some text",
                Description = "some long text",
                Category = "General"
        };
            application.Api.CreateNewIssue(account, project, issueData);
        }
    }
}
