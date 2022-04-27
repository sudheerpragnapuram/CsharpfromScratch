using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace NunitFramework
{
    public class SortWebTables
    {

        IWebDriver driver;
        [SetUp]
        public void startbrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]
        public void sortTable()
        {

            ArrayList a = new ArrayList();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByValue("20");
            
            // step-1 -Get all veggies names in Arraylist -A
            IList<IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement veggie in veggies)
            {
                a.Add(veggie);
            }
            
            // step-2 sort this arraylist
            

            foreach(String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }
            TestContext.Progress.WriteLine("After sorting");

            a.Sort();
             foreach(String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            driver.FindElement(By.CssSelector("th[aria-label*='Veg/fruit name']")).Click();

            ArrayList b = new ArrayList();

            IList<IWebElement> sortveggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement sortveggie in sortveggies)
            { 
            b.Add(sortveggie);
            }

            Assert.AreEqual(a, b);

        }

    }
}
