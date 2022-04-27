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

namespace NunitFramework
{
    public class DropDown
    {
        // public string Name { get; set; }
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.rahulshettyacademy.com/loginpagePractise/";

        }

        [Test]
        public void dropdown()
        { 
            //for static drop downs
            IWebElement item = driver.FindElement(By.CssSelector("select[class='form-control']"));
            SelectElement s = new SelectElement(item);
            s.SelectByText("Teacher");
            s.SelectByValue("consult");

            // Radio Buttons

           IList<IWebElement> rados = driver.FindElements(By.CssSelector("input[type='radio']"));

            foreach (IWebElement radobtn in rados)
            {
                if (radobtn.GetAttribute("value").Equals("user")) { 
                radobtn.Click();
                }
            }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();
            //Boolean selec =  driver.FindElement(By.Id("usertype")).Selected;

           // Assert.That(selec, Is.True);




        


        }
      



    }
}
