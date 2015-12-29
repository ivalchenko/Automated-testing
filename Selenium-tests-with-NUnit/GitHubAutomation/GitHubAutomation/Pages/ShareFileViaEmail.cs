using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyAutomation.Pages
{
    public class ShareFileViaEmail
    {
        private const string BASE_URL = "https://www.copy.com/browse/";
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Users, Groups, and Email Addresses']")]
        private IWebElement inputReceiverEmail;

        [FindsBy(How = How.XPath, Using = "//textarea[@id='message']")]
        private IWebElement inputMessage;

        [FindsBy(How = How.XPath, Using = "//button[@class='button button-small button-primary has-glyph ']")]
        private IWebElement butttonShare;

        [FindsBy(How = How.XPath, Using = "//li[@class='browser-row recipient-row has-subtitle type-recipient subtype-generic']/h1/small[@class='email']")]
        private IWebElement whoHasAccess;

        public ShareFileViaEmail(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void Share(string userEmail, string message)
        {
            inputReceiverEmail.SendKeys(userEmail);
            inputMessage.SendKeys(message);
            butttonShare.Click();
        }

        public string GetUserNameWhoHasAccess()
        {
            return whoHasAccess.Text;
        }
    }
}
