using System.Collections.Generic;
using MyProject.Utilities;
using MyProject.Utilities.Controls;
using OpenQA.Selenium;
using TestCtCoProject.Extensions.Infrastracture;
using TestCtCoProject.Infrastracture.Drivers;

namespace TestCtCoProject.PageObjects
{ 
    public class HomePage : BaseObject
    {
        public HomePage(WebDriver webDriver) : base(webDriver)
        {

        }
        public Link CareerLink => Driver.Link("a[href='https://ctco.lv/careers/']");
        
        public Link VacanciesLink 
            => Driver.Link("#navbarCollapse ul.sub-menu li a[href='https://ctco.lv/careers/vacancies/']");
        

    }
}