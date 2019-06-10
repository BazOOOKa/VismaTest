using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace MyProject.PageObjects
{
    class SocialMediaPage
    {
        public SocialMediaPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "div.top-card__details div h1")]
        public IWebElement LinkedInVismaTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "._64-f span")]
        public IWebElement FacebookVismaTitle { get; set; }
    }
}