using NUnit.Framework;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace GitHubAutomation
{
    [TestFixture]
    public class SmokeTests
    {
        private Steps.Steps steps = new Steps.Steps();
        private const string USERNAME = "i.valchenk@hotmail.com";
        private const string PASSWORD = "Self_Pity_11";
        private const string NEWNAME = "_TestName.rar";

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void OneCanLoginCopy()
        {
            steps.LoginCopy(USERNAME, PASSWORD);
            Assert.True(steps.IsLoggedIn(USERNAME));
        }

        [Test]
        public void OneCanCreateFolder()
        {
            steps.LoginCopy(USERNAME, PASSWORD);
            Assert.IsTrue(steps.CreateNewFolder("testFolder"));
        }

        [Test]
        public void OneCanShareFile()
        {
            steps.LoginCopy(USERNAME, PASSWORD);
            steps.ShareFile(USERNAME, "Hi, it's " + USERNAME + " checkout this archive.");
            Assert.True(steps.HasUserAccess(USERNAME));
        }

        [Test]
        public void OneCanRenameFile()
        {
            Console.WriteLine("Start RENAME test.");

            steps.LoginCopy(USERNAME, PASSWORD);
            steps.RenameFile(NEWNAME);
            Assert.True(steps.WasFileRenamed(NEWNAME));
        }

        [Test]
        public void OneCanLogout()
        {
            steps.LoginCopy(USERNAME, PASSWORD);
            steps.Logout();
            Assert.True(steps.WasLogout());
        }

    }
}
