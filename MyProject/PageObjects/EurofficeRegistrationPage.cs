using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.PageObjects
{
    class EurofficeRegistrationPage
    {
        public EurofficeRegistrationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".checkoutHeader__title")]
        public IWebElement RegistrationPageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#YourDetails_Title")]
        public IWebElement UserTitleDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#Address_FirstName")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#Address_LastName")]
        public IWebElement UserLastName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LoginDetails_Email")]
        public IWebElement UserEmailAddress { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LoginDetails_Password")]
        public IWebElement UserPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span[for='LoginDetails_Email']")]
        public IWebElement IncorrectEmailNotification { get; set; }
    }
}
