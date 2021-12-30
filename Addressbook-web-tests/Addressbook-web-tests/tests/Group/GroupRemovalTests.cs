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
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.RemoveAt(numberGroup);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
