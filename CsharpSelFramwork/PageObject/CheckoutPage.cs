using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSelFramwork.PageObject
{
    // List<IWebElement> checkoutcards = driver.FindElements(By.CssSelector("h4 a"));

    
    public class CheckoutPage
    {

        
        IWebDriver driver;
        public CheckoutPage(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //driver.FindElement(By.CssSelector("button[class='btn btn-success']")).Click();
        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutcards;

        [FindsBy(How = How.CssSelector, Using = "button[class='btn btn-success']")]
        private IWebElement finalcheckoutbutton;

        public IList<IWebElement> getCards()
        {
            return checkoutcards;
        }

        public PurchasePage FinalCheckOutButton()
        {
           finalcheckoutbutton.Click();
            return new PurchasePage(driver);

        }


        
    }
}
