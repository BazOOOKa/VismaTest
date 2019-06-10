using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.PageObjects
{
    public class ApplicationPage
    {
        public ApplicationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "a[title='Visma.lv']")]
        public IWebElement VismaTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Piesakieties individuālai prezentācijai!')]")]
        public IWebElement Title { get; set; }

        [FindsBy(How = How.Id, Using = "input-name")]
        public IWebElement NameField { get; set; }

        [FindsBy(How = How.Id, Using = "input-email")]
        public IWebElement EmailField { get; set; }

        [FindsBy(How = How.Id, Using = "input-enquiry")]
        public IWebElement EnquiryField { get; set; }

        [FindsBy(How = How.Name, Using = "submit")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".epi-form-required input[type=checkbox]")]
        public IWebElement TermOfUseCheckbox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[data-eloqua-html-field=firstName] input")]
        public IWebElement NameInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[data-eloqua-html-field=lastName] input")]
        public IWebElement LastNameInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[data-eloqua-html-field=company] input")]
        public IWebElement CompanyNameInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[data-eloqua-html-field=busPhone] input")]
        public IWebElement PhoneInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[data-eloqua-html-field=emailAddress] input")]
        public IWebElement EmailInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[data-eloqua-html-field='emailAddress'] span")]
        public IWebElement EmailErrorNotification { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ValidationFail > span[style='display: block;']")]
        public IList<IWebElement> MondatoryInputFieldsErrorNotificationList { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".input-container  > span[style='display: block;']")]
        public IList<IWebElement> CheckboxErrorNotifications { get; set; }
    }
}