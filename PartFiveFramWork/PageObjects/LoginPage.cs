using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartFiveFramWork.PageObjects
{
    public class LoginPage
    {
        
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.CssSelector, Using = "#password")]
        private IWebElement password;

        //[FindsBy(How = How.CssSelector, Using = "#terms")]
        //private IWebElement checkbox;


        [FindsBy(How = How.CssSelector, Using = "#signInBtn")]
        private IWebElement signbtn;

        public ProductsPage validlogin(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            //checkbox.Click();
            signbtn.Click();

            return new ProductsPage(driver);

        }
        public IWebElement getUserName()
        {
            return username;
        }

    }
}
