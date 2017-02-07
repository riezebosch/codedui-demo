using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using Shouldly;
using codedui_demo.uitests.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace codedui_demo.uitests
{
    [TestClass]
    [DeploymentItem(@"IEDriverServer.exe")]
    public class RegisterTest
    {
        public TestContext TestContext { get; set; }

        private const string devservername = "web";
        private const string targetprojectname = "codedui-demo";

        private IWebDriver driver;

        [TestInitialize]
        [AspNetDevelopmentServer(devservername, targetprojectname)]
        public void StartTest()
        {
            driver = new InternetExplorerDriver();
            driver.Url = FromTestContext().ToString();
        }

        [TestCleanup]
        public void EndTest()
        {
            driver.Close();
        }

        [TestMethod]
        [AspNetDevelopmentServer(devservername, targetprojectname)]
        public void Register()
        {
            var register = new HomePage(driver)
                .ClickRegister();

            var email = CreateUniqueEmail();

            var home = register
                .EnterEmail(email)
                .EnterPassword("P@ssw0rd")
                .EnterConfirmPassword("P@ssw0rd")
                .ClickRegister();

            home.IsLoggedIn(email)
                .ShouldBeTrue();
        }

        [TestMethod]
        [AspNetDevelopmentServer(devservername, targetprojectname)]
        public void RegisterAndLogOff()
        {
            var register = new HomePage(driver)
                .ClickRegister();

            var email = CreateUniqueEmail();

            var home = register
                .EnterEmail(email)
                .EnterPassword("P@ssw0rd")
                .EnterConfirmPassword("P@ssw0rd")
                .ClickRegister();
            
            home
                .Logoff()
                .IsLoggedIn()
                .ShouldBeFalse();
        }

        [TestMethod]
        [AspNetDevelopmentServer(devservername, targetprojectname)]
        public void TestWeakPassword()
        {
            var register = new HomePage(driver)
                .ClickRegister();

            var email = CreateUniqueEmail();

            register
                .EnterEmail(email)
                .EnterPassword("password")
                .EnterConfirmPassword("password")
                .ClickRegister();

            register
                .Errors
                .Any(m => m.Contains("Passwords must have"))
                .ShouldBeTrue();
        }

        private Uri FromTestContext()
        {
            return (Uri)TestContext.Properties[$"{TestContext.AspNetDevelopmentServerPrefix}{devservername}"];
        }

        private static string CreateUniqueEmail()
        {
            return $"{Guid.NewGuid()}@gmail.com";
        }
    }
}