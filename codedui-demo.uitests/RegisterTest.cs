using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Shouldly;
using codedui_demo.uitests.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using OpenQA.Selenium;

namespace codedui_demo.uitests
{
    [TestClass]
    public abstract class RegisterTest
    {
        public TestContext TestContext { get; set; }

        private const string devservername = "web";
        private const string targetprojectname = "codedui-demo";

        private IWebDriver driver;

        [TestInitialize]
        public void StartTest()
        {
            driver = InitializeDriver();
            driver.Url = FromTestContext().ToString();
        }

        protected abstract IWebDriver InitializeDriver();

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
        public void TestErrorForWeakPassword()
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
                .ShouldContain("Passwords must have at least one non letter or digit character. Passwords must have at least one digit ('0'-'9'). Passwords must have at least one uppercase ('A'-'Z').");
        }

        [TestMethod]
        [AspNetDevelopmentServer(devservername, targetprojectname)]
        public void TestErrorWhenConfirmPasswordDoesNotMatch()
        {
            var register = new HomePage(driver)
                .ClickRegister();

            var email = CreateUniqueEmail();

            register
                .EnterEmail(email)
                .EnterPassword("P@ssw0rd")
                .EnterConfirmPassword("P@Ssw0rd")
                .ClickRegister();

            register
                .Errors
                .ShouldContain("The password and confirmation password do not match.");
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