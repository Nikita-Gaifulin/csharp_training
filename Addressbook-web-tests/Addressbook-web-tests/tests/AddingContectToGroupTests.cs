using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbookWebTests
{
    public class AddingContectToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> groupList = GroupData.GetAll();
            List<ContactData> contactList = ContactData.GetAll();
            ContactData newContactData = new ContactData("AddedTo", $"AddingToGroup{R.Next(0, 100)}");
            GroupData newGroupData = new GroupData("Automatic Creation");

            // Checks if groups & contacts exist at all
            if (groupList.Count == 0)
            {
                app.Groups.Create(newGroupData);

                if (contactList.Count == 0)
                {
                    app.Contacts.Create(newContactData);
                }
            }
            if (contactList.Count == 0)
            {
                app.Contacts.Create(newContactData);
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            if (oldList.SequenceEqual(ContactData.GetAll()))
            {
                app.Contacts.Create(newContactData);
            }
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
