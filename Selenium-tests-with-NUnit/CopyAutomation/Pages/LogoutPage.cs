using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Pages
{
    class LogoutPage
    {
        private const string BASE_URL = "https://www.copy.com/";

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement button;

        private IWebDriver driver;

        public LogoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Logout Page opened");
        }

        public bool WasLogout()
        {
            return button.Text.Equals("Sign in");
        }
    }
}
