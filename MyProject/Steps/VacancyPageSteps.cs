using FluentAssertions;
using MyProject.Infrastracture.Extensions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TestCtCoProject.Infrastracture;
using TestCtCoProject.Infrastracture.Drivers;
using TestCtCoProject.PageObjects;

namespace MyProject.Steps
{
    public class VacancyPageSteps : BaseSteps
    {
        private readonly VacancyPage _vacancyPage;

        public VacancyPageSteps(WebDriver webDriver) : base(webDriver)
        {
            _vacancyPage = new VacancyPage(webDriver);
        }


        [When(@"User is able to open Vacancy with Test Automation Engineer title")]
        public void WhenUserIsAbleToOpenVacancyWithTitle()
        {
            _vacancyPage.VacanciesTitleIsPresent();
            _vacancyPage.TestAutomationEngeneerDetails.Click();
        }

        [Then(@"User can verify exactly count of skills in the paragraph Professional skills and qualification")]
        public void ThenUserCanVerifyExactlyCountOfSkillsInTheParagraphProfessionalSkillsAndQualification()
        {
            _vacancyPage.TestAutomationTitleIsPresent();
            
            //I added this waituntilDisplayed method, because i wanted to print out the list of skills to my console 
            // but elements on page are appearing from bottom to top and sometimes it is printing out not full list of skills
            //so to prevent this case i implemented this method to make it 100% stable
            Driver.WaitUntilElementIsDisplayed(_vacancyPage.ProfessionalSkillsParagraph);

            var listOfSkills = _vacancyPage.ProfesstionalSkillsRequirementList;
            List<string> expectedSkillsList = new List<string>();
            
            _vacancyPage.GetCountOfSkills().Should().Be(8);
            for (int i = 0; i < listOfSkills.Count; i++)
            {
                expectedSkillsList.Add(listOfSkills[i].Text);
            }

            Console.WriteLine("There are " + _vacancyPage.GetCountOfSkills() + " skills required");
            expectedSkillsList.ForEach(x => Console.Write("\n {0}\t", x));

        }
    }
}