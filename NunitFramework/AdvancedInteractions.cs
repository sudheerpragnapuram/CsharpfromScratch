using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace NunitFramework
{
    public class AdvancedInteractions
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // driver.Manage().Window.Maximize();
           // driver.Url = "https://rahulshettyacademy.com/#/index";
        }

        [Test]
        public void test_Actions()
        {
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(By.CssSelector("div[class='nav-outer clearfix'] a[class='dropdown-toggle']"))).Perform();

            // one way driver.FindElement(By.XPath("//div[@class='nav-outer clearfix']//a[normalize-space()='About us']")).Click();
            a.MoveToElement(driver.FindElement(By.XPath("//div[@class='nav-outer clearfix']//a[normalize-space()='About us']"))).Click().Perform();
        }

        [Test]
        public void Dragdrop()
            {

            driver.Url = "https://demoqa.com/droppable/";
            Actions a = new Actions(driver);
            a.DragAndDrop(driver.FindElement(By.XPath("//div[@id='draggable']")), driver.FindElement(By.XPath("//div[@id='simpleDropContainer']//div[@id='droppable']"))).Perform();
        }

        [Test]
        public void Frames()
        {
            //Scroll
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            IWebElement framescroll = driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", framescroll);
            // we can use Id name Index
           
            driver.SwitchTo().Frame("courses-iframe");
            //driver.SwitchTo().Frame("#courses-iframe");
            driver.FindElement(By.LinkText("All Access Plan")).Click();

            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
            driver.SwitchTo().DefaultContent();
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);




        }

    }
}
