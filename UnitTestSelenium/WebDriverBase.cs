using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UnitTestSelenium
{
    public class WebDriverBase
    {
        private IWebDriver _driver;

        /// <summary>
        /// Create Instace of browser chrome.
        /// </summary>
        /// <param name="url"></param>
        public void InstanceChrome(string url)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            _driver = driver;


        }
        /// <summary>
        /// Set Text to control
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="texto"></param>
        public void SetText(By selector, string texto)
        {
            IsVisible(selector);
            //var dd = _driver.FindElement(selector);
            _driver.FindElement(selector).SendKeys(texto);
            //dd.SendKeys(texto);
        }

        /// <summary>
        /// Close Browser.
        /// </summary>
        public void CloseBrowser()
        {
            _driver.Close();
        }

        //// metodos nuevos
        ///
        private bool IsClikable(By selector, int time = 0)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(time));
                return wait.Until(ExpectedConditions.ElementToBeClickable(selector)) != null ? true : false;

            }
            catch (Exception)
            {
                return false;
            }

        }

        private bool IsVisible(By selector, int time = 0)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(time));
                return wait.Until(ExpectedConditions.ElementIsVisible(selector)) != null ? true : false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public void MoveToElement(By selector)
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)_driver;
            je.ExecuteScript("arguments[0].scrollIntoView(false);", _driver.FindElement(selector));
        }

        public void IsVisible { get; set; }

    }
}
