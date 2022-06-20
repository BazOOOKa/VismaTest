using System.Collections.Generic;
using System.Linq;
using MyProject.Infrastracture.Extensions;
using MyProject.Utilities;
using MyProject.Utilities.Controls;
using OpenQA.Selenium;
using TestCtCoProject.Extensions.Infrastracture;
using TestCtCoProject.Infrastracture.Drivers;

namespace TestCtCoProject.PageObjects
{ 
    public class VacancyPage : BaseObject
    {
        public VacancyPage(WebDriver webDriver) : base(webDriver)
        {

        }
        public Link CareerLink => Driver.Link("a[href='https://ctco.lv/careers/vacancies/test-automation-engineer-3/'");
        public IWebElement VacanciesTitle
            => Driver.Element("div.js-vacancies-top-left div:nth-child(1) h1");
        
        public IWebElement ProfessionalSkillsParagraph
            => Driver.Element(".vacancies-second-contents.active p:nth-of-type(1)");

        public Link TestAutomationEngeneerDetails
            => Driver.Link("div.vacancies-main .table-display .second-information-menu-inner li a[href='https://ctco.lv/careers/vacancies/test-automation-engineer-3/']");


        public IList<IWebElement> ProfesstionalSkillsRequirementList
            => Driver.Elements("div.vacancies-second-contents.active ul:first-of-type li");

        public int GetCountOfSkills()
        {
            return ProfesstionalSkillsRequirementList.Count;
        }
        public string GetVacancyTitleText()
        {
            return VacanciesTitle.Text;
        }

        public void VacanciesTitleIsPresent()
        {
             Driver.WaitUntilElementIsExist(".js-min-full-height div.vacancies-menu-block:first-child div.text-block h1");
        }
        
        public void TestAutomationTitleIsPresent()
        {
           
             Driver.WaitUntilElementIsExist(".vacancies-second-contents.active");
        }
        




    }
}
