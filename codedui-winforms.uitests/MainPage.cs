using CUITe.Controls.WinControls;
using CUITe.ScreenObjects;
using CUITe.SearchConfigurations;
// using Microsoft.VisualStudio.TestTools.UITesting;
// using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codedui_winforms.uitests
{
    class MainPage : Screen
    {
        private WinWindow Main => new WinWindow(By.Name("Form1"));

        private WinEdit Input => Main.Find<WinEdit>(By.ControlName("textBox1"));
       
        private WinButton Button => Main.Find<WinButton>(By.Name("button1"));

        private WinText Label => Main.Find<WinText>(By.ControlName("label1"));

        public MainPage EnterInput(int input)
        {
            Input.Text = input.ToString();
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
