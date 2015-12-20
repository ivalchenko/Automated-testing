using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Pages
{
    class RenamePage
    {
        private const string BASE_URL = "https://www.copy.com/browse/a:7e08130;z:copy;b:myfiles/Math_For_Alex.rar%3Boid%3A1";
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@value='Math_For_Alex.rar']")]
        private IWebElement inputNameFile;

        [FindsBy(How = How.XPath, Using = "//button[@class='button button-small button-primary has-glyph ']")]
        private IWebElement butttonRename;

        /*[FindsBy(How = How.XPath, Using = "//li[@class='browser-row type-file subtype-file state-selected-multi state-selected multi-select-eligible']/h1/a")]
        private IWebElement fileName;*/

        public RenamePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void Rename(string newName)
        {
            inputNameFile.Clear();
            inputNameFile.SendKeys(newName);
            butttonRename.Click();
        }

        public string GetFileName()
        {
            Console.WriteLine("Into GET FILE NAME method.");
            string elem = driver.FindElement(By.XPath("//li[@class='browser-row type-file subtype-file  state-selected-multi state-selected multi-select-eligible']/h1/a")).Text;
            Console.WriteLine("Name is: {0}", elem);                

            return elem;
        }
    }
}
