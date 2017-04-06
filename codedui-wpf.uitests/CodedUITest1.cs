using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Shouldly;

namespace codedui_wpf.uitests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    [DeploymentItem("codedui-wpf.exe")]
    public class CodedUITest1WPF
    {
        ApplicationUnderTest sut;

        [TestInitialize]
        public void Opstarten()
        {
            sut = ApplicationUnderTest.Launch("codedui-wpf.exe");
        }

        [TestMethod]
        public void ZelfdeTestMetCuite()
        {
            MainPageCuite.Launch<MainPageCuite>("codedui-wpf.exe")
                 .GetalOpVeld1Invoeren(0)
                 .DrukOpKnop()
                 .LeesResultaatUit()
                 .ShouldBe("0");
        }

        [TestMethod]
        public void HetEersteGetalIs0EnHetBijbehorendeFibonacciGetalIsOok0()
        {
           new MainPage(sut)
                .GetalOpVeld1Invoeren(0)
                .DrukOpKnop()
                .LeesResultaatUit()
                .ShouldBe("0");
        }

        [TestMethod]
        public void BijEenNegatieveInvoerGeeftDeApplicatieDeMeldingInvalidInput()
        {
            var page = new MainPage(sut);
            page.GetalOpVeld1Invoeren(-1);
            page.DrukOpKnop();

            var resultaat = page.LeesResultaatUit();

            Assert.AreEqual("Ongeldige invoer!", resultaat);
        }
    }
}