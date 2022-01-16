using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace addressbookWebTests
{
    public class ContactHelper : HelperBase
    {
        private List<ContactData> contactCache = null;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones,
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone1 = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string homePhone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                Home = homePhone1,
                Mobile = mobilePhone,
                Work = workPhone,
                Phone2 = homePhone2,
                Email = email,
                Email2 = email2,
                Email3 = email3,
            };
        }

        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactsPage();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }
        public void Remove(int numberContact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(numberContact);
            DeleteContact();
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

        public List<ContactData> GetContactsList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[name='entry']"));
                
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text));
                }
            }   
            
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            manager.Navigator.GoToHomePage();
            return driver.FindElements(By.CssSelector("[name='entry']")).Count;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tr[" + (index + 1) + "]/td/input")).Click();
            return this;
        }

        public ContactHelper VerifyExistingContact(int numberContact)
        {
            manager.Navigator.GoToHomePage();
            while(!IsContactsExisted(numberContact))
            {
                ContactData emptyContact = new ContactData("", "");
                Create(emptyContact);
                manager.Navigator.GoToHomePage();
            }
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper EditContactCreation(int numberContact)
        {
            driver.FindElement(By.XPath("//tr[" + (numberContact + 1) + "]/td[8]/a/img")).Click();
            return this;
        }

        bool IsContactsExisted(int numberContact)
        {
            if (IsElementPresent(By.XPath("//tr[" + (numberContact + 1) + "]/td/input")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        protected void FillContactForm(ContactData contact)
        {
            ClickTextBox(By.Name("firstname"), contact.FirstName);
            ClickTextBox(By.Name("middlename"), contact.Middlename);
            ClickTextBox(By.Name("lastname"), contact.Lastname);
            ClickTextBox(By.Name("nickname"), contact.Nickname);
            ClickTextBox(By.Name("title"), contact.Title);
            ClickTextBox(By.Name("company"), contact.Company);
            ClickTextBox(By.Name("address"), contact.Address);
            ClickTextBox(By.Name("home"), contact.Home);
            ClickTextBox(By.Name("mobile"), contact.Mobile);
            ClickTextBox(By.Name("work"), contact.Work);
            ClickTextBox(By.Name("fax"), contact.Fax);
            ClickTextBox(By.Name("email"), contact.Email);
            ClickTextBox(By.Name("email2"), contact.Email2);
            ClickTextBox(By.Name("email3"), contact.Email3);
            ClickTextBox(By.Name("homepage"), contact.Homepage);
            ClickDropdownList(By.Name("bday"), contact.Bday);
            ClickDropdownList(By.Name("bmonth"), contact.Bmonth);
            ClickTextBox(By.Name("byear"), contact.Byear);
            ClickDropdownList(By.Name("aday"), contact.Aday);
            ClickDropdownList(By.Name("amonth"), contact.Amonth);
            ClickTextBox(By.Name("ayear"), contact.Ayear);
            ClickTextBox(By.Name("address2"), contact.Address2);
            ClickTextBox(By.Name("phone2"), contact.Phone2);
            ClickTextBox(By.Name("notes"), contact.Notes);
        }
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
