using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using codedui_demo.uitests.Home;
using OpenQA.Selenium;

namespace codedui_demo.uitests.Account
{
    class RegisterPage 
    {
        private IWebDriver driver;

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IEnumerable<string> Errors
        {
            get
            {
                var list = driver.FindElement(By.ClassName("validation-summary-errors"))
                    .FindElement(By.TagName("ul"));

                return list.FindElements(By.TagName("li")).Select(li => li.Text);
            }
        }

        public RegisterPage EnterEmail(string email)
        {
            driver.FindElement(By.Id("Email")).SendKeys(email);
            return this;
        }

        public HomePage ClickRegister()
        {
            driver.FindElement(By.TagName("form")).Submit();
            return new HomePage(driver);
        }

        public RegisterPage EnterConfirmPassword(string password)
        {
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys(password);
            return this;
        }

        public RegisterPage EnterPassword(string password)
        {
            driver.FindElement(By.Id("Password")).SendKeys(password);
            return this;
        }
    }
}
