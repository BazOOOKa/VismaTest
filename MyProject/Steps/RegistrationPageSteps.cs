using MyProject.PageObjects;
using MyProject.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MyProject.Steps
{
    [Binding]
    class RegistrationPageSteps
    {
        private Driver myDriver;
        private EurofficeRegistrationPage registrationPage;


        public RegistrationPageSteps(Driver driver)
        {
            myDriver = driver;
            registrationPage = new EurofficeRegistrationPage(myDriver.WebDriver);
        }

        [Then(@"User fills mandatory fields on Registration Page")]
        public void ThenUserFillsMandatoryFieldsOnRegistrationPage(Table table)
        {
            foreach (var row in table.Rows)
            {
                switch (row["ItemList"].ToLower())
                {
                    case "user name":
                        registrationPage.UserName.Clear();
                        registrationPage.UserName.SendKeys(row["Value"]);
                        break;

                    case "user lastname":
                        registrationPage.UserLastName.Clear(); ;
                        registrationPage.UserLastName.SendKeys(row["Value"]);
                        break;

                    case "user password":
                        registrationPage.UserPassword.Clear(); ;
                        registrationPage.UserPassword.SendKeys(row["Value"]);
                        break;

                    case "user emailaddress":
                        registrationPage.UserEmailAddress.Clear(); ;
                        registrationPage.UserEmailAddress.SendKeys(row["Value"]);
                        break;

                    default:
                        Assert.False(true, "\"" + row["ItemList"] + "\" case undefined");
                        break;
                }
            }
        }

        [When(@"User clicks to register as a personal Customer")]
        public void WhenUserClicksToRegisterAsAPersonalCustomer()
        {
            registrationPage.RegisrationAsAPerson.Click();
        }


        [Then(@"User can see wrong email notification")]
        public void ThenUserCanSeeWrongEmailNotification()
        {
            registrationPage.IncorrectEmailNotification.ElementIsVisible();
        }
    }
}
