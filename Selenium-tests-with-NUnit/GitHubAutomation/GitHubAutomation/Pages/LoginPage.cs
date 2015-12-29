using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyAutomation.Pages
{
    public class LoginPage
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string BASE_URL = "https://www.copy.com/page/home;section:landing";

        [FindsBy(How = How.Id, Using = "dom_id_1")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "dom_id_2")]
        private IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement buttonSubmit;

        [FindsBy(How = How.XPath, Using = "//span[@class='email']")]
        private IWebElement linkLoggedInUser;

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void Login(string username, string password)
        {
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            log.Info("Fill Login and Password fields for authorization.");
            Console.WriteLine("Fill Login and Password fields for authorization.");
            buttonSubmit.Click();
            log.Info("Click to 'Sign in' button.");
            Console.WriteLine("Click to 'Sign in' button.");
        }

        public string GetLoggedInUserName()
        {
            return linkLoggedInUser.Text;
        }
    }
}
