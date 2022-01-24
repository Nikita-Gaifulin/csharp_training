using NUnit.Framework;

namespace addressbookWebTests
{
    [TestFixture]
    class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            ContactData fromTable = app.Contacts.GetContactBriefInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactBriefInformationFromEditForm(0);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }
    }
}
