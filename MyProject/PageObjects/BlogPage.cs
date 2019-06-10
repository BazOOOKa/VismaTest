using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MyProject.PageObjects
{
    public class Blogpage
    {
        public Blogpage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".site-title  a h1")]
        public IWebElement VismaBlogMainPageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[title='Grāmatvedības dokumentu pārvēršana un glabāšana elektroniskā formātā']")]
        public IWebElement AccountingDocumentsTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[title='Visma Skolu indekss 2019']")]
        public IWebElement VismaSchoolTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[title='Vidējās izpeļņas aprēķināšanas problēmsituācijas']")]
        public IWebElement AverageEarningsTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[title='Grāmatvedības dokumentu pārvēršana un glabāšana elektroniskā formātā']")]
        public IWebElement AccountingDocumentsLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[title='Visma Skolu indekss 2019']")]
        public IWebElement VismaSchoolLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[title='Vidējās izpeļņas aprēķināšanas problēmsituācijas']")]
        public IWebElement AverageEarningsLink { get; set; }
    }
}