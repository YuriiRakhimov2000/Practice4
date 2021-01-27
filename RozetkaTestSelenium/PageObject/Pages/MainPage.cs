using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace RozetkaTestSelenium.PageObject.Pages
{
    class MainPage
    {
        String test_url = "https://rozetka.com.ua";

        public IWebDriver driver;
        private WebDriverWait _wait;
        Int32 timeout = 10000;

        [FindsBy(How = How.XPath,
            Using = "/html/body/app-root/div/div[1]/app-rz-header/header/div/div[1]/ul[2]/li[2]/a")]
        [CacheLookup]
        private IWebElement UALangLink;

        [FindsBy(How = How.XPath,
            Using = "/html/body/app-root/div/div[1]/app-rz-header/header/div/div[2]/div[2]/form/button")]
        [CacheLookup]
        private IWebElement searchButton;


        [FindsBy(How = How.Name, Using = "search")] [CacheLookup]
        private IWebElement searchField;



        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        

        public void goToPage()
        {
            driver.Navigate().GoToUrl(test_url);
            loadComplete();
        }

        public void loadComplete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor) d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void changeLanguage()
        {
            try
            {
                UALangLink.Click();
                loadComplete();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
            }
            
        }

        public void searchProduct(string product)
        {
            searchField.SendKeys(product);
            searchButton.Click();
            loadComplete();
        }


    };
    //Practice 15
    //My Little Wrapper
    class FluentMainPage : MainPage
    {
        public FluentMainPage(IWebDriver driver) : base(driver)
        {
        }

        public FluentMainPage fgoToPage()
        {
            goToPage();
            return this;
        }
       

        public FluentMainPage floadComplete()
        {
           loadComplete();
           return this;
        }

        public FluentMainPage fchangeLanguage()
        {
            changeLanguage();
            return this;
        }

        public FluentMainPage fsearchProduct(string product)
        {
            searchProduct(product);
            return this;
        }



    }
}
