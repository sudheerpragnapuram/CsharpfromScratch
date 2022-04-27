using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSelFramwork.PageObject
{
    public class PurchasePage
    {
        IWebDriver driver;
        public PurchasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        // driver.FindElement(By.CssSelector("#country")).SendKeys("ind");
        //driver.FindElement(By.LinkText("India")).Click();
        //driver.FindElement(By.CssSelector("label[for='checkbox2']")).Click();
        //driver.FindElement(By.CssSelector("input[value='Purchase']")).Click();
        

        [FindsBy(How = How.CssSelector, Using = "#country")]
        private IWebElement countryselect;

        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement clickindia;


        [FindsBy(How = How.CssSelector, Using = "label[for='checkbox2']")]
        private IWebElement checkbox;

        [FindsBy(How = How.CssSelector, Using = "input[value='Purchase']")]
        private IWebElement purchasebutton;

        //driver.FindElement(By.CssSelector(".alert.alert-success.alert-dismissible"))
        //[FindsBy(How = How.CssSelector, Using = ".alert.alert-success.alert-dismissible")]
        //private IWebElement confirmtext;

        public void waitElementVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(12));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
        }

        public void CountrySelect(string name)
        {
            countryselect.SendKeys(name);
            
        }
        public SuccessPage finalsteps()
        {
            clickindia.Click();
            checkbox.Click();
            purchasebutton.Click();
            return new SuccessPage(driver);
        }
       
        //public IWebElement getConfirmText()
        //{
        //    return confirmtext;
        //}



    }
}
