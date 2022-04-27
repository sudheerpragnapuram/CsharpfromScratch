using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace NunitFramework
{
  
    
    public class Locators
    { 
        IWebDriver driver;
    
        [SetUp]
        public void OpenBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            
            driver.Url = "https://www.rahulshettyacademy.com/loginpagePractise/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }
        //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        [Test]
        public void Test1()
        {

            driver.FindElement(By.Id("username")).SendKeys("abc");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Rahul");
            driver.FindElement(By.CssSelector("#password")).SendKeys("Learning");
            //Radio button
            driver.FindElement(By.XPath("//label[2]//span[2]")).Click();
            driver.FindElement(By.CssSelector("#okayBtn")).Click();


            driver.FindElement(By.CssSelector("select[data-style='btn-info']")).Click();
            driver.FindElement(By.CssSelector("option[value='teach']")).Click();
            driver.FindElement(By.CssSelector("#terms")).Click();
            driver.FindElement(By.CssSelector("#signInBtn")).Click();
            //Thread.Sleep(4000)
            TestContext.Progress.WriteLine("@@@@@@@@@@@@@Checking erro message @@@@@@@@@@@@@@@@@@@@");

            //Explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .TextToBePresentInElementValue(driver.FindElement(By.CssSelector("#signInBtn")), "Sign In"));

            String error = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(error);

            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));

            String linkurl = link.GetAttribute("href");
            String expectedurl = "https://rahulshettyacademy.com/#/documents-request";
            Assert.AreEqual(expectedurl, linkurl);

        }
            


        [Test]
        public void HandleChildWindow()
        {
            String email = "mentor@rahulshettyacademy.com";
            String parentwindowId = driver.CurrentWindowHandle;

            driver.FindElement(By.CssSelector(".blinkingText")).Click();
            //driver.WindowHandles.Count;

            Assert.AreEqual(2, driver.WindowHandles.Count);

            String childwindowname = driver.WindowHandles[1];
            driver.SwitchTo().Window(childwindowname);

            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".im-para.red")).Text);
           String text = driver.FindElement(By.CssSelector(".im-para.red")).Text;

            //
            //
            //Please email us at mentor @rahulshettyacademy.com with below template to receive response

            String[] splittedText = text.Split("at");

            String[] trimsplit = splittedText[1].Trim().Split(" ");
            Assert.AreEqual(email, trimsplit[0]);

            // swithing back to parent window
            driver.SwitchTo().Window(parentwindowId);
            driver.FindElement(By.Id("username")).SendKeys(trimsplit[0]);


        }




        [TearDown]
        public void Closing()
        {
           driver.Close();
        }
    }
}
