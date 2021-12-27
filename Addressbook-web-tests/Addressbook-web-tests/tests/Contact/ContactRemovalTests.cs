using NUnit.Framework;

namespace addressbookWebTests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int numberContact = 10;
            app.Contacts.VerifyExistingContact(numberContact);
            app.Contacts.Remove(numberContact);
        }
    }
}
