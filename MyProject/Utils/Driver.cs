using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.Linq.Expressions;
using FluentAssertions;
using NUnit.Framework;
using FluentAssertions.Execution;
using System.Threading;

namespace MyProject.Utils
{
    [Binding]
    public class Driver
    {
        public IWebDriver WebDriver;
        private const int WAIT_SECONDS = 8;
        private static Type[] typesToIgnore = new Type[]{
            typeof(ArgumentException),
            typeof(NoSuchElementException),
            typeof(NotImplementedException),
            typeof(InvalidOperationException),
            typeof(ElementNotVisibleException),
            typeof(StaleElementReferenceException)
        };

        public Driver(string browser)
        {
            DriverInitialization(browser);
        }

        private void DriverInitialization(string browserName)
        {
            Console.WriteLine($"WebDriver initizalization. Browser choosen: {browserName}");
            switch (browserName)
            {
                case "ChromeLocal":
                    WebDriver = new ChromeDriver();
                    WebDriver.Manage().Window.Maximize();
                    break;
                default:
                    throw new KeyNotFoundException($"Wrong Browser name: {browserName}. Please choose correct.");
            }
        }

        public WebDriverWait GetNewWebDriverWait()
        {
            return new WebDriverWait(WebDriver,
                TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings["explicitTimeout"])));
        }

        public void DriverTermination()
        {
            Console.WriteLine("WebDriver termination.");
            if (WebDriver != null)
            {
                WebDriver.Quit();
            }
        }

        public void SwitchToWindow()
        {
            WebDriver.WindowHandles.Count.Should().Be(2);
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles[1]);
        }

        public void CloseNewTab()
        {
            if (WebDriver.WindowHandles.Count.Equals(2))
            {
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles[1]);
                WebDriver.Close();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles[0]);
            }
        }

        public void ScrollToBottom()
        {
            IJavaScriptExecutor js = WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(1000);
        }

        public void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView();", element);
        }

        internal bool IsElementPresent(IWebElement element)
        {
            try
            {
                if (element.Displayed || !element.Displayed) return true;
            }
            catch { }
            return false;
        }

        internal void WaitForElementVisible( IWebElement element, int waitSeconds = WAIT_SECONDS)
        {
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            wait.Timeout = TimeSpan.FromSeconds(waitSeconds);
            wait.PollingInterval = TimeSpan.FromMilliseconds(5000);
            wait.IgnoreExceptionTypes(typesToIgnore);
            try
            {
                wait.Until(e => IsElementPresent(e) && e.Displayed);
            }
            catch
            {
                try
                {
                    element.Click();
                }
                catch (Exception e)
                {
                    string message = e.GetBaseException().Message;

                    Execute.Assertion.FailWith(
                        message: $"Element is not visible for {waitSeconds} secods and failed with error : {message}");
                }
            }
            finally
            {
            }
        }

        public void ClickWithJavaScript(IWebElement element)
        {
            ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].click()", element);
            Thread.Sleep(1000);
        }
    }
}