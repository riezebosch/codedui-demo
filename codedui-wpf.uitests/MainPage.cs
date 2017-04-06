using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace codedui_wpf.uitests
{
    internal class MainPage
    {
        private ApplicationUnderTest sut;

        private WpfWindow MainWindow
        {
            get
            {
                var window = new WpfWindow(sut);
                window.WindowTitles.Add("MainWindow");

                return window;
            }
        }

        public MainPage(ApplicationUnderTest sut)
        {
            this.sut = sut;
        }

        internal MainPage GetalOpVeld1Invoeren(int v)
        {
            var edit = new WpfEdit(MainWindow);
            edit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "BAsMDgQKAAAHDwYGBA4JDQ";

            edit.Text = v.ToString();

            return this;
        }


        internal MainPage DrukOpKnop()
        {
            var button = new WpfButton(MainWindow);
            button.SearchProperties[WpfButton.PropertyNames.AutomationId] = "BgkJBA8MAg4MAw0CBAYLBw";

            Mouse.Click(button);

            return this;
        }

        internal string LeesResultaatUit()
        {
            var label = new WpfText(MainWindow);
            label.SearchProperties[WpfText.PropertyNames.AutomationId] = "CQcKCw0LBQsIAQ0CBAwHAA";

            return label.DisplayText;
        }
    }
}