using CUITe.Controls.HtmlControls;
using CUITe.SearchConfigurations;
using Microsoft.VisualStudio.TestTools.UITesting;
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
    }
}
