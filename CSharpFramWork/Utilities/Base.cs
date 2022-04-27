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

namespace CSharpFramWork.Utilities
{
    public class Base
    {

        String browserName;
        // putting accsess modifier using public infront of IWebDriver driver
        //public IWebDriver driver;
        // Adding threadsafe to run parallel
        public ThreadLocal <IWebDriver> driver = new ThreadLocal<IWebDriver>();
        [SetUp]
        public void Startbrowser()
        {
            //To Run From Terminal
            browserName = TestContext.Parameters["newbrowseName"];
            if (browserName == null)
            {
              // Configuration 
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            //String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            // driver.Manage().Window.Maximize();
            
                String url = ConfigurationManager.AppSettings["urllink"];
            driver.Value.Url = url;
        }
        // should not call driver direct in the Test
        public IWebDriver getDriver()
        {
            return driver.Value;
        }
        // Handling browser mechanism
        public void InitBrowser (string browserName)
        {
            switch (browserName)
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

        public void Aftertest()
        {
            driver.Value.Quit();
        }

    }
}
