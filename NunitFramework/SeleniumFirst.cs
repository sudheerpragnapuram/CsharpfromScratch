using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace NunitFramework
{
    public class SeleniumFirst
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            //Chrome
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
           





            //firefox
            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            //driver = new FirefoxDriver();
            //Microsoft Edge
           // new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            //driver = new EdgeDriver();

            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {

           // driver.Url = "https://rahulshettyacademy.com/#/index";
            driver.Url = "https://www.rahulshettyacademy.com/loginpagePractise/";

           TestContext.Progress.WriteLine( driver.Title);
            TestContext.Progress.WriteLine( driver.Url);
        }

        [TearDown]
        public void ClosBrowser()
        { 


           driver.Close();

        }


    }
}
