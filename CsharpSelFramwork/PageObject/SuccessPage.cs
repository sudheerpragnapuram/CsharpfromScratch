using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSelFramwork.PageObject
{
    public class SuccessPage
    {
        IWebDriver driver;
        public SuccessPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //driver.FindElement(By.CssSelector(".alert.alert-success.alert-dismissible"))
        [FindsBy(How = How.CssSelector, Using = ".alert.alert-success.alert-dismissible")]
        private IWebElement confirmtext;

        public IWebElement getConfirmText()
        {
            return confirmtext;
        }
    }

}