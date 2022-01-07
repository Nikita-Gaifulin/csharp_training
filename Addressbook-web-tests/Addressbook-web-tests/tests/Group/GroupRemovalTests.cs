using NUnit.Framework;
using System.Collections.Generic;

namespace addressbookWebTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int numberGroup = 0;
            app.Groups.VerifyExistingGroup(numberGroup);
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            app.Groups.Remove(numberGroup);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(numberGroup);
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
