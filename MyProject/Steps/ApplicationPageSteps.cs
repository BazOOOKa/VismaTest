using FluentAssertions;
using NUnit.Framework;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using MyProject.PageObjects;
using MyProject.Utils;
using static MyProject.Steps.CommonSteps;
using System.Linq;

namespace MyProject.Steps
{
    [Binding]
    public class ApplicationPageSteps
    {
        private Driver myDriver;
        private ApplicationPage appPage;

        public ApplicationPageSteps(Driver driver)
        {
            myDriver = driver;
            appPage = new ApplicationPage(myDriver.WebDriver);
        }

        [Then(@"User navigates to Application Page")]
        public void ThenUserNavigatesToApplicationPage()
        {
            appPage.Title.ElementIsVisible();
        }

        [Then(@"User clicks on Submit button")]
        public void ThenUserClicksOnSubmitButton()
        {
            myDriver.ClickWithJavaScript(appPage.SubmitButton);
        }

        [Then(@"User clicks on Term of Use Checkbox")]
        public void UserClicksOnTermOfUseCheckbox()
        {
            myDriver.ClickWithJavaScript(appPage.TermOfUseCheckbox);
        }

        [Then(@"User can see all input fields '(.*)' as mandatory with '(.*)' message")]
        public void ThenUserCanSeeAllInputFieldsAsMandatoryWithMessage(string Case, string message)
        {
            if (Case == "highlighted")
            {
                appPage.MondatoryInputFieldsErrorNotificationList.Count.Should().Be(5);
                for (int i = 0; i < appPage.MondatoryInputFieldsErrorNotificationList.Count; i++)
                {
                    appPage.MondatoryInputFieldsErrorNotificationList[i].Text.Should().Be(message);
                }
            }
            else if (Case == "not highlighted")
            {
                appPage.MondatoryInputFieldsErrorNotificationList.Count.Should().Be(0);
            }
        }

        [Then(@"User can see checkbox '(.*)' as mandatory")]
        public void ThenUserCanSeeCheckboxAsMandatory(string Case)
        {
            if (Case == "highlighted")
            {
                appPage.CheckboxErrorNotifications.Count.Should().Be(1);
            }
            else if (Case == "not highlighted")
            {
                appPage.CheckboxErrorNotifications.Count.Should().Be(0);
            }
        }

        [Then(@"User '(.*)' see '(.*)' e-mail error")]
        public void ThenUserCanSeeE_MailError(string Case, string error)
        {
            switch (Case)
            {
                case "cannot":
                    appPage.EmailErrorNotification.ElementIsNotVisible();
                    break;
                case "can":
                    appPage.EmailErrorNotification.Text.Should().Be(error);
                    break;
            }
        }

        [Then(@"User fills all mandatory fields")]
        public void ThenUserFillsAllMandatoryFields(Table table)
        {
            foreach (var row in table.Rows)
            {
                switch (row["ItemList"].ToLower())
                {
                    case "name":
                        appPage.NameInputField.Clear();
                        appPage.NameInputField.SendKeys(row["Value"]);
                        break;
                    case "surname":
                        appPage.LastNameInputField.Clear(); ;
                        appPage.LastNameInputField.SendKeys(row["Value"]);
                        break;
                    case "company name":
                        appPage.CompanyNameInputField.Clear(); ;
                        appPage.CompanyNameInputField.SendKeys(row["Value"]);
                        break;
                    case "phone":
                        appPage.PhoneInputField.Clear(); ;
                        appPage.PhoneInputField.SendKeys(row["Value"]);
                        break;
                    case "e-mail":
                        appPage.EmailInputField.Clear(); ;
                        appPage.EmailInputField.SendKeys(row["Value"]);
                        break;
                    
                    default:
                        Assert.False(true, "\"" + row["ItemList"] + "\" case undefined");
                        break;
                }
            }
        }

        [Then(@"User returns back to the home page")]
        public void ThenUserReturnsBackToTheHomePage()
        {
            myDriver.ClickWithJavaScript(appPage.VismaTitle);
        }
    }
}


