using NUnit.Framework;

namespace addressbookWebTests
{
    [TestFixture]
    public class ContactDetailInformaionTests : AuthTestBase
    {
        [Test]
        public void TestContactDetails()
        {
            int indexToVerify = 1;
            ContactData dataFromEditForm = app.Contacts.GetContactDetailInformationFromEditForm(indexToVerify);
            string dataFromDetails = app.Contacts.GetContactDetailInformationFromTable(indexToVerify);


            CollectionAssert.AreEqual(dataFromEditForm.AllData, dataFromDetails);

        }
    }
}
