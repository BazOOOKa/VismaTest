using MyProject.Utils;
using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;

namespace MyProject.Steps
{
    [Binding]
    class CommonSteps
    {
        private Driver myDriver;

        public CommonSteps(Driver driver)
        {
            myDriver = driver;
        }

        [When(@"User navigate to Home Page")]
        public void GivenUserNavigateToHomePage()
        {
            myDriver.WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["vismaUrl"]);
        }

        public class CommonList
        {
            public string ItemList { get; set; }
            public string Value { get; set; }
        }

        
    }
}
