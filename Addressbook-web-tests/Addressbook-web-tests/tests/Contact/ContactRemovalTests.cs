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

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData contactToRemove = oldContacts[oldContacts.Count - numberContact];

            app.Contacts.Remove(contactToRemove);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.Remove(contactToRemove);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (var contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, contactToRemove.Id);
            }
        }
    }
}
