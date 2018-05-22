using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;


namespace SeleniumWithCore2
{
    [TestClass]
    public class SeleniumWebTests
    {
        IWebDriver driver;
        string driverDirectory;
        [TestInitialize]
        public void TestInitialize()
        {
            this.driverDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            this.driver = new ChromeDriver(driverDirectory);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.driver.Close();
        }

        [TestMethod]
        public void FailingTest()
        {
            driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
            driver.FindElement(By.Name("UserName")).SendKeys("admin");
            driver.FindElement(By.Name("Password")).SendKeys("admin");
            driver.FindElement(By.Name("Login")).Submit();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(drv => drv.Url.Equals("http://executeautomation.com/demosite/index.html?UserName=admin&Password=adminNOT"));            
        }

        [TestMethod]
        public void PassingTest()
        {
            driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
            driver.FindElement(By.Name("UserName")).SendKeys("admin");
            driver.FindElement(By.Name("Password")).SendKeys("admin");
            driver.FindElement(By.Name("Login")).Submit();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(drv => drv.Url.Equals("http://executeautomation.com/demosite/index.html?UserName=admin&Password=admin"));
        }

    }
}
