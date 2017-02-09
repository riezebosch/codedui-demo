using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codedui_winforms.uitests
{
    class MainPage
    {
        private WinWindow Main { get; set; }

        public MainPage Start()
        {
            var app = ApplicationUnderTest.Launch("codedui-winforms.exe");
            Main = new WinWindow(app);
            Main.WindowTitles.Add("Form1");

            return this;
        }
        public MainPage EnterInput(int input)
        {
            var wrapper = new WinWindow(Main);
            wrapper.SearchProperties[WinButton.PropertyNames.Name] = "textBox1";

            var text = new WinEdit(wrapper);
            text.Text = input.ToString();

            return this;
        }

        public MainPage ClickButton()
        {
            var wrapper = new WinWindow(Main);
            wrapper.SearchProperties[WinButton.PropertyNames.Name] = "button1";

            var button = new WinButton(wrapper);
            Mouse.Click(button);

            return this;
        }

     
        public string ReadOutput()
        {
            var wrapper = new WinWindow(Main);
            wrapper.SearchProperties[WinButton.PropertyNames.Name] = "label1";

            var label = new WinText(wrapper);
            return label.DisplayText;
        }
    }
}
