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
            var control = Find<HtmlEdit>(HtmlControl.PropertyNames.Id, id);
            Keyboard.SendKeys(control, keys);
        }

        protected T Find<T>(string by, string value, UITestControl parent = null)
            where T : HtmlControl
        {
            var control = (T)Activator.CreateInstance(typeof(T), parent ?? Browser);
            control.SearchProperties.Add(by.ToString(), value, PropertyExpressionOperator.EqualTo);
            control.Find();

            return control;
        }
    }
}
