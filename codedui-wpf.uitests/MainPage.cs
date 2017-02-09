using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codedui_wpf.uitests
{
    class MainPage
    {
        private ApplicationUnderTest app;

        private WpfWindow Main
        {
            get
            {
                var window = new WpfWindow(app);
                window.WindowTitles.Add("MainWindow");

                return window;
            }
        }

        private WpfEdit Input
        {
            get
            {
                var wrapper = new WpfWindow(Main);
                wrapper.SearchProperties[UITestControl.PropertyNames.Name] = "input";

                return new WpfEdit(wrapper);
            }
        }
       
        private WpfButton Button
        {
            get
            {
                var wrapper = new WpfWindow(Main);
                wrapper.SearchProperties[UITestControl.PropertyNames.Name] = "button";

                return new WpfButton(wrapper);
            }
        }

        private WpfText Label
        {
            get
            {
                var wrapper = new WpfText(Main);
                wrapper.SearchProperties[UITestControl.PropertyNames.Name] = "output";

                return new WpfText(wrapper);
            }
        }

        private MainPage()
        {
        }

        public static MainPage Start()
        {
            return new MainPage
            {
                app = ApplicationUnderTest.Launch("codedui-wpf.exe")
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
