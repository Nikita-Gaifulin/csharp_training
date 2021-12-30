using NUnit.Framework;
using System.Collections.Generic;

namespace addressbookWebTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Nikita", "Gayfulin");

            contact.Middlename = null;

            contact.Nickname = null;
            contact.Title = null;
            contact.Company = null;
            contact.Address = null;
            contact.Home = null;
            contact.Mobile = null;
            contact.Work = null;
            contact.Fax = null;
            contact.Email = null;
            contact.Email2 = null;
            contact.Email3 = null;
            contact.Homepage = null;
            contact.Bday = null;
            contact.Bmonth = null;
            contact.Byear = null;
            contact.Aday = null;
            contact.Amonth = null;
            contact.Ayear = null;
            contact.Address2 = null;
            contact.Phone2 = null;
            contact.Notes = null;

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactsList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
        }
    }
}
