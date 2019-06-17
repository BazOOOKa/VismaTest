using MyProject.PageObjects;
using MyProject.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MyProject.Steps
{
    [Binding]
    class EmergenSteps
    {
        private Driver myDriver;
        private EmergenPage emergenPage;

        public EmergenSteps(Driver driver)
        {
            myDriver = driver;
            emergenPage = new EmergenPage(myDriver.WebDriver);
        }

        [When(@"User navigate to EurOffice Page")]
        public void GivenUserNavigateToHomePage()
        {
            myDriver.WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["eurOfficeUrl"]);
            emergenPage.EurOfficePageTItle.ElementIsVisible();
        }

    }
}
