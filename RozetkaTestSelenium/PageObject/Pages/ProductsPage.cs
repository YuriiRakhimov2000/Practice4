using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace RozetkaTestSelenium.PageObject.Pages
{
    class ProductsPage
    {

        public IWebDriver driver;
        private WebDriverWait _wait;
        public string price;
        Int32 _timeout = 10000;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/div/div[1]/rz-search/rz-catalog/div/div[2]/section/rz-grid/ul/li[1]/app-goods-tile-default/div/div[2]/div[4]/div[2]/p/span[1]")]
        [CacheLookup]
        private IWebElement FirstElementPrice;

        [FindsBy(How = How.CssSelector, Using = "body > app-root > div > div:nth-child(2) > rz-search > rz-catalog > div > div.layout.layout_with_sidebar > section > rz-grid > ul > li:nth-child(1) > app-goods-tile-default > div > div.goods-tile__inner > a.goods-tile__heading > span")]
        [FindsBy(How = How.XPath, Using = "/html/body/app-root/div/div[1]/rz-search/rz-catalog/div/div[2]/section/rz-grid/ul/li[1]/app-goods-tile-default/div/div[2]/a[2]/span")]
        [CacheLookup]
        private IWebElement Product;

       


        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        public void load_complete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(_timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void savePrice()
        {
            price = FirstElementPrice.Text;
        }


        public void goToProduct()
        {
            Product.Click();
            load_complete();
        }

    }
}