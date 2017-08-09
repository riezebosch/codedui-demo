using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
//using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Shouldly;
using CUITe.ScreenObjects;

namespace codedui_winforms.uitests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    [DeploymentItem("codedui-winforms.exe")]
    public class CodedUITest1
    {
        [TestMethod]
        public void CodedUITestMethod1()
        {
            Screen.Launch<MainPage>("codedui-winforms.exe")
                .EnterInput(5)
                .ClickButton()
                .ReadOutput()
                .ShouldBe("5");
        }

        [TestMethod]
        public void ErrorMessageOnNegativeInput()
        {
            Screen.Launch<MainPage>("codedui-winforms.exe")
                .EnterInput(-3)
                .ClickButton()
                .ReadOutput()
                .ShouldBe("Invalid input.");
        }
    }
}
