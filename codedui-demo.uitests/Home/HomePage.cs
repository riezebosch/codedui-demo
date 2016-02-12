//using Microsoft.Services.TestTools.UITesting.Html;
using codedui_demo.uitests.Account;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace codedui_demo.uitests.Home
{
    class HomePage : TestPage
    {
       
        public HomePage(BrowserWindow browser) : base(browser)
        {
        }

        public RegisterPage ClickRegister()
        {
            var link = Find<HtmlHyperlink>(HtmlControl.PropertyNames.Id, "registerLink");
            link.WaitForControlReady();
            Mouse.Click(link);

            return new RegisterPage(Browser);
        }

        internal bool IsLoggedIn(string username)
        {
            var link = Find<HtmlHyperlink>(HtmlControl.PropertyNames.Title, "Manage");
            return link.InnerText.Contains(username);
        }

        internal HomePage Logoff()
        {
            var link = Find<HtmlHyperlink>(HtmlControl.PropertyNames.InnerText, "Log off");
            Mouse.Click(link);

            return this;
        }
    }
}
