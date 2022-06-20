using MyProject.Infrastracture.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCtCoProject.Infrastracture.Drivers;

namespace MyProject.Utilities.Controls
{
    public class Link : PowerControl
    {
        public Link(WebDriver driver, IWebElement webElement) : base(driver, webElement)
        {

        }

        public new void Click()
        {
            this.ClickAndLoadPage();
        }
    }
}
