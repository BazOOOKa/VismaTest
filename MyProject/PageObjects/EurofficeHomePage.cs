using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.PageObjects
{
    class EurofficeHomePage
    {
        public EurofficeHomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".masthead__logo")]
        public IWebElement EurOfficePageTItle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[data-eventlabel='EUROFFICE REWARDS']")]
        public IWebElement EurofficeRewardsLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#custom-page-header img[alt='Euroffice Rewards']")]
        public IWebElement EurofficeRewardsTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.masthead__myAccountTabSignIn strong")]
        public IList<IWebElement> RegisterButtons  { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.productListItem__link header > h1")]
        public IList<IWebElement> CustomerFavouritesProductList  { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".checkoutHeader__title")]
        public IWebElement AccountSignInTtle  { get; set; }

    }
}
