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
        private ApplicationUnderTest app;

        private WinWindow Main
        {
            get
            {
                var window = new WinWindow(app);
                window.WindowTitles.Add("Form1");

                return window;
            }
        }

        private WinEdit Input
        {
            get
            {
                var wrapper = new WinWindow(Main);
                wrapper.SearchProperties[UITestControl.PropertyNames.Name] = "textBox1";

                return new WinEdit(wrapper);
            }
        }
       
        private WinButton Button
        {
            get
            {
                var wrapper = new WinWindow(Main);
                wrapper.SearchProperties[UITestControl.PropertyNames.Name] = "button1";

                return new WinButton(wrapper);
            }
        }

        private WinText Label
        {
            get
            {
                var wrapper = new WinWindow(Main);
                wrapper.SearchProperties[UITestControl.PropertyNames.Name] = "label1";

                return new WinText(wrapper);
            }
        }

        private MainPage()
        {
        }

        public static MainPage Start()
        {
            return new MainPage
            {
                app = ApplicationUnderTest.Launch("codedui-winforms.exe")
            };
        }
        public MainPage EnterInput(int input)
        {
            Input.Text = input.ToString();
            return this;
        }
        public MainPage ClickButton()
        {
            Mouse.Click(Button);
            return this;
        }
        public string ReadOutput()
        {
            return Label.DisplayText;
        }
    }
}
