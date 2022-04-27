using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartFiveFramWork.PageObjects
{
   public class PurchasePage
    {
        private IWebDriver driver;
        public PurchasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //    driver.FindElement(By.CssSelector("#country")).SendKeys("ind");
        //    driver.FindElement(By.LinkText("India")).Click();

        [FindsBy(How = How.CssSelector, Using = "#country")]
        private IWebElement country;

        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement countryName;
        //    driver.FindElement(By.CssSelector("label[for='checkbox2']")).Click();
        //    driver.FindElement(By.CssSelector("input[value='Purchase']")).Click();
        //driver.FindElement(By.CssSelector(".alert.alert-success.alert-dismissible"))
        [FindsBy(How = How.CssSelector, Using = "label[for='checkbox2']")]
        private IWebElement checkboxtwo;

        [FindsBy(How = How.CssSelector, Using = "[value='Purchase']")]
        private IWebElement confirmbutton;

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-success.alert-dismissible")]
        private IWebElement validatingText;

        public void displaycountry(string countryname)
        {
            country.SendKeys(countryname);
        }
        public void elementIsVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
             wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
           
        }

        public void selectcountry()
            {
            countryName.Click();
             checkboxtwo.Click();
            confirmbutton.Click();
        }

        public IWebElement getvalidText()
        {
            return validatingText;
        }

        
    }
}
