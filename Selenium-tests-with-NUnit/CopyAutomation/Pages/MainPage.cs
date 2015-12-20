using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace GitHubAutomation.Pages
{
    public class MainPage
    {
        private const string BASE_URL = "http://www.copy.com/";

        [FindsBy(How = How.XPath, Using = "//a[@class='control glyph-newfolder']/span")]
        private IWebElement buttonCreateNew;

        [FindsBy(How = How.XPath, Using = "//li[@class='browser-row type-file subtype-file  multi-select-eligible']/span[@class='multi-select-checkbox']")]
        private IWebElement fileWantToBeShare;

        [FindsBy(How = How.XPath, Using = "//div[@class='profile-name-wrapper']/a[1]")]
        private IWebElement buttonProfileName;

        [FindsBy(How = How.XPath, Using = "//div[@class='menu-footer-wrapper']/div/a[@class='dropdown-footer']")]
        private IWebElement buttonSignout;
        
        [FindsBy(How = How.XPath, Using = "//li[@class='browser-row type-file subtype-file  multi-select-eligible']/span[@class='multi-select-checkbox']")]
        private IWebElement fileWantToBeRenamed;

        [FindsBy(How = How.XPath, Using = "//a[@class='control glyph-share']/span")]
        private IWebElement buttonShareFile;

        [FindsBy(How = How.XPath, Using = "//a[@class='control glyph-edit']/span")]
        private IWebElement buttonRenameFile;

        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        // create new folder
        public void ClickOnCreateNewFolderButton()
        {
            buttonCreateNew.Click();
        }

        // share
        public void ClickOnFileWantToBeShare()
        {
            fileWantToBeShare.Click();
            buttonShareFile.Click();
        }

        // rename
        public void ClickOnTheFileWantToBeRename()
        {
            fileWantToBeRenamed.Click();
            buttonRenameFile.Click();
        }

        // logout
        public void Logout()
        {
            buttonProfileName.Click();
            buttonSignout.Click();
        }

    }
}
