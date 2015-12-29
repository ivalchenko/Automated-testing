using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyAutomation.Pages
{
    public class CreateNewFolderPage
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string BASE_URL = "https://www.copy.com/browse/";
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "file_name")]
        private IWebElement inputFolderName;

        [FindsBy(How = How.XPath, Using = "//button[@class='button button-small button-primary has-glyph ']")]
        private IWebElement butttonCreate;

        public CreateNewFolderPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public string CreateNewFolder(string folderName)
        {
            string folderFullName = folderName + Utils.RandomGenerator.GetRandomString(6);
            log.Info("New random folder name is " + folderFullName);
            Console.WriteLine("New random folder name is " + folderFullName);
            inputFolderName.SendKeys(folderFullName);
            butttonCreate.Click();
            log.Info("Click to the 'Confirm Create' folder button.");
            Console.WriteLine("Click to the 'Create' folder button.");
            return folderFullName;
        }

    }
}
