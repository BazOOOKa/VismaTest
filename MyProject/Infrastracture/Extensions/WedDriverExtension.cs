using MyProject.Utilities.Controls;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TestCtCoProject.Infrastracture.Drivers;

namespace TestCtCoProject.Extensions.Infrastracture
{
    public static class WedDriverExtension
    {
        #region Element Extensions
        public static IWebElement Element(this WebDriver webDriver, string cssSelector)
        {
            return webDriver.FindElement(By.CssSelector(cssSelector));
        }

        public static List<IWebElement> Elements(this WebDriver webDriver, string cssSelector)
        {
            return new List<IWebElement>(webDriver.FindElements(By.CssSelector(cssSelector)));
        }

        public static Link Link(this WebDriver webDriver, string cssSelector)
        {
            return new Link(webDriver, webDriver.FindElement(By.CssSelector(cssSelector)));
        }
        public static IWebElement XpathElement(this WebDriver webDriver, string xpath)
        {
            return webDriver.FindElement(By.XPath(xpath));
        }
        #endregion


        public static void GoToUrl(this WebDriver webDriver, string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public static void Refresh(this WebDriver webDriver)
        {
            webDriver.Navigate().Refresh();
        }

        public static void SwitchToNewWindow(this WebDriver webDriver, int w = 1)
        {
            webDriver.SwitchTo().Window(webDriver.WindowHandles[w]);
        }

        //This method is specific, might not be usefull, put it here in case i need to wait in specific way
        private static bool WaitForAjaxToComplete(this WebDriver driver)
        {
            IJavaScriptExecutor javascript = driver.Current as IJavaScriptExecutor;
            var queryStatus = false;
            try
            {
                queryStatus = (bool)javascript.ExecuteScript("return typeof jQuery != 'undefined'");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //TEMP WE NEED JQUERY FREE CLICKS
            }

            if (!queryStatus)
            {
                Console.WriteLine("JQuery is not loaded, wait for ajax is impossible.");
                return false;
            }

            try
            {
                var wait = driver.Wait;
                wait.Until(drv => (bool)javascript.ExecuteScript("return jQuery.active == 0"));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("jquery failed to wait for active but it might be ok, continue. Error:" + ex.Message);
                return false;
            }
        }
    }
}
