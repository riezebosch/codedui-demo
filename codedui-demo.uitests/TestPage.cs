using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codedui_demo.uitests
{
    class TestPage
    {
        protected BrowserWindow Browser { get; set; }

        public TestPage(BrowserWindow browser)
        {
            this.Browser = browser;
        }

        protected void FindAndSendKeys(string id, string keys)
        {
            var control = Find<HtmlEdit>(By.Id, id);
            Keyboard.SendKeys(control, keys);
        }

        protected T Find<T>(By by, string value)
            where T : HtmlControl
        {
            var control = (T)Activator.CreateInstance(typeof(T), Browser);
            if (by == By.Id)
            {
                control.SearchProperties.Add(HtmlControl.PropertyNames.Id, value, PropertyExpressionOperator.EqualTo);
            }
            else if (by == By.Text)
            {
                control.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, value, PropertyExpressionOperator.EqualTo);

            }
            else
            {
                control.SearchProperties.Add(by.ToString(), value, PropertyExpressionOperator.EqualTo);
            }
            control.Find();

            return control;
        }
    }
}
