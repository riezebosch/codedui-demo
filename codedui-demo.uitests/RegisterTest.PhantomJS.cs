using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;

namespace codedui_demo.uitests
{
    [TestClass]
    [DeploymentItem(@"phantomjs.exe")]
    public class RegisterTestPhantomJS : RegisterTest
    {
        protected override IWebDriver InitializeDriver()
        {
            var driver = new PhantomJSDriver();
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);

            return driver;
        }
    }
}
