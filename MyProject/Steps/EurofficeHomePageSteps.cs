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
    class EurofficeHomePageSteps
    {
        private Driver myDriver;
        private EurofficeHomePage emergenPage;
        private EurofficeRegistrationPage registrationPage;

        public EurofficeHomePageSteps(Driver driver)
        {
            myDriver = driver;
            emergenPage = new EurofficeHomePage(myDriver.WebDriver);
            registrationPage = new EurofficeRegistrationPage(myDriver.WebDriver);
        }

        [When(@"User navigate to EurOffice Home Page")]
        public void GivenUserNavigateToHomePage()
        {
            myDriver.WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["eurOfficeUrl"]);
            emergenPage.EurOfficePageTItle.ElementIsVisible();
        }

        [When(@"User clicks on Euroffice Rewards")]
        public void WhenUserClickOnEurofficeRewards()
        {
            emergenPage.EurofficeRewardsLink.Click();
            emergenPage.EurofficeRewardsTitle.ElementIsVisible();
        }

        [Then(@"User cannnot choose the rewards without signing into the system")]
        public void ThenUserCannnotChoseTheRewardsWithoutSigningIntoTheSystem()
        {
            if (emergenPage.RegisterButtons[0].ElementIsVisible())
            {
                emergenPage.CustomerFavouritesProductList[0].Click();
                emergenPage.AccountSignInTtle.ElementIsVisible();
            }
        }

        [When(@"Click On Registration Button")]
        public void WhenClickOnRegistrationButton()
        {
            emergenPage.RegisterButtons[1].Click();
            registrationPage.RegistrationPageTitle.ElementIsVisible();
        }
    }
}
