using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Pages
{
    public class CreateNewFolderPage
    {
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
            inputFolderName.SendKeys(folderFullName);
            butttonCreate.Click();
            return folderFullName;
        }

        /*public bool IsCurrentRepositoryEmpty()
        {
            return labelEmptyRepoRecommendations.Displayed;
        }*/

        /*public string GetCurrentRepositoryName()
        {
            return linkCurrentRepository.Text;
        }*/

    }
}
