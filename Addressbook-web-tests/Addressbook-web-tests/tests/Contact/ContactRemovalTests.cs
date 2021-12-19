using NUnit.Framework;

namespace addressbookWebTests
{
    [TestFixture]
    class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove(1);
        }
    }
}
