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
    public class Regression :Base
    {
       
        
        [Test]
        public void Test1()
        {

            driver.Value.FindElement(By.Id("username")).SendKeys("abc");
            driver.Value.FindElement(By.Id("username")).Clear();
            driver.Value.FindElement(By.Id("username")).SendKeys("Rahul");
            driver.Value.FindElement(By.CssSelector("#password")).SendKeys("Learning");

           // driver.FindElement(By.XPath("//label[2]//span[2]")).Click();
           // driver.FindElement(By.CssSelector("#okayBtn")).Click();

           // driver.FindElement(By.CssSelector("select[data-style='btn-info']")).Click();
           // driver.FindElement(By.CssSelector("option[value='teach']")).Click();
            driver.Value.FindElement(By.CssSelector("#terms")).Click();
           driver.Value.FindElement(By.CssSelector("#signInBtn")).Click();

            TestContext.Progress.WriteLine("@@@@@@@@@@@@@Checking erro message @@@@@@@@@@@@@@@@@@@@");

            //Explicit wait
            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .TextToBePresentInElementValue(driver.Value.FindElement(By.CssSelector("#signInBtn")), "Sign In"));

            String error = driver.Value.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(error);
        }
       
    }
}
