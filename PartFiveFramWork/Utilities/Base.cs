using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace PartFiveFramWork.Utilities
{
    public class Base
    {
        public ExtentReports extent;
        public ExtentTest test;
        String browserName;
        // report file
        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportpath = projectDirectory + "//index.html";
            var htmlRepoter = new ExtentHtmlReporter(reportpath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlRepoter);
            extent.AddSystemInfo("Host Name", "Local Host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Usernmae", "Sudheer");
        }


        // putting accsess modifier using public infront of IWebDriver driver
        //public IWebDriver driver;
        // Adding threadsafe to run parallel
        public ThreadLocal <IWebDriver> driver = new ThreadLocal<IWebDriver>();
        [SetUp]
        public void Startbrowser()
        {
            // create entry for extentreporter
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            //To Run From Terminal
            browserName = TestContext.Parameters["browseName"];
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
           var status = TestContext.CurrentContext.Result.Outcome.Status;
           var stackTrace = TestContext.CurrentContext.Result.StackTrace;


            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            if(status == TestStatus.Failed)
            {
                test.Fail("Test Failed", captureScreenShot(driver.Value, fileName));
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);
            }
            else if(status == TestStatus.Passed)
            {
               
            }
            extent.Flush();
            driver.Value.Quit();
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }

    }
}
