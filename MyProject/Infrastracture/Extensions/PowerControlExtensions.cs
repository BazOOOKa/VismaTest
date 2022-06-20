using MyProject.Utilities.Controls;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestCtCoProject.Infrastracture.Drivers;

namespace MyProject.Infrastracture.Extensions
{
    public static class PowerControlExtensions
    {
        public static void ClickAndWaitAjax(this PowerControl clickTarget)
        {
            WebDriver driver = clickTarget.Driver;

            clickTarget.Click();

            CheckWaitjQuery(driver);
        }

        public static void ClickAndWaitAjax(this IWebElement clickTarget, WebDriver driver)
        {
            clickTarget.Click();
            CheckWaitjQuery(driver);
        }

        public static void WaitUntilElementIsDisplayed(this WebDriver driver, IWebElement elementToShow)
        {
            var wait = driver.Wait;
            driver.Wait.Until((d) => elementToShow.Displayed && elementToShow.Enabled);
            CheckWaitjQuery(driver);
        }

        public static void WaitUntilElementIsExist(this WebDriver driver, string cssSelector)
        {
            var wait = driver.Wait;
            //There is better solution for that, but i have only one evening to finilize this task, so i'm 
            //using internal extenstion library, not the perfect one but 100% stable  
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(cssSelector)));
        }

        public static void WaitPageToBeLoaded(this WebDriver driver)
        {
            WaitForPageToLoad(driver);
        }

        public static void ClickAndWaitUntilDisplayed(this PowerControl clickTarget, IWebElement dependentElement)
        {
            WebDriver driver = clickTarget.Driver;
            clickTarget.Click();

            clickTarget.Driver.Wait.Until((d) => dependentElement.Displayed && dependentElement.Enabled);

            CheckWaitjQuery(driver);
        }

        public static void ClickAndLoadPage(this PowerControl clickTarget)
        {
            WebDriver driver = clickTarget.Driver;
            clickTarget.Click();

            WaitForPageToLoad(driver);
        }

        public static void ScrollIntoView(this PowerControl element)
        {
            var javascript = (IWebDriver)element.Driver.Current as IJavaScriptExecutor;
            var wait = element.Driver.Wait;

            javascript.ExecuteScript("arguments[0].scrollIntoView();", element.Current);
            wait.Until(drv => element.Displayed);
        }

        public static void ScrollToBottom(WebDriver driver)
        {
            var javascript = (IWebDriver)driver.Current as IJavaScriptExecutor;
            javascript.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public static void ScrollToTop(WebDriver driver)
        {
            var javascript = (IWebDriver)driver.Current as IJavaScriptExecutor;
            javascript.ExecuteScript("window.scrollTo(0, 0);");
        }

        private static void CheckWaitjQuery(WebDriver driver)
        {
            var wait = driver.Wait;

            var javascript = (IWebDriver)driver.Current as IJavaScriptExecutor;
            var doesjQueryExists = false;

            try
            {
                doesjQueryExists = (bool)javascript.ExecuteScript("return typeof jQuery != 'undefined'");
            }
            catch
            {
                //TEMP WE NEED JQUERY FREE CLICKS
            }

            if (!doesjQueryExists)
            {
                Console.WriteLine("JQuery is not loaded, wait for ajax is impossible.");
                return;
            }

            try
            {
                driver.Wait.Until(drv => (bool)javascript.ExecuteScript("return jQuery.active == 0"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("jQuery failed to wait for active but it might be ok, continue. Error:" + ex.Message);
            }
        }

        /// <summary>
        /// Wait for document.readyState is 'complete'. DOM elements are accessible and sub-resources are loaded.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        private static void WaitForPageToLoad(WebDriver driver)
        {
            var javascript = (IWebDriver)driver.Current as IJavaScriptExecutor;
            if (javascript == null)
                return;//We can't execute anything, so just return

            while (true)
            {
                var loaded = (bool)javascript.ExecuteScript("return document.readyState").Equals("complete")
                    || (bool)javascript.ExecuteScript("return document.readyState").Equals("interactive");

                if (loaded)
                    break;

                Thread.Sleep(100);
            }
        }
    }
}
