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
            NavBar.Value.FindElement(By.Id("registerLink")).Click();
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
            NavBar.Value.FindElement(By.LinkText("Log off")).Click();
            return new HomePage(driver);
        }
    }
}
