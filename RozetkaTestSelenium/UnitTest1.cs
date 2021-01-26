using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RozetkaTestSelenium.PageObject.Pages;


namespace RozetkaTestSelenium
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait _wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"D:\F1\F2\IT_Step\4SD\AT\Lab4\chromedriver_win32");
            _wait = new WebDriverWait(driver, new TimeSpan(30));

        }

        [TestCase("ideapad 310")]
        [Repeat(20)]
        public void Test1(string product)
        {
            // 1 go to url
            // 2 change language
            // 3 search model
            // 4 save price
            // 5 open first product
            // 6 check 4 step
            // 7 go back url
            // 8 check price 

            var fmainPage = new FluentMainPage(driver)
                .fgoToPage()
                .fchangeLanguage()
                .fsearchProduct(product);
            var productsPage =new ProductsPage(fmainPage.driver);
            productsPage.load_complete();
            productsPage.savePrice();
            string localPrice = productsPage.price;
            productsPage.goToProduct();
            var productPage = new ProductPage(productsPage.driver);
            productPage.load_complete();
            productPage.savePrice();
            if (double.Parse(localPrice) != double.Parse(productPage.price))
            {
                Assert.Fail();
            }
            productPage.goBack();
            productsPage = new ProductsPage(productPage.driver);
            productsPage.savePrice();
            Assert.AreEqual(double.Parse(localPrice), double.Parse(productsPage.price));
            driver.Quit();
        }
    }
}