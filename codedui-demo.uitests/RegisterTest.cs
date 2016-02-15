using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using Shouldly;
using codedui_demo.uitests.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using CUITe.ObjectRepository;

namespace codedui_demo.uitests
{
    [CodedUITest]
    public class RegisterTest
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            SpeedUp.Setup();
        }

        [TestMethod]
        [AspNetDevelopmentServer("web", "codedui-demo")]
        public void Register()
        {
            var register = Page
                .Launch<HomePage>(FromAspNetDevelopmentServer())
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
        [AspNetDevelopmentServer("web", "codedui-demo")]
        public void RegisterAndLogOff()
        {
            var register = Page
                .Launch<HomePage>(FromAspNetDevelopmentServer())
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
        [AspNetDevelopmentServer("web", "codedui-demo")]
        public void TestWeakPassword()
        {
            var register = Page
                .Launch<HomePage>(FromAspNetDevelopmentServer())
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

        private Uri FromAspNetDevelopmentServer()
        {
            var stack = new StackTrace();
            var attr = stack.GetFrame(1).GetMethod().GetCustomAttributes(true).OfType<AspNetDevelopmentServerAttribute>().FirstOrDefault();
            if (attr == null)
            {
                throw new InvalidOperationException("This method may only be called directly from the test method and that method should have the AspNetDevelopmentServer attribute.");
            }

            return (Uri)TestContext.Properties[$"{TestContext.AspNetDevelopmentServerPrefix}{attr.Name}"];
        }

        private static string CreateUniqueEmail()
        {
            return $"{Guid.NewGuid()}@gmail.com";
        }
    }
}