using OpenQA.Selenium;

namespace addressbookWebTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactsPage();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Auth.Logout();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        protected void FillContactForm(ContactData contact)
        {
            ClickTextBox("firstname", contact.FirstName);
            ClickTextBox("middlename", contact.Middlename);
            ClickTextBox("lastname", contact.Lastname);
            ClickTextBox("nickname", contact.Nickname);
            ClickTextBox("title", contact.Title);
            ClickTextBox("company", contact.Company);
            ClickTextBox("address", contact.Address);
            ClickTextBox("home", contact.Home);
            ClickTextBox("mobile", contact.Mobile);
            ClickTextBox("work", contact.Work);
            ClickTextBox("fax", contact.Fax);
            ClickTextBox("email", contact.Email);
            ClickTextBox("email2", contact.Email2);
            ClickTextBox("email3", contact.Email3);
            ClickTextBox("homepage", contact.Homepage);
            ClickDropdownList("bday", contact.Bday);
            ClickDropdownList("bmonth", contact.Bmonth);
            ClickTextBox("byear", contact.Byear);
            ClickDropdownList("aday", contact.Aday);
            ClickDropdownList("amonth", contact.Amonth);
            ClickTextBox("ayear", contact.Ayear);
            ClickTextBox("address2", contact.Address2);
            ClickTextBox("phone2", contact.Phone2);
            ClickTextBox("notes", contact.Notes);
        }
    }
}
