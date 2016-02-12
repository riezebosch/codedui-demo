using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using codedui_demo.uitests.Home;

namespace codedui_demo.uitests.Account
{
    class RegisterPage : TestPage
    {

        public RegisterPage(BrowserWindow browser) : base(browser)
        {

        }



        public RegisterPage EnterEmail(string email)
        {
            FindAndSendKeys("Email", email);
            return this;
        }

        


        internal RegisterPage EnterPassword(string password)
        {
            FindAndSendKeys("Password", password);
            return this;
        }

        internal RegisterPage EnterConfirmPassword(string password)
        {
            FindAndSendKeys("ConfirmPassword", password);
            return this;
        }

        internal HomePage ClickRegister()
        {
            var control = Find<HtmlInputButton>(By.Type, "submit");
            Mouse.Click(control);

            return new HomePage(Browser);
        }
    }
}
