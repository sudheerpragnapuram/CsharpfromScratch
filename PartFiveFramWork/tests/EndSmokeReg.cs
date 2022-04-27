using AngleSharp.Text;
using PartFiveFramWork.PageObjects;
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
    public class EndSmokeReg : Base
    {
        [Test, TestCaseSource("AddTestDataConfig"), Category("Regression")]
        //[TestCase("rahulshettyacademy", "learning")]
        //[TestCase("sudheer", "pragnapuram")]

        // Run the tests parallel in 3 ways and to run parallel we have to add Thread safe in Base class
        // run all data ses of test method in parallel [Parallelizable(ParallelScope.All)] 
        //run all test methods in one class parallel  [Parallelizable(ParallelScope.Children)] in class level
        // run all test files in project parallel [Parallelizable(ParallelScope.Self)] in class level

        //**** To Run in Terminal**********

        //dotnet test CSharpFramWork.csproj (All tests)

        //dotnet test CSharpFramWork.csproj --filter TestCategory=Smoke

        //dotnet test CSharpFramWork.csproj --filter TestCategory=Regression --% -- TestRunParameters.Parameter(name=\"newbrowseName\", value=\"Chrome\")

        //dotnet test CSharpFramWork.csproj --filter TestCategory=Smoke --% -- TestRunParameters.Parameter(name=\"newbrowseName\", value=\"Chrome\")

        //dotnet test CSharpFramWork.csproj --% -- TestRunParameters.Parameter(name=\"newbrowseName\", value=\"Chrome\")
        


        // [Parallelizable(ParallelScope.All)]

        public void Test1(String username, String password, String[] expectedproducts)
        {
           // String[] expectedproducts = { "iphone X", "Blackberry" };
            String[] actualproducts = new String[2];

            LoginPage loginpage = new LoginPage(getDriver());
            ProductsPage productpage = loginpage.validlogin(username, password);

            productpage.waitForPageDispaly();
            IList<IWebElement> products = productpage.getCards();

            foreach (IWebElement product in products)
            {

                if (expectedproducts.Contains(product.FindElement(productpage.getCardTitle()).Text))
                {
                    product.FindElement(productpage.addToCartButton()).Click();
                }
                TestContext.Progress.WriteLine(product.FindElement(productpage.getCardTitle()).Text);

            }

            CheckOutPage checkoutpage = productpage.checkout();

            IList<IWebElement> checkoutcards = checkoutpage.getItemsCart();

            for (int i = 0; i < checkoutcards.Count; i++)
            {
                actualproducts[i] = checkoutcards[i].Text;
            }
            Assert.AreEqual(expectedproducts, actualproducts);

            PurchasePage purchasepage = checkoutpage.checkOutButton();

            purchasepage.displaycountry("ind");

            purchasepage.elementIsVisible();
            purchasepage.selectcountry();

            string confitmtext = purchasepage.getvalidText().Text;
            StringAssert.Contains("Success", confitmtext);

            TestContext.Progress.WriteLine(confitmtext);

        }



        [Test, Category("Smoke")]
        public void Test2()
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


        public static IEnumerable<TestCaseData>AddTestDataConfig()
        {
           yield  return new TestCaseData(getDataParser().extractData("username"), getDataParser()
               .extractData("password"), getDataParser().extractDataArray("products"));
           yield return new TestCaseData(getDataParser().extractData("usernma_wrong"), getDataParser()
                .extractData("password_wrong"), getDataParser().extractDataArray("products"));
        }
        
    }
}
