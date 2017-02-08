//using Microsoft.Services.TestTools.UITesting.Html;
using codedui_demo.uitests.Account;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace codedui_demo.uitests.Home
{
    class HomePage 
    {
        private IWebDriver driver;

        private Lazy<IWebElement> NavBar {  get; } 
       
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            NavBar = new Lazy<IWebElement>(() => driver.FindElement(By.ClassName("navbar")));
        }

        public RegisterPage ClickRegister()
        {
            var link = NavBar.Value.FindElement(By.Id("registerLink"));
            link.Click();

            WaitForStaleness(link);
            return new RegisterPage(driver);
        }

        public bool IsLoggedIn(string username = null)
        {
            var link = driver.FindElements(By.CssSelector("a[title='Manage']"));
            if (link.Any())
            {
                return username == null || link.First().Text.Contains(username);
            }

            return false;
        }

        public HomePage Logoff()
        {
            var link = NavBar.Value.FindElement(By.LinkText("Log off"));
            link.Click();

            WaitForStaleness(link);
            return new HomePage(driver);
        }

        /// <summary>
        /// Wait for staleness of (items on) current page before 
        /// navigating to new page.
        /// </summary>
        /// <remarks>
        /// This worked just fine for all browsers, but IE started
        /// to nag when zoom level wasn't 100% and zoom level is ignored
        /// in the driver options.s
        /// </remarks>
        /// <param name="link"></param>
        private void WaitForStaleness(IWebElement link)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.StalenessOf(link));
        }
    }
}
