using NUnit.Framework;
using System.Collections.Generic;

namespace addressbookWebTests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int numberContact = 1;
            app.Contacts.VerifyExistingContact(numberContact);

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Remove(numberContact);

            List<ContactData> newContacts = app.Contacts.GetContactsList();

            oldContacts.RemoveAt(numberContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);

        }
    }
}
