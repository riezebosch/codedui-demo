using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace codedui_demo.uitests
{
    [TestClass]
    [DeploymentItem(@"ChromeDriver.exe")]
    public class RegisterTestChrome : RegisterTest
    {
        protected override IWebDriver InitializeDriver()
        {
            return new ChromeDriver();
        }
    }
}
