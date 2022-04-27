using AngleSharp.Text;
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
    public class E2ETest
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
           // driver.Manage().Window.Maximize();
            driver.Url = "https://www.rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void fuctions()
        {
            String[] expectedproducts = { "iphone X", "Blackberry" };
            String[] actualproducts = new String[2];
                driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.CssSelector("#password")).SendKeys("learning");
            driver.FindElement(By.CssSelector("#signInBtn")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

           IList<IWebElement> products =  driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement product in products)
            {

                if(expectedproducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                    {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
               TestContext.Progress.WriteLine( product.FindElement(By.CssSelector(".card-title a")).Text);



            }

            driver.FindElement(By.PartialLinkText("Checkout")).Click();
            IList<IWebElement> checkoutcards = driver.FindElements(By.CssSelector("h4 a"));

            for (int i = 0; i < checkoutcards.Count; i++)
            {
                actualproducts[i] = checkoutcards[i].Text;
            }
            Assert.AreEqual(expectedproducts, actualproducts);

            driver.FindElement(By.CssSelector("button[class='btn btn-success']")).Click();
            driver.FindElement(By.CssSelector("#country")).SendKeys("ind");

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();
            driver.FindElement(By.CssSelector("label[for='checkbox2']")).Click();
            driver.FindElement(By.CssSelector("input[value='Purchase']")).Click();
            String confitmText = driver.FindElement(By.CssSelector(".alert.alert-success.alert-dismissible")).Text;
            StringAssert.Contains("Success", confitmText);

            TestContext.Progress.WriteLine(confitmText);


        }
        [TearDown]

        public void aftertest()
        {
            driver.Quit();
        }

    }
}
