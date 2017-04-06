using System;
using CUITe.ScreenObjects;
using CUITe.Controls.WpfControls;
using CUITe.SearchConfigurations;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace codedui_wpf.uitests
{
    internal class MainPageCuite : Screen
    {
        private WpfWindow MainWindow
        {
            get
            {
                return Application.Find<WpfWindow>(By.Name("MainWindow"));
            }
        }

        internal MainPageCuite GetalOpVeld1Invoeren(int v)
        {
            MainWindow
                .Find<WpfEdit>(By.AutomationId("BAsMDgQKAAAHDwYGBA4JDQ"))
                .Text = v.ToString();

            return this;
        }


        internal MainPageCuite DrukOpKnop()
        {
            MainWindow.Find<WpfButton>(By.AutomationId("BgkJBA8MAg4MAw0CBAYLBw")).Click();
            return this;
        }

        internal string LeesResultaatUit()
        {
            return MainWindow.Find<WpfText>(By.AutomationId("CQcKCw0LBQsIAQ0CBAwHAA")).DisplayText;
        }
    }
}