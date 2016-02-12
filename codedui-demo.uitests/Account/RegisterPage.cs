using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;
using codedui_demo.uitests.Home;
using CUITe.Controls.HtmlControls;
using CUITe.SearchConfigurations;

namespace codedui_demo.uitests.Account
{
    class RegisterPage : TestPage
    {
        public RegisterPage(BrowserWindow browser) : base(browser)
        {
        }
        
        public RegisterPage EnterEmail(string email)
        {
            Browser.Find<HtmlEdit>(By.Id("Email")).Text = email;
            return this;
        }
        
        internal RegisterPage EnterPassword(string password)
        {
            Browser.Find<HtmlEdit>(By.Id("Password")).Text = password;
            return this;
        }

        internal RegisterPage EnterConfirmPassword(string password)
        {
            Browser.Find<HtmlEdit>(By.Id("ConfirmPassword")).Text = password;
            return this;
        }

        internal HomePage ClickRegister()
        {
            Browser.Find<HtmlInputButton>(By.SearchProperties("type=submit")).Click();
            return new HomePage(Browser);
        }

        public IEnumerable<string> Errors
        {
            get
            {
                var list = Browser
                    .Find<HtmlDiv>(By.Class("validation-summary-errors text-danger"))
                    .Find<HtmlUnorderedList>();

                    return list.GetChildren().OfType<HtmlCustomListItem>().Select(li => li.InnerText);
            }
        }
    }
}
