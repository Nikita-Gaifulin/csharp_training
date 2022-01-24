using NUnit.Framework;

namespace addressbookWebTests
{
    [TestFixture]
    public class ContactDetailInformaionTests : AuthTestBase
    {
        [Test]
        public void ContactDetailInformationTest()
        {
            ContactData fromEditForm = app.Contacts.GetContactDetailInformationFromEditForm(0);
            string[] detailsFromTable = app.Contacts.GetContactDetailInformationFromTable(0);
            CollectionAssert.AreEqual(detailsFromTable, fromEditForm.Details);
        }
    }
}
