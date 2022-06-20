using System;
using System.Collections.ObjectModel;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Html5;
using OpenQA.Selenium.Support.UI;


namespace TestCtCoProject.Infrastracture.Drivers
{
    public class WebDriver : IWebDriver
    {
        private readonly IWebDriver _currentWebDriver;
        private readonly ConfigurationFileDriver _configuration;
        private readonly IObjectContainer _objectContainer;


        private readonly Lazy<WebDriverWait> _waitLazy;

        public WebDriver(
            IWebDriver webDriver,
            ConfigurationFileDriver configurationDriver,
            IObjectContainer objectContainer)
        {
            _currentWebDriver = webDriver;
            _configuration = configurationDriver;
            _objectContainer = objectContainer;

            _waitLazy = new Lazy<WebDriverWait>(() => new WebDriverWait(Current, _configuration.DefaultTimeOut));

        }

        /// <summary>
        ///     Used for accessing configuration.
        /// </summary>
        public ConfigurationFileDriver Configuration => _configuration;

        public IWebDriver Current => _currentWebDriver;

        public WebDriverWait Wait => _waitLazy.Value;

        public string Url { get => _currentWebDriver.Url; set => _currentWebDriver.Url = value; }

        public string Title => _currentWebDriver.Title;

        public string PageSource => _currentWebDriver.PageSource;

        public string CurrentWindowHandle => _currentWebDriver.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => _currentWebDriver.WindowHandles;

        public bool IsSupportCentre => Url.StartsWith(Configuration.SupportCentreUrl);

        public bool IsPortal => Url.StartsWith(Configuration.PortalUrl);

        public bool IsSupplier => Url.StartsWith(Configuration.SupplierUrl);

        public void Close() { _currentWebDriver.Close(); }
        public void Quit() { _currentWebDriver.Quit(); }
        public IOptions Manage() { return _currentWebDriver.Manage(); }
        public INavigation Navigate() { return _currentWebDriver.Navigate(); }
        public ITargetLocator SwitchTo() { return _currentWebDriver.SwitchTo(); }
        public IWebElement FindElement(By by) { return _currentWebDriver.FindElement(by); }
        public ReadOnlyCollection<IWebElement> FindElements(By by) { return _currentWebDriver.FindElements(by); }
        public void TakeScreenshot()
        {
        }
        public void Dispose()
        {
            //NO NEED TO DISPOSE, CLEANING IN HOOKS CLASS
        }

        public ISessionStorage SessionStorage => throw new NotImplementedException($"{Current.GetType()} does not support SessionStorage");

        public ICookieJar Cookies => _currentWebDriver.Manage().Cookies;
    }
}