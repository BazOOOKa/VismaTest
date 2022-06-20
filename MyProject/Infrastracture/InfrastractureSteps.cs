using System;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TestCtCoProject.Infrastracture.Drivers;

namespace TestCtCoProject.Extensions.Infrastracture
{
    public class InfrastructureSteps : TechTalk.SpecFlow.Steps
    {
        private const string CHROME_BROWSER_KEY = "browser.chrome";

        private readonly IObjectContainer _objectContainer;
        private readonly WebDriver _webDriver;

        public InfrastructureSteps(IObjectContainer objectContainer, WebDriver webDriver)
        {
            _objectContainer = objectContainer;
            _webDriver = webDriver;
        }

        /// <summary>
        ///     #1
        /// </summary>
        public static void SetupBeforeFeature(FeatureContext featureContext, IObjectContainer objectContainer, BrowserSeleniumDriverFactory factory)
        {
            //Opening chrome
            var browser = factory.GetChrome();

            //need to register interface to be reused across the project
            objectContainer.RegisterInstanceAs<IWebDriver>(browser);

            //store reference to browser in feature context
            featureContext.Add(CHROME_BROWSER_KEY, browser);
        }

        /// <summary>
        ///     #2
        /// </summary>
        public void SetupBeforeScenario()
        {
            
        }

        /// <summary>
        ///     #3
        /// </summary>
        public void BeforeStep()
        {

        }

        /// <summary>
        ///     #4
        /// </summary>
        public void AfterStep()
        {
            _webDriver.TakeScreenshot();

            Console.WriteLine(_webDriver.Url);
        }


        /// <summary>
        ///     #5
        /// </summary>
        public void AfterScenarioTearDown(FeatureContext featureContext, BrowserSeleniumDriverFactory factory)
        {
            if (_webDriver == null)
                return; 

            if (this.ScenarioContext.TestError != null)
            {
                _webDriver.TakeScreenshot();
            }
            else
            {
            }

            try
            {
                featureContext.TryGetValue(CHROME_BROWSER_KEY, out object browser);
                if (browser != null)
                {
                    var chrome = (ChromeDriver)browser;
                    factory.ResetBrowser(chrome);
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }

        /// <summary>
        ///     #6
        /// </summary>
        public static void CleanUpAfterFeature(FeatureContext featureContext)
        {
            featureContext.TryGetValue(CHROME_BROWSER_KEY, out object browser);
            if (browser != null)
            {
                var chrome = (ChromeDriver)browser;

                try
                {
                    chrome.Close();
                    chrome.Quit();
                }
                catch (Exception)
                {
                    //just ignore, this can happen if Chrome is manually closed.
                }
            }
        }
    }
}
