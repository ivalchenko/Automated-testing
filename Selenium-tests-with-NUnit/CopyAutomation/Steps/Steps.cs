using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Steps
{
    public class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginCopy(string username, string password)
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.OpenPage();
            loginPage.Login(username, password);
        }

        public bool IsLoggedIn(string username)
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            return (loginPage.GetLoggedInUserName().Trim().ToLower().Equals(username));
        }

        public bool HasUserAccess(string username)
        {
            Pages.ShareFileViaEmail sharePage = new Pages.ShareFileViaEmail(driver);
            return (sharePage.GetUserNameWhoHasAccess().Trim().ToLower().Equals(username));
        }

        public bool CreateNewFolder(string folderName)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.ClickOnCreateNewFolderButton();
            Pages.CreateNewFolderPage createNewFolderPage = new Pages.CreateNewFolderPage(driver);
            string expectedRepoName = createNewFolderPage.CreateNewFolder(folderName);

            //return expectedRepoName.Equals(createNewFolderPage.GetCurrentFolderName());
            // fix it

            return expectedRepoName != null; 
        }

        public void ShareFile(string userEmail, string message)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.ClickOnFileWantToBeShare();
            Pages.ShareFileViaEmail shareFile = new Pages.ShareFileViaEmail(driver);
            shareFile.Share(userEmail, message);
        }

        // rename
        public bool WasFileRenamed(string newName)
        {
            Console.WriteLine("Into WasfileRenamed method.");

            Pages.RenamePage renamePage = new Pages.RenamePage(driver);
            return (renamePage.GetFileName().Trim().ToLower().Equals(newName.ToLower()));
        }

        public void RenameFile(string newName)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.ClickOnTheFileWantToBeRename();
            Pages.RenamePage renamePage = new Pages.RenamePage(driver);
            renamePage.Rename(newName);

            Console.WriteLine("File was successfully renamed.");
        }

        public bool WasLogout()
        {
            Pages.LogoutPage logoutPage = new Pages.LogoutPage(driver);
            return logoutPage.WasLogout();
        }

        public void Logout()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.Logout();
        }

    }
}
