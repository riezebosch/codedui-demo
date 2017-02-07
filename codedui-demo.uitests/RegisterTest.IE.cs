using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace codedui_demo.uitests
{
    [TestClass]
    [DeploymentItem(@"IEDriverServer.exe")]
    public class RegisterTestIE : RegisterTest
    {
        protected override IWebDriver InitializeDriver()
        {
            return new InternetExplorerDriver();
        }
    }
}
