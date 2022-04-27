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
    public class ProductsPage
    {
        //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

        //    IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

        //By.CssSelector(".card-title a")
        //  driver.FindElement(By.PartialLinkText("Checkout")).Click();

        private IWebDriver driver;

        By CardTitle = By.CssSelector(".card-title a");
        By addTocart = By.CssSelector(".card-footer button");
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkoutButton;

        public IList<IWebElement> getCards()
        {
            return cards;
        }

        public void waitForPageDispaly()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

        }

        public By getCardTitle()
        {
            return CardTitle;
        }
        public By addToCartButton()
        {
            return addTocart;
        }

        public CheckOutPage checkout()
        {
            checkoutButton.Click();

            return new CheckOutPage(driver);
        }



    }
}
