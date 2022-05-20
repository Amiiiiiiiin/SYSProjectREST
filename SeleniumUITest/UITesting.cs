using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumUITest
{
    [TestClass]
    public class UITesting
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";
        private static IWebDriver _driver;

        // https://www.automatetheplanet.com/mstest-cheat-sheet/
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory); // fast
            // if your Chrome browser was updated, you must update the driver as well ...
            //    https://chromedriver.chromium.org/downloads
            //_driver = new FirefoxDriver(DriverDirectory);  // slow
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }
    
        [TestMethod]
        public void AddProfileUITest()
        {
            _driver.Navigate().GoToUrl("https://sysprojectui.azurewebsites.net/setup.html");

                 IWebElement buttonElement = _driver.FindElement(By.Id("getAllButton"));

            Assert.AreEqual("Profiles", buttonElement.Text);

            IWebElement inputName = _driver.FindElement(By.Id("nameField"));
            inputName.SendKeys("Kevin2");
            buttonElement.Click();
            Thread.Sleep(2000);
            
            buttonElement.Click();
           //IWebElement dropDownElement = _driver.FindElement(By.Id("dropDown"));
            ReadOnlyCollection<IWebElement> listElements = _driver.FindElements(By.Id("list"));
            Thread.Sleep(2000);
            //Assert.IsTrue(listElements[-1].Text.Contains("Kevin2"));
            IWebElement lastElement = listElements.ElementAt(listElements.Count - 1);
            string lastElementText = lastElement.Text;
            Assert.IsTrue(lastElementText.EndsWith("Kevin2"));
            Thread.Sleep(2000);

            IWebElement deleteName = _driver.FindElement(By.Id("deleteField"));
            deleteName.SendKeys("Kevin2");
            buttonElement.Click();

        }

    }
}
