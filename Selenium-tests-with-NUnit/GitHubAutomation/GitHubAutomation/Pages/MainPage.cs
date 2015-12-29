using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace CopyAutomation.Pages
{
    public class MainPage
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string BASE_URL = "http://www.copy.com/";

        [FindsBy(How = How.XPath, Using = "//li[@class='browser-row type-file subtype-file  multi-select-eligible']/span[@class='multi-select-checkbox']")]
        private IWebElement fileWantToBeShare;

        [FindsBy(How = How.XPath, Using = "//li[@class='browser-row type-file subtype-file  multi-select-eligible']/span[@class='multi-select-checkbox']")]
        private IWebElement fileWantToBeDelete;
        
        [FindsBy(How = How.XPath, Using = "//li[@class='browser-row type-file subtype-file  multi-select-eligible']/span[@class='multi-select-checkbox']")]
        private IWebElement fileWantToBeRenamed;

        [FindsBy(How = How.XPath, Using = "//li[@class='browser-row type-file subtype-file  multi-select-eligible']/h1/a")]
        private IWebElement NameOfFileWhichWasDelete;

        // buttons
        [FindsBy(How = How.XPath, Using = "//a[@class='control glyph-newfolder']/span")]
        private IWebElement buttonCreateNew;

        [FindsBy(How = How.XPath, Using = "//a[@class='user-dropdown']/div[@class='profile-name-wrapper']/span[1]")]
        private IWebElement buttonProfile;

        [FindsBy(How = How.XPath, Using = "//a[@class='control glyph-share']/span")]
        private IWebElement buttonShareFile;

        [FindsBy(How = How.XPath, Using = "//a[@class='control glyph-edit']/span")]
        private IWebElement buttonRenameFile;

        [FindsBy(How = How.XPath, Using = "//a[@class='control glyph-more more-actions']/span")]
        private IWebElement buttonMore;

        [FindsBy(How = How.XPath, Using = "//div[@class='context-menu-action-group index-1']/a[1]/span")]
        private IWebElement buttonDelete;

        [FindsBy(How = How.XPath, Using = "//button[@class='button button-small button-primary has-glyph  button-danger']")]
        private IWebElement butttonConfirmDelete;

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
            log.Info("Click to the 'Create' new folder button.");
            Console.WriteLine("Click to the 'Create' new folder button.");
            buttonCreateNew.Click();
        }

        // share
        public void ClickOnFileWantToBeShare()
        {
            fileWantToBeShare.Click();
            log.Info("Click to the file which want to be shared.");
            Console.WriteLine("Click to the file which want to be shared.");
            buttonShareFile.Click();
            log.Info("Click to the share button.");
            Console.WriteLine("Click to the share button.");
        }

        // rename
        public void ClickOnTheFileWantToBeRename()
        {
            fileWantToBeRenamed.Click();
            log.Info("Click to the file which want to be renamed");
            Console.WriteLine("Click to the file which want to be renamed.");
            buttonRenameFile.Click();
            log.Info("Click to the rename button.");
            Console.WriteLine("Click to the rename button.");
        }

        // delete
        public void Delete()
        {
            fileWantToBeDelete.Click();
            log.Info("Click to the file which want to be deleted.");
            Console.WriteLine("Click to the file which want to be deleted.");
            buttonMore.Click();
            log.Info("Click to the button 'More'");
            Console.WriteLine("Click to the button 'More'");
            buttonDelete.Click();
            log.Info("Click to the button 'Delete'");
            Console.WriteLine("Click to the button 'Delete'");
            butttonConfirmDelete.Click();
            log.Info("Click to the button 'Confirm delete'.");
            Console.WriteLine("Click to the button 'Confirm delete'.");
        }

        public string GetNameOfFileWhichWasDelete()
        {
            log.Info("NameOfFileWhichWasDelete " + NameOfFileWhichWasDelete.Text);
            Console.WriteLine("NameOfFileWhichWasDelete is '{0}'", NameOfFileWhichWasDelete.Text);
            return NameOfFileWhichWasDelete.Text;
        }

    }
}
