using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace MyProject.PageObjects
{
    public class HomePage
    {
        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".list-unstyled a[href*='contact']")]
        public IWebElement ContactUsLink { get; set; }

        [FindsBy(How = How.Id, Using = "input-name")]
        public IWebElement NameField { get; set; }

        [FindsBy(How = How.Id, Using = "input-email")]
        public IWebElement EmailField { get; set; }

        [FindsBy(How = How.Id, Using = "input-enquiry")]
        public IWebElement EnquiryField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type='submit']")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "cta")]
        public IWebElement ApplyButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".choices__list--dropdown > div")]
        public IWebElement CountryDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[role=option]")]
        public IList<IWebElement> CountryDropdownList { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".frontpage-banner > figure  div  h2")]
        public IWebElement Banner { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[title='Visma Skolu indekss 2019']")]
        public IWebElement VismaSchoolLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "[title='Vidējās izpeļņas aprēķināšanas problēmsituācijas']")]
        public IWebElement AccountingDocumentsLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Grāmatvedības dokumentu pārvēršana un glabāšana elektroniskā formātā")]
        public IWebElement AverageEarningsLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[data-accept-cookies=true]")]
        public IWebElement AcceptCoockies { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".newsticker")]
        public IWebElement HyperLinkContainer { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Facebook')]")]
        public IWebElement FacebookLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'LinkedIn')]")]
        public IWebElement LinkedInLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Blog')]")]
        public IWebElement BlogLink { get; set; }
    }
}