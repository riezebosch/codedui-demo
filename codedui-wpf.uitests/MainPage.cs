using CUITe.Controls.WpfControls;
using CUITe.ScreenObjects;
using CUITe.SearchConfigurations;
using Microsoft.VisualStudio.TestTools.UITesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codedui_wpf.uitests
{
    class MainPage : Screen
    {
        private WpfWindow Main => Application.Find<WpfWindow>(By.Name("MainWindow"));

        private WpfEdit Input1 => Main.Find<WpfEdit>(By.AutomationId("BAsMDgQKAAAHDwYGBA4JDQ"));

        private WpfEdit Input2 => Main.Find<WpfEdit>(By.AutomationId("BAUCBA8BBgkNDAkEBAMLBg"));                

        private WpfButton Button => Main.Find<WpfButton>(By.AutomationId("BgkJBA8MAg4MAw0CBAYLBw"));

        private WpfText Label => Main.Find<WpfText>(By.AutomationId("CQcKCw0LBQsIAQ0CBAwHAA"));

        
        public MainPage EnterFirstInput(int input)
        {
            Input1.Text = input.ToString();
            return this;
        }

        public MainPage EnterSecondInput(int input)
        {
            Input2.Text = input.ToString();
            return this;
        }

        public MainPage ClickButton()
        {
            Button.Click();
            return this;
        }
        public string ReadOutput()
        {
            return Label.DisplayText;
        }
    }
}
