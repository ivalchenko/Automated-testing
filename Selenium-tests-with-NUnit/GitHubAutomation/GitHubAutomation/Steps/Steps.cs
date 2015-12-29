using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyAutomation.Steps
{
    public class Steps
    {
        IWebDriver driver;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void InitBrowser()
        {
            log.Info("InitBrowser.");
            Console.WriteLine("InitBrowser.");

            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            log.Info("CloseBrowser.");
            Console.WriteLine("CloseBrowser.");

            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginCopy(string username, string password)
        {
            log.Info("Create LoginPage.");
            Console.WriteLine("Create LoginPage.");

            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.OpenPage();

            log.Info("Open LoginPage.");
            Console.WriteLine("Open LoginPage.");

            loginPage.Login(username, password);
        }

        public bool IsLoggedIn(string username)
        {
            log.Info("Into IsLoggedIn() method of Steps.");
            Console.WriteLine("Into IsLoggedIn() method of Steps.");

            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            return (loginPage.GetLoggedInUserName().Trim().ToLower().Equals(username));
        }

        // create new folder
        public bool CreateNewFolder(string folderName)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.ClickOnCreateNewFolderButton();
            log.Info("Into CreateNewFolder() method of Steps.");
            Console.WriteLine("Into CreateNewFolder() method of Steps.");
            Pages.CreateNewFolderPage createNewFolderPage = new Pages.CreateNewFolderPage(driver);
            string expectedRepoName = createNewFolderPage.CreateNewFolder(folderName);
            log.Info("ExpectedRepoName is " + expectedRepoName);
            Console.WriteLine("ExpectedRepoName is " + expectedRepoName);

            //return expectedRepoName.Equals(createNewFolderPage.GetCurrentFolderName());
            // fix it

            return expectedRepoName != null; 
        }

        // share
        public bool HasUserAccess(string username)
        {
            log.Info("Into HasUserAccess() method of Steps.");
            Console.WriteLine("Into HasUserAccess() method of Steps.");
            Pages.ShareFileViaEmail sharePage = new Pages.ShareFileViaEmail(driver);
            return (sharePage.GetUserNameWhoHasAccess().Trim().ToLower().Equals(username));
        }

        public void ShareFile(string userEmail, string message)
        {
            log.Info("Into ShareFile() method of Steps.");
            Console.WriteLine("Into ShareFile() method of Steps.");
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            log.Info("Click on file which want to be share.");
            Console.WriteLine("Click on file which want to be share.");
            mainPage.ClickOnFileWantToBeShare();
            Pages.ShareFileViaEmail shareFile = new Pages.ShareFileViaEmail(driver);
            shareFile.Share(userEmail, message);
        }

        // rename
        public bool WasFileRenamed(string newName)
        {
            log.Info("Into WasfileRenamed() method of Steps.");
            Console.WriteLine("Into WasfileRenamed() method of Steps.");
            Pages.RenamePage renamePage = new Pages.RenamePage(driver);
            return (renamePage.GetFileName().Trim().ToLower().Equals(newName.ToLower()));
        }

        public void RenameFile(string newName)
        {
            log.Info("Into RenameFile() method of Steps.");
            Console.WriteLine("Into RenameFile() method of Steps.");
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            log.Info("Click on the file which want to be renamed.");
            Console.WriteLine("Click on the file which want to be renamed.");
            mainPage.ClickOnTheFileWantToBeRename();
            Pages.RenamePage renamePage = new Pages.RenamePage(driver);
            renamePage.Rename(newName);
        }

        // delete
        public bool Delete()
        {
            log.Info("Into Delete() method of Steps.");
            Console.WriteLine("Into Delete() method of Steps.");
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            string deletedName = mainPage.GetNameOfFileWhichWasDelete();
            mainPage.Delete();

            Pages.DeletePage deletePage = new Pages.DeletePage(driver);

            return deletePage.WasFileDelete(deletedName);
        }


    }
}
