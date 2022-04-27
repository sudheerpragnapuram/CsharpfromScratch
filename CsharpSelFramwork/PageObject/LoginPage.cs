using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSelFramwork.PageObject
{
  public class LoginPage
    {
        //driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
        //driver.FindElement(By.CssSelector("#password")).SendKeys("learning");
        //driver.FindElement(By.CssSelector("#signInBtn")).Click();
       IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);

        }
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.CssSelector, Using = "#password")]
        private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "#signInBtn")]
        private IWebElement signbtn;

        public ProductsPage validLogin(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            signbtn.Click();
            return new ProductsPage(driver);
        }
        public IWebElement getUserName()
        {
            return username;
        }



    }
}
