using OpenQA.Selenium;

namespace addressbookWebTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Remove(int numberGroup)
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsGroupsExisted())
            {
                GroupData emptyData = new GroupData("");
                Create(emptyData);
            }
            SelectGroup(numberGroup);
            DeleteGroup();
        }

        public GroupHelper Modify(int numberGroup, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsGroupsExisted())
            {
                GroupData emptyData = new GroupData("");
                emptyData.Header = "";
                emptyData.Footer = "";
                Create(emptyData);
            }
            SelectGroup(numberGroup);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
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
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }

        bool IsGroupsExisted()
        {
            if (IsElementPresent(By.Name("selected[]")))
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
