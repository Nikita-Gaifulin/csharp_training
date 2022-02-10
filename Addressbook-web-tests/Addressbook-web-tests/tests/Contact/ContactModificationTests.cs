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

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldContactData = oldContacts[numberContact - 1];

            app.Contacts.Modify(oldContactData, modifiedContact);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts[numberContact - 1].Firstname = modifiedContact.Firstname;
            oldContacts[numberContact - 1].Lastname = modifiedContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (var contact in newContacts)
            {
                if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual($"{modifiedContact.Lastname} {modifiedContact.Firstname}", $"{contact.Lastname} {contact.Firstname}");
                }
            }
        }
    }
}
