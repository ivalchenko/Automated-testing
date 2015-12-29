using NUnit.Framework;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CopyAutomation
{
    [TestFixture]
    public class SmokeTests
    {
        private Steps.Steps steps = new Steps.Steps();
        private const string USERNAME = "i.valchenk@hotmail.com";
        private const string PASSWORD = "Self_Pity_11";
        private const string NEWNAME = "_TestName.rar";

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
            log.Info("Browser was successfully started.");
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
            log.Info("Browser was successfully closed.");
        }

        [Test]
        public void OneCanLoginCopy()
        {
            log.Info("\n\nStart Test 'OneCanLoginCopy()'.");

            steps.LoginCopy(USERNAME, PASSWORD);
            Assert.True(steps.IsLoggedIn(USERNAME));

            if (steps.IsLoggedIn(USERNAME) == false)
                log.Error("User is logged-out.");
            else
                log.Info("Test was successfully completed. User is logged-in.");
        }

        [Test]
        public void OneCanCreateFolder()
        {
            log.Info("\n\nStart Test 'OneCanCreateFolder()'.");

            steps.LoginCopy(USERNAME, PASSWORD);
            Assert.IsTrue(steps.CreateNewFolder("testFolder"));

            if (steps.CreateNewFolder("testFolder") == false)
                log.Error("Failed to create folder.");
            else
                log.Info("Test was successfully completed. Folder was successfully created.");
        }

        [Test]
        public void OneCanShareFile()
        {
            log.Info("\n\nStart Test 'OneCanShareFile()'.");

            steps.LoginCopy(USERNAME, PASSWORD);
            steps.ShareFile(USERNAME, "Hi, it's " + USERNAME + " checkout this archive.");
            Assert.True(steps.HasUserAccess(USERNAME));

            if (steps.HasUserAccess(USERNAME) == false)
                log.Error("User don't have access.");
            else
                log.Info("Test was successfully completed. File was shared.");
        }

        [Test]
        public void OneCanRenameFile()
        {
            log.Info("\n\nStart Test 'OneCanRenameFile()'.");

            steps.LoginCopy(USERNAME, PASSWORD);
            steps.RenameFile(NEWNAME);
            Assert.True(steps.WasFileRenamed(NEWNAME));

            if (steps.WasFileRenamed(NEWNAME) == false)
                log.Error("File hasn't been renamed.");
            else
                log.Info("Test was successfully completed. File was successfully renamed.");
        }

        [Test]
        public void OneCanDelete()
        {
            log.Info("\n\nStart Test 'OneCanDelete()'.");

            steps.LoginCopy(USERNAME, PASSWORD);
            Assert.True(steps.Delete());

            if (steps.Delete() == false)
                log.Error("The file was not deleted.");
            else
                log.Info("Test was successfully completed. File was successfully deleted.");
        }
    }
}
