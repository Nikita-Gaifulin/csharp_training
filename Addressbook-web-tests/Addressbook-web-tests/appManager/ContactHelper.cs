using OpenQA.Selenium;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;

namespace addressbookWebTests
{
    public class ContactHelper : HelperBase
    {
        private List<ContactData> contactCache = null;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactData GetContactBriefInformationFromTable(int index)
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

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        private ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='" + id + "']")).Click();
            return this;
        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupInFilter(group.Name);
            SelectContact(contact.Id);
            CommitRemovingFromGroup();
        }

        private void CommitRemovingFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void SelectGroupInFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public string GetContactDetailInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            manager.Navigator.GoToDetails(index);

            string allData = driver.FindElement(By.XPath("//div[@id='content']")).Text;

            return allData;
        }

        public ContactData GetContactBriefInformationFromEditForm(int index)
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

        public ContactData GetContactDetailInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");

            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");

            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone1 = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string homePhone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string bday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");

            string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string amonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            amonth = char.ToUpper(amonth[0]) + amonth.Substring(1);

            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Middlename = middleName,
                Nickname = nickName,
                Company = company,
                Title = title,
                Address = address,
                Home = homePhone1,
                Mobile = mobilePhone,
                Work = workPhone,
                Fax = fax,
                Phone2 = homePhone2,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homepage,
                Bday = bday,
                Bmonth = bmonth,
                Byear = byear,
                Aday = aday,
                Amonth = amonth,
                Ayear = ayear,
                Address2 = address2,
                Notes = notes,
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

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(contact.Id);
            DeleteContact();
            return this;
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

        public ContactHelper Modify(ContactData contact, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(contact.Id);
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        private ContactHelper InitContactModification(string id)
        {
            driver.FindElement(By.XPath("//tr[./td[./input[@name='selected[]' and @value='" + id + "']]]"))
               .FindElement(By.XPath(".//img[@alt='Edit']")).Click();

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
            ClickTextBox(By.Name("firstname"), contact.Firstname);
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
