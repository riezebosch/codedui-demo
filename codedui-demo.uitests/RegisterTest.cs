﻿using codedui_demo.uitests.Account;
//using Microsoft.Services.TestTools.UITesting.Html;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using codedui_demo.uitests.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace codedui_demo.uitests
{
    [CodedUITest]
    public class RegisterTest
    {
        static Process proc;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Playback.Initialize();
            var browser = BrowserWindow.Launch();
            proc = browser.Process;
            browser.CloseOnPlaybackCleanup = false;
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            Playback.Initialize();
            var browser = BrowserWindow.FromProcess(proc);
            browser.Close();
        }

        [TestMethod]
        [AspNetDevelopmentServer("web", "codedui-demo")]

        public void Register()
        {
            var home = new HomePage(Browser);
            var register = home
                .ClickRegister();

            var name = Guid.NewGuid();
            register.EnterEmail($"{name}@gmail.com")
                .EnterPassword("P@ssw0rd")
                .EnterConfirmPassword("P@ssw0rd")
                .ClickRegister()
                .IsLoggedIn($"{name}@gmail.com")
                .ShouldBeTrue();
        }

        [TestMethod]
        [AspNetDevelopmentServer("web", "codedui-demo")]

        public void RegisterAndLogOff()
        {
            var home = new HomePage(Browser);
            var register = home
                .ClickRegister();

            var name = Guid.NewGuid();
            register.EnterEmail($"{name}@gmail.com")
                .EnterPassword("P@ssw0rd")
                .EnterConfirmPassword("P@ssw0rd")
                .ClickRegister()
                .Logoff()
                .IsLoggedIn()
                .ShouldBeFalse();
        }

        [TestMethod]
        [AspNetDevelopmentServer("web", "codedui-demo")]
        public void TestWeakPassword()
        {
            var home = new HomePage(Browser);
            var register = home
                .ClickRegister();

            var name = Guid.NewGuid();
            register.EnterEmail($"{name}@gmail.com")
                .EnterPassword("password")
                .EnterConfirmPassword("password")
                .ClickRegister();


            register
                .Errors
                .Any(m => m.Contains("Passwords must have"))
                .ShouldBeTrue();

        }

        private BrowserWindow Browser
        {
            get
            {
                var url = (Uri)TestContext.Properties[$"{TestContext.AspNetDevelopmentServerPrefix}web"];
                var browser = BrowserWindow.FromProcess(proc);
                browser.NavigateToUrl(url);

                return browser;
            }
        }

    }
}
