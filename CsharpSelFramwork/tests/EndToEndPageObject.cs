using AngleSharp.Text;
using CsharpSelFramwork.PageObject;
using CsharpSelFramwork.Utilities;
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
    // Inhertance method
    [Parallelizable(ParallelScope.Children)]
    public class EndToEndPageObject : Base
    {
        // Run the tests parallel in 3 ways and to run parallel we have to add Thread safe in Base class
        // run all data ses of test method in parallel [Parallelizable(ParallelScope.All)] 
        //run all test methods in one class parallel  [Parallelizable(ParallelScope.Children)] in class level
        // run all test files in project parallel [Parallelizable(ParallelScope.Self)] in class level

        [Test, TestCaseSource("AddTestDataConfig")]
       // [TestCase("rahulshettyacademy", "learning")]
        // for mutlipule users we can add no.of [testcase]
       // [TestCase("rahulshettyacade", "learni")]
       
       // [Parallelizable(ParallelScope.All)]
        public void Test1(String username, String password, String[] expectedproducts)
        {
           // String[] expectedproducts = { "iphone X", "Blackberry" };
            String[] actualproducts = new String[2];
            // Login Page
            //driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            //driver.FindElement(By.CssSelector("#password")).SendKeys("learning");
            //driver.FindElement(By.CssSelector("#signInBtn")).Click();
            LoginPage loginpage = new LoginPage(getDriver());
            ProductsPage  productspage = loginpage.validLogin(username, password);
            productspage.waitForPageDisplay();
            IList<IWebElement> products =  productspage.getCards();
            //Products page
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            //IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement product in products)
            {

                if (expectedproducts.Contains(product.FindElement(productspage.getCardTitle()).Text))
                {
                    product.FindElement(productspage.getAddToCartButton()).Click();
                }
                TestContext.Progress.WriteLine(product.FindElement(productspage.getCardTitle()).Text);



            }
            // checkout button
            //driver.FindElement(By.PartialLinkText("Checkout")).Click();
           CheckoutPage checkoutpage =  productspage.checkOut();

            // Checkout Page
             IList<IWebElement> checkoutcards =  checkoutpage.getCards();


            for (int i = 0; i < checkoutcards.Count; i++)
            {
                actualproducts[i] = checkoutcards[i].Text;
            }
            Assert.AreEqual(expectedproducts, actualproducts);

            //Final checkout button
            //driver.FindElement(By.CssSelector("button[class='btn btn-success']")).Click();
            PurchasePage purchasepage = checkoutpage.FinalCheckOutButton();

            // Success Page

           
                purchasepage.CountrySelect("ind");
            purchasepage.waitElementVisible();
            SuccessPage successpage = purchasepage.finalsteps();

           //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
           //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
         
            //driver.FindElement(By.LinkText("India")).Click();
            //driver.FindElement(By.CssSelector("label[for='checkbox2']")).Click();
            //driver.FindElement(By.CssSelector("input[value='Purchase']")).Click();
            String confitmText = successpage.getConfirmText().Text;
            StringAssert.Contains("Success", confitmText);

            TestContext.Progress.WriteLine(confitmText);

        }

        // Second class

        [Test]
        public void Test2()
        {

            driver.Value.FindElement(By.Id("username")).SendKeys("abc");
            driver.Value.FindElement(By.Id("username")).Clear();
            driver.Value.FindElement(By.Id("username")).SendKeys("Rahul");
            driver.Value.FindElement(By.CssSelector("#password")).SendKeys("Learning");
            //Radio button
            driver.Value.FindElement(By.XPath("//label[2]//span[2]")).Click();
            driver.Value.FindElement(By.CssSelector("#okayBtn")).Click();


           // driver.FindElement(By.XPath("//select[@class='form-control']")).Click();
           // driver.FindElement(By.CssSelector("option[value='teach']")).Click();
            driver.Value.FindElement(By.CssSelector("#terms")).Click();
            driver.Value.FindElement(By.CssSelector("#signInBtn")).Click();
            //Thread.Sleep(4000)
            TestContext.Progress.WriteLine("@@@@@@@@@@@@@Checking erro message @@@@@@@@@@@@@@@@@@@@");

            //Explicit wait
            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .TextToBePresentInElementValue(driver.Value.FindElement(By.CssSelector("#signInBtn")), "Sign In"));

            String error = driver.Value.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(error);

                  }


        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser()
                .extractData("password"),getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("usernma_wrong"), getDataParser()
                .extractData("password_wrong"));
            // we can add no. of users
        }

    }
}
