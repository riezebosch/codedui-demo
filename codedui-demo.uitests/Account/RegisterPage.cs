using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;
using codedui_demo.uitests.Home;
using CUITe.Controls.HtmlControls;
using CUITe.SearchConfigurations;
using CUITe.ObjectRepository;

namespace codedui_demo.uitests.Account
{
    class RegisterPage : Page
    {
        public IEnumerable<string> Errors
        {
            get
            {
                var list = Find<HtmlDiv>(By.Class("validation-summary-errors text-danger"))
                    .Find<HtmlUnorderedList>();

                return list.GetChildren().OfType<HtmlCustomListItem>().Select(li => li.InnerText);
            }
        }

        public RegisterPage EnterEmail(string email)
        {
            Find<HtmlEdit>(By.Id("Email")).Text = email;
            return this;
        }

        public HomePage ClickRegister()
        {
            Find<HtmlInputButton>(By.SearchProperties("type=submit")).Click();
            return NavigateTo<HomePage>();
        }

        public RegisterPage EnterConfirmPassword(string password)
        {
            Find<HtmlEdit>(By.Id("ConfirmPassword")).Text = password;
            return this;
        }

        public RegisterPage EnterPassword(string password)
        {
            Find<HtmlEdit>(By.Id("Password")).Text = password;
            return this;
        }
    }
}
