using NUnit.Framework;

namespace addressbookWebTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("fff");
            newData.Header = "ooo";
            newData.Footer = "lll";
            app.Groups.Modify(1, newData);
        }
    }
}
