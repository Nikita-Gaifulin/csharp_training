using NUnit.Framework;

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
            newData.Header = "ooo";
            newData.Footer = "lll";
            app.Groups.VerifyExistingGroup(numberGroup);
            app.Groups.Modify(numberGroup, newData);
        }
    }
}
