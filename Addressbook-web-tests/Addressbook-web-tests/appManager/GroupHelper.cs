using System.Collections.Generic;
using OpenQA.Selenium;

namespace addressbookWebTests
{
    public class GroupHelper : HelperBase
    {
        private List<GroupData> groupCache = null;

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Remove(int numberGroup)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(numberGroup);
            DeleteGroup();
        }

        public GroupHelper Modify(int numberGroup, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(numberGroup);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            return this;
        }

        public List<GroupData> GetGroupsList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }

                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else
                    {
                        groupCache[i].Name = parts[i-shift].Trim();
                    }
                }
            }
            
            return new List<GroupData>(groupCache);
        }


        public int GetGroupCount()
        {
            manager.Navigator.GoToGroupsPage();
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index + 1) + "]/input")).Click();
            return this;
        }

        public GroupHelper VerifyExistingGroup(int numberGroup)
        {
            manager.Navigator.GoToGroupsPage();
            while (!IsGroupsExisted(numberGroup + 1))
            {
                GroupData emptyData = new GroupData("");
                Create(emptyData);
                manager.Navigator.GoToGroupsPage();
            }
            return this;
        }

        bool IsGroupsExisted(int numberGroup)
        {
            if (IsElementPresent(By.XPath("//div[@id='content']/form/span[" + numberGroup + "]/input")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            ClickTextBox(By.Name("group_name"), group.Name);
            ClickTextBox(By.Name("group_header"), group.Header);
            ClickTextBox(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
    }
}
