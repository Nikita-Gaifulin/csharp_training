using NUnit.Framework;
using System.Collections.Generic;

namespace addressbookWebTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            int numberContact = 10;
            ContactData modifiedContact = new ContactData("Nikita", "Gayfulin");
            
            modifiedContact.Middlename = null;
           
            modifiedContact.Nickname = null;
            modifiedContact.Title = null;
            modifiedContact.Company = null;
            modifiedContact.Address = null;
            modifiedContact.Home = null;
            modifiedContact.Mobile = null;
            modifiedContact.Work = null;
            modifiedContact.Fax = null;
            modifiedContact.Email = null;
            modifiedContact.Email2 = null;
            modifiedContact.Email3 = null;
            modifiedContact.Homepage = null;
            modifiedContact.Bday = null;
            modifiedContact.Bmonth = null;
            modifiedContact.Byear = null;
            modifiedContact.Aday = null;
            modifiedContact.Amonth = null;
            modifiedContact.Ayear = null;
            modifiedContact.Address2 = null;
            modifiedContact.Phone2 = null;
            modifiedContact.Notes = null;

            app.Contacts.VerifyExistingContact(numberContact);

            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            
            app.Contacts.Modify(numberContact, modifiedContact);

            List<ContactData> newContacts = app.Contacts.GetContactsList();

            oldContacts[numberContact].FirstName = modifiedContact.FirstName;
            oldContacts[numberContact].Lastname = modifiedContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
        }
    }
}
