using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyAutomation.Pages
{
    public class DeletePage
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string BASE_URL = "https://www.copy.com/browse/a:7e08130;z:copy;b:myfiles";
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[@class='control glyph-trash']/span")]
        private IWebElement buttonTrash;

        public DeletePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public bool WasFileDelete(string fileName)
        {
            log.Info("Into WasFileDelete() method of DeletePage.");
            Console.WriteLine("Into WasFileDelete() method of DeletePage.");
            log.Info("Click to 'Trash' button.");
            Console.WriteLine("Click to 'Trash' button.");
            buttonTrash.Click();

            List<IWebElement> elements = new List<IWebElement>();

            foreach (var elem in driver.FindElements(By.XPath("//li[@class='browser-row type-file subtype-file  state-deleted multi-select-eligible']/h1/a")))
            {
                if (elem.Text == fileName)
                {
                    log.Info("Deleted file was successfully found. It's " + elem.Text);
                    Console.WriteLine("Deleted file was successfully found. It's " + elem.Text);
                    return true; 
                }    
            }

            log.Error("Deleted file was not found!");
            Console.WriteLine("Deleted file was not found!");
            return false;
        }
    }
}
