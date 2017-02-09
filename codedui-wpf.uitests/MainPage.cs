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

        private WpfEdit Input1
        {
            get
            {
                var control = new WpfEdit(Main);
                control.SearchProperties[WpfControl.PropertyNames.AutomationId] = "BAsMDgQKAAAHDwYGBA4JDQ";

                return control;
            }
        }

        private WpfEdit Input2
        {
            get
            {
                var control = new WpfEdit(Main);
                control.SearchProperties[WpfControl.PropertyNames.AutomationId] = "BAUCBA8BBgkNDAkEBAMLBg";

                return control;
            }
        }

        public MainPage EnterSecondInput(int input)
        {
            Input2.Text = input.ToString();
            return this;
        }

        private WpfButton Button
        {
            get
            {
                var control = new WpfButton(Main);
                control.SearchProperties[WpfControl.PropertyNames.AutomationId] = "BgkJBA8MAg4MAw0CBAYLBw";

                return control;
            }
        }

        private WpfText Label
        {
            get
            {
                var control = new WpfText(Main);
                control.SearchProperties[WpfControl.PropertyNames.AutomationId] = "CQcKCw0LBQsIAQ0CBAwHAA";

                return control;
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
        public MainPage EnterFirstInput(int input)
        {
            Input1.Text = input.ToString();
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
