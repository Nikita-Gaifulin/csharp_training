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
        public void Remove(int numberContact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(numberContact);
            DeleteContact();
            manager.Auth.Logout();
        }

        public ContactHelper Modify(int numberContact, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(numberContact);
            EditContactCreation(numberContact);
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tr[" + (index + 1) + "]/td/input")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper EditContactCreation(int numberContact)
        {
            driver.FindElement(By.XPath("//tr[" + (numberContact + 1) + "]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
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
