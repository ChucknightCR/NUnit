using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace NUnit1
{
    public class Program
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        [Test]
        public void ValidarLogin()
        {
            //login
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");  // 
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            // Waiting for inventory
            wait.Until(d => d.Url.Contains("inventory.html"));  // Wait for the URL so it can get "inventory.html", if it gets the inventory.html it is fine.

            //Add to cart
            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            driver.FindElement(By.Id("checkout")).Click();
            Thread.Sleep(1000);


            //Checkout info
            driver.FindElement(By.Id("first-name")).SendKeys("Juan");
            driver.FindElement(By.Id("last-name")).SendKeys("Rodriguez");
            driver.FindElement(By.Id("postal-code")).SendKeys("20245");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("continue")).Click();

            Thread.Sleep(1000);

            //Finish the purchase
            driver.FindElement(By.Id("finish")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.Id("back-to-products")).Click();
            Thread.Sleep(1000);

        }


        //Now we will test login into a different website.
        [Test]
        public void LoginHero()
        {
            //Open the website
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            //Login
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.ClassName("radius")).Click();

            Thread.Sleep(3000);
        }





        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}