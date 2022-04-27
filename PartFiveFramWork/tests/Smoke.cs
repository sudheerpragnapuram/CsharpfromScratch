using AngleSharp.Text;
using PartFiveFramWork.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace PartFiveFramWork
{
    [Parallelizable(ParallelScope.Self)]
    public class Smoke :Base
    {


        [Test]
        public void Fuctions()
        {
            String[] expectedproducts = { "iphone X", "Blackberry" };
            String[] actualproducts = new String[2];
            driver.Value.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.Value.FindElement(By.CssSelector("#password")).SendKeys("learning");
            driver.Value.FindElement(By.CssSelector("#signInBtn")).Click();
            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

        }
    }
}


