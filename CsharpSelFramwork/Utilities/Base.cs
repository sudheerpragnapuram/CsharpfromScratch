using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace CsharpSelFramwork.Utilities
{
    
    public class Base
    {
        

       public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
      // public IWebDriver driver;
        [SetUp]
        public void startbrowser()
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            String browserName = ConfigurationManager.AppSettings["browser"];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            InitBrowser(browserName);
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            // driver.Manage().Window.Maximize();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            String urllink = ConfigurationManager.AppSettings["url"];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            driver.Value.Url = urllink;

        }

        public IWebDriver getDriver()
        { return driver.Value; 
        }
        // Browser Factory Pattern Implementation
        public void InitBrowser ( string browserName)
        {
            switch(browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;

            }
        }

        public static JsonReader getDataParser()
        {
            return new JsonReader();
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Value.Quit();

        }
    }
}
