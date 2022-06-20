using OpenQA.Selenium.Support.UI;
using TestCtCoProject.Infrastracture.Drivers;

namespace MyProject.Utilities
{
    public abstract class BaseObject
    {
        protected WebDriver Driver;
        protected WebDriverWait Wait => Driver.Wait;
        public BaseObject(WebDriver driver)
        {
            Driver = driver;
        }
    }
}