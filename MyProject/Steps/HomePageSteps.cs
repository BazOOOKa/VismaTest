
using MyProject.Infrastracture.Extensions;
using TechTalk.SpecFlow;
using TestCtCoProject.Infrastracture;
using TestCtCoProject.Infrastracture.Drivers;
using TestCtCoProject.PageObjects;

namespace MyProject.Steps
{
    public class HomePageSteps : BaseSteps
    {
        private readonly HomePage _homePage;

        public HomePageSteps(WebDriver webDriver) : base(webDriver)
        {
            _homePage = new HomePage(webDriver);
        }

        [When(@"User is opening Vacancy from the Career List")]
        public void WhenUserIsOpeningVacancyFromTheCareerList()
        {
            _homePage.CareerLink.Click();
            //Driver.WaitUntilElementIsDisplayed(_homePage.VacanciesLink);
            _homePage.VacanciesLink.Click();
            Driver.WaitPageToBeLoaded();
        }

    }
}