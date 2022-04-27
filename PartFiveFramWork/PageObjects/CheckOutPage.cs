using PartFiveFramWork.PageObjects;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartFiveFramWork.PageObjects
{
    public class CheckOutPage
    {
        private IWebDriver driver;
        public CheckOutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkitemscart;

        [FindsBy(How = How.CssSelector, Using = "button[class='btn btn-success']")]
        private IWebElement finalCheckOutButton;

        public IList<IWebElement> getItemsCart()
        {
            return checkitemscart;
        }

        public PurchasePage checkOutButton()
        {
            finalCheckOutButton.Click();
            return new PurchasePage(driver);
        }


    }
}
