﻿using System.Collections.Generic;
using NUnit.Framework;

namespace addressbookWebTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ddd";
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a ' a");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
    }
}