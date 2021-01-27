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
    class ProductPage
    {
        

        public IWebDriver driver;
        private WebDriverWait _wait;
        Int32 _timeout = 10000;
        public string price;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/div/div[1]/app-rz-product/div/product-tab-main/div[1]/div[1]/div[2]/product-main-info/div/div/div/p")]
        [FindsBy(How = How.CssSelector, Using = "body > app-root > div > div:nth-child(2) > app-rz-product > div > product-tab-main > div:nth-child(1) > div:nth-child(1) > div.product-about__right > product-main-info > div > div > div > p")]
        private IWebElement Price;


        public ProductPage(IWebDriver driver)
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
            price = Price.Text;
            if (price[price.Length - 1] == '₴')
            {
                price = price.Substring(0, price.Length - 1);
            }
            
        }
        public void goBack()
        {
            driver.Navigate().Back();

        }
    }


}