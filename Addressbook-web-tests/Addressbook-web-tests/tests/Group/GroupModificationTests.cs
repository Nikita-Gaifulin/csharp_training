using NUnit.Framework;
using System.Collections.Generic;

namespace addressbookWebTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            int numberGroup = 10;
            GroupData newData = new GroupData("fff");
            newData.Header = null;
            newData.Footer = null;
            app.Groups.VerifyExistingGroup(numberGroup);

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[oldGroups.Count - numberGroup];

            app.Groups.Modify(numberGroup, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[numberGroup].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
