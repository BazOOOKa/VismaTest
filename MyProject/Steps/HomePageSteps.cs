using FluentAssertions;
using NUnit.Framework;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using MyProject.PageObjects;
using MyProject.Utils;
using System.Threading;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Interactions;
using FluentAssertions.Execution;

namespace MyProject.Steps
{
    [Binding]
    public class HomePageSteps
    {
        private Driver myDriver;
        private HomePage homePage;
        private Blogpage blogPage;
        private SocialMediaPage socialMedia;

        public HomePageSteps(Driver driver)
        {
            myDriver = driver;
            homePage = new HomePage(myDriver.WebDriver);
            blogPage = new Blogpage(myDriver.WebDriver);
            socialMedia = new SocialMediaPage(myDriver.WebDriver);
        }


        [When(@"User click on Apply button")]
        public void WhenUserClickOnApplyButton()
        {
            homePage.ApplyButton.Click();
        }

        [Then(@"click on blog '(.*)' at the main page")]
        public void ThenClickOnBlogLinkAtTheMainPage(string link)
        {
            myDriver.ScrollToElement(homePage.HyperLinkContainer);
            switch (link)
            {
                case "visma school":
                    myDriver.WaitForElementVisible(blogPage.VismaSchoolLink);
                    myDriver.ClickWithJavaScript(blogPage.VismaSchoolLink);

                    myDriver.SwitchToWindow();
                    blogPage.VismaSchoolTitle.ElementIsVisible();

                    break;

                case "accounting documents":
                   
                    myDriver.WaitForElementVisible(blogPage.AccountingDocumentsLink);
                    myDriver.ClickWithJavaScript(blogPage.AccountingDocumentsLink);

                    myDriver.SwitchToWindow();
                    blogPage.AccountingDocumentsTitle.ElementIsVisible();
                    break;

                case "average earnings":
                    myDriver.WaitForElementVisible(blogPage.AverageEarningsLink);
                    myDriver.ClickWithJavaScript(blogPage.AverageEarningsLink);

                    myDriver.SwitchToWindow();
                    blogPage.AverageEarningsTitle.ElementIsVisible();
                    break;

                default:
                    Assert.False(true, "\"" + link + "\" case undefined");
                    break;
            }
        }

        [Then(@"User changes country to Romania")]
        public void ThenUserChangesCountryTo()
        {
            ScenarioContext.Current["initialUrl"] = myDriver.WebDriver.Url;
            ScenarioContext.Current["BannerTextLV"] = homePage.Banner.Text;
            myDriver.ScrollToBottom();

            myDriver.ClickWithJavaScript(homePage.CountryDropdown);
            homePage.CountryDropdownList[6].Click();
        }


        [Then(@"User can see that web-link and language had been changed according to country")]
        public void ThenUserCanSeeThatWeb_LinkAndLanguageHadBeenChangedAccordingToCountry()
        {
            string newBanner = homePage.Banner.Text;
            string newUrl = myDriver.WebDriver.Url;
            ScenarioContext.Current.Get<string>("initialUrl").Should().NotBe(newUrl);
            ScenarioContext.Current.Get<string>("BannerTextLV").Should().NotBe(newBanner);
        }

        [When(@"User clicks on '(.*)' links and check '(.*)'")]
        public void WhenUserClicksOnLinksAndCheck(string link, string title)
        {
           
            ScenarioContext.Current["initialUrl"] = myDriver.WebDriver.Url;
            string newUrl = null;
            myDriver.ScrollToBottom();

                switch (link.ToLower())
                {
                    case "facebook":
                        myDriver.ClickWithJavaScript(homePage.FacebookLink);
                        myDriver.SwitchToWindow();
                        newUrl = myDriver.WebDriver.Url;
                        ScenarioContext.Current.Get<string>("initialUrl").Should().NotBe(newUrl);
                        newUrl.Should().Contain("www.facebook.com");
                        myDriver.WaitForElementVisible(socialMedia.FacebookVismaTitle);
                        socialMedia.FacebookVismaTitle.Text.Should().Be(title);

                        break;

                    case "linkedin":
                        myDriver.ClickWithJavaScript(homePage.LinkedInLink);
                        myDriver.SwitchToWindow();
                        newUrl = myDriver.WebDriver.Url;
                        ScenarioContext.Current.Get<string>("initialUrl").Should().NotBe(newUrl);
                        newUrl.Should().Contain("www.linkedin.com");
                        /* 
                         After some changes at Visma Web site or in LindedIn Website now it's impossible to 
                         take a look on Visma Page in LinkedIn without authorization, I don't want to share here my credentials for that.   
                        */

                        //myDriver.WaitForElementVisible(socialMedia.LinkedInVismaTitle);
                        //socialMedia.LinkedInVismaTitle.Text.Should().Be(title);
                    break;

                    case "blog":
                        myDriver.ClickWithJavaScript(homePage.BlogLink);
                        myDriver.SwitchToWindow();
                        newUrl = myDriver.WebDriver.Url;
                        ScenarioContext.Current.Get<string>("initialUrl").Should().NotBe(newUrl);
                        newUrl.Should().Contain("blogs");
                        myDriver.WaitForElementVisible(blogPage.VismaBlogMainPageTitle);
                        blogPage.VismaBlogMainPageTitle.Text.Should().Be(title);
                    break;

                    default:
                        Execute.Assertion.FailWith("Case undefined for key: {0}, {1}", link, title);
                    break;
                }
            
        }
    }
}