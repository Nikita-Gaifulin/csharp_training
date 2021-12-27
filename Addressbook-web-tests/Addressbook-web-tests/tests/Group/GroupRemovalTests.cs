using NUnit.Framework;

namespace addressbookWebTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int numberGroup = 10;
            app.Groups.VerifyExistingGroup(numberGroup);
            app.Groups.Remove(numberGroup);
        }
    }
}
