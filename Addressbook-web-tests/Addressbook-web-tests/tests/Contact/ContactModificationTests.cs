using NUnit.Framework;

namespace addressbookWebTests
{
    [TestFixture]
    class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData modifiedContact = new ContactData();
            modifiedContact.FirstName = "Nikita4";
            modifiedContact.Middlename = "Tester4";
            modifiedContact.Lastname = "Tester4";
            modifiedContact.Nickname = "Tester4";
            modifiedContact.Title = "Tester4";
            modifiedContact.Company = "Testers";
            modifiedContact.Address = "www";
            modifiedContact.Home = "home1";
            modifiedContact.Mobile = "99999";
            modifiedContact.Work = "88888";
            modifiedContact.Fax = "7865757";
            modifiedContact.Email = "sdfsd@dfsfd";
            modifiedContact.Email2 = "234dsfg@dsfs";
            modifiedContact.Email3 = "dsfsdf@dsfs.ry";
            modifiedContact.Homepage = "Tester";
            modifiedContact.Bday = "2";
            modifiedContact.Bmonth = "October";
            modifiedContact.Byear = "2074";
            modifiedContact.Aday = "3";
            modifiedContact.Amonth = "September";
            modifiedContact.Ayear = "2099";
            modifiedContact.Address2 = "sdfdsf";
            modifiedContact.Phone2 = "456546";
            modifiedContact.Notes = "fdgdfg";
            app.Contacts.Modify(2, modifiedContact);
        }
    }
}
