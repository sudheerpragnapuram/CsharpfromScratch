using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace NunitFramework
{
    public class AutoAlertSuggestions
    {

        IWebDriver driver;
        [SetUp]
        public void startbrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }
        [Test]
        public void testalert()
        {
            String name = "sudheer";
            driver.FindElement(By.XPath("//input[@id='name']")).SendKeys(name);
            driver.FindElement(By.XPath("//input[@id='confirmbtn']")).Click();
            String alerttext = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            //driver.SwitchTo().Alert().Dismiss();
            //driver.SwitchTo().Alert().SendKeys("Hello");
            StringAssert.Contains(name, alerttext);

        }

        [Test]
        public void Autodropdown()
        {
            driver.FindElement(By.CssSelector("#autocomplete")).SendKeys("Ind");

            IList<IWebElement> options =  driver.FindElements(By.CssSelector(".ui-menu-item div"));

            foreach (IWebElement option in options)
            {
                if(option.Text.Equals("India"))
                {
                    option.Click();
                }

            }

            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("#autocomplete")).GetAttribute("vaue"));
        }

    }
}
