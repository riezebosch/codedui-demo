using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Shouldly;
using CUITe.ScreenObjects;

namespace codedui_wpf.uitests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    [DeploymentItem("codedui-wpf.exe")]
    public class CodedUITest1WPF
    {
        [TestMethod]
        public void CodedUITestMethod1()
        {
            Screen
                .Launch<MainPage>("codedui-wpf.exe")
                .EnterFirstInput(5)
                .EnterSecondInput(6)
                .ClickButton()
                .ReadOutput()
                .ShouldBe("5");
        }

        [TestMethod]
        public void ErrorMessageOnNegativeInput()
        {

            Screen
                .Launch<MainPage>("codedui-wpf.exe")
                .EnterFirstInput(-3)
                .ClickButton()
                .ReadOutput()
                .ShouldBe("Invalid input.");
        }
    }
}