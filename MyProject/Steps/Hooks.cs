using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using BoDi;
using TechTalk.SpecFlow;
using MyProject.Utils;

namespace MyProject.Steps
{
    [Binding]
    public class Hooks
    {
        private Driver myDriver;
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void Setup()
        {
            myDriver = new Driver("ChromeLocal");
            _objectContainer.RegisterInstanceAs(myDriver);
        }

        [AfterScenario]
        public void TearDown()
        {
            if (_scenarioContext.TestError != null)
            {
                Utilities.MakeScreenshot(myDriver);
            }

            myDriver.DriverTermination();
        }

        [AfterTestRun]
        public static void AfterTests()
        {
            CloseChromeDriverProcesses();
        }

        private static void CloseChromeDriverProcesses()
        {
            var chromeDriverProcesses = Process.GetProcesses().
                Where(pr => pr.ProcessName == "chromedriver");

            if (chromeDriverProcesses.Count() == 0)
            {
                return;
            }

            foreach (var process in chromeDriverProcesses)
            {
                process.Kill();
            }
        }
    }
}