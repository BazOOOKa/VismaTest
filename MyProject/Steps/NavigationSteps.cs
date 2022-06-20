using Regression.Tests.Infrastructure;
using TechTalk.SpecFlow;
using TestCtCoProject.Extensions.Infrastracture;
using TestCtCoProject.Infrastracture;
using TestCtCoProject.Infrastracture.Drivers;

namespace MyProject.Steps
{
    public class NavigationSteps : BaseSteps
    {
        public NavigationSteps(WebDriver webDriver) : base(webDriver)
        {
           
        }

        [When(@"User navigate on CtCo home page")]
        public void WhenUserNavigateOnCtCoHomePage()
        {
            Driver.GoToUrl(FileConfig.HomePage);
        }
    }
}