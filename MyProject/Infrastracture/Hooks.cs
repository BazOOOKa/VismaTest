using BoDi;
using TechTalk.SpecFlow;
using TestCtCoProject.Extensions.Infrastracture;
using TestCtCoProject.Infrastracture.Drivers;

namespace Regression.Tests.Infrastructure
{
    /// <summary>
    /// Code for binding test actions to custom code.
    /// </summary>
    [Binding]
    public class Hooks : InfrastructureSteps
    {
        public Hooks(IObjectContainer objectContainer, WebDriver webDriver)
            : base(objectContainer, webDriver)
        {

        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext,IObjectContainer objectContainer, BrowserSeleniumDriverFactory factory)
        {
            SetupBeforeFeature(featureContext, objectContainer, factory);
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext featureContext)
        {
            CleanUpAfterFeature(featureContext);
        }

        [BeforeScenario]
        public void BeforeScenarioSetup()
        {
            //ScenarioStopwatch.Start();
            SetupBeforeScenario();
        }

        [AfterScenario]
        public void AfterScenario(FeatureContext featureContext, BrowserSeleniumDriverFactory factory)
        {
           
            AfterScenarioTearDown(featureContext, factory);
        }

        [AfterStep]
        public void AfterStepScreenshot()
        {
            AfterStep();
            //We can add here cloud or local directory to store screenshots
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {

        }

        [BeforeStep]
        public void BeforeStepSetup()
        {
            
        }
    }
}
