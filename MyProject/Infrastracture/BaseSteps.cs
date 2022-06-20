using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TestCtCoProject.Infrastracture.Drivers;

namespace TestCtCoProject.Infrastracture
{
    [Binding]
    public abstract class BaseSteps
    {
        /// <summary>
        ///     Provides access to configuration file.
        /// </summary>
        protected ConfigurationFileDriver FileConfig => Driver.Configuration;

        /// <summary>
        ///     Provides access to Web driver
        /// </summary>
        protected readonly WebDriver Driver;

        protected WebDriverWait Wait => Driver.Wait;

        /// <summary>
        ///     Provides connection to configuration api
        /// </summary>

        public BaseSteps(WebDriver driver)
        {
            Driver = driver;
        }
    }
}
