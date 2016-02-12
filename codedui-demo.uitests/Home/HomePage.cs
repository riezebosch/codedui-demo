//using Microsoft.Services.TestTools.UITesting.Html;
using codedui_demo.uitests.Account;
using CUITe.Controls.HtmlControls;
using CUITe.SearchConfigurations;
using Microsoft.VisualStudio.TestTools.UITesting;
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
        private Lazy<HtmlDiv> NavBar {  get; } 
       
        public HomePage(BrowserWindow browser) : base(browser)
        {
            NavBar = new Lazy<HtmlDiv>(() => Browser.Find<HtmlDiv>(By.Class("navbar navbar-inverse navbar-fixed-top")));
        }

        public RegisterPage ClickRegister()
        {
            NavBar.Value.Find<HtmlHyperlink>(By.Id("registerLink")).Click();
            return new RegisterPage(Browser);
        }

        internal bool IsLoggedIn(string username = null)
        {
            NavBar.Value.WaitForControlReady();
            var link = Browser.Find<HtmlHyperlink>(By.SearchProperties("Title=Manage"));

            if (link.Exists)
            {
                return username == null ? link.InnerText.Contains(username) : true;
            }

            return false;
        }

       

        internal HomePage Logoff()
        {
            NavBar.Value.Find<HtmlHyperlink>(By.SearchProperties("InnerText=Log off")).Click();

            // This action results in a redirect therefore starting fresh when searching for components.
            return new HomePage(Browser);
        }
    }
}
