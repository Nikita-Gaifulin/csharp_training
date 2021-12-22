using NUnit.Framework;

namespace addressbookWebTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData();
            contact.FirstName = "Nikita";
            contact.Middlename = "Tester1";
            contact.Lastname = "Tester2";
            contact.Nickname = "Tester3";
            contact.Title = "Tester4";
            contact.Company = "Testers";
            contact.Address = "www";
            contact.Home = "home1";
            contact.Mobile = "99999";
            contact.Work = "88888";
            contact.Fax = "7865757";
            contact.Email = "sdfsd@dfsfd";
            contact.Email2 = "234dsfg@dsfs";
            contact.Email3 = "dsfsdf@dsfs.ry";
            contact.Homepage = "Tester";
            contact.Bday = "2";
            contact.Bmonth = "October";
            contact.Byear = "2074";
            contact.Aday = "3";
            contact.Amonth = "September";
            contact.Ayear = "2099";
            contact.Address2 = "sdfdsf";
            contact.Phone2 = "456546";
            contact.Notes = "fdgdfg";
            app.Contacts.Create(contact);
        }
    }
}
