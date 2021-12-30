using NUnit.Framework;
using System.Collections.Generic;

namespace addressbookWebTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            int numberGroup = 10;
            GroupData newData = new GroupData("fff");
            newData.Header = null;
            newData.Footer = null;
            app.Groups.VerifyExistingGroup(numberGroup);

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.Modify(numberGroup, newData);

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups[numberGroup].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
    }
}
