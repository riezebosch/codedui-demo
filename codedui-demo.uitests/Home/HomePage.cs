//using Microsoft.Services.TestTools.UITesting.Html;
using codedui_demo.uitests.Account;
using CUITe.Controls.HtmlControls;
using CUITe.ObjectRepository;
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
    class HomePage : Page
    {
        private Lazy<HtmlDiv> NavBar {  get; } 
       
        public HomePage()
        {
            NavBar = new Lazy<HtmlDiv>(() => Browser.Find<HtmlDiv>(By.Class("navbar navbar-inverse navbar-fixed-top")));
        }

        public RegisterPage ClickRegister()
        {
            NavBar.Value.Find<HtmlHyperlink>(By.Id("registerLink")).Click();
            return NavigateTo<RegisterPage>();
        }

        public bool IsLoggedIn(string username = null)
        {
            NavBar.Value.WaitForControlReady();
            var link = Find<HtmlHyperlink>(By.SearchProperties("Title=Manage"));

            if (link.Exists)
            {
                return username == null || link.InnerText.Contains(username);
            }

            return false;
        }

        public HomePage Logoff()
        {
            NavBar.Value.Find<HtmlHyperlink>(By.SearchProperties("InnerText=Log off")).Click();
            return NavigateTo<HomePage>();
        }
    }
}
