using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCtCoProject.Infrastracture.Drivers;

namespace MyProject.Utilities.Controls
{
    public class PowerControl : IWebElement
    {
        public readonly WebDriver Driver;
        private readonly IWebElement _webElement;

        public PowerControl(WebDriver webDriver, IWebElement webElement)
        {
            Driver = webDriver;
            _webElement = webElement;
        }

        /// <summary>
        ///     Please, use with care
        /// </summary>
        public IWebElement Current => _webElement;

        public string TagName => _webElement.TagName;

        public string Text => _webElement.Text;

        public bool Enabled => _webElement.Enabled;

        /// <summary>
        /// Returns true if the element has "disabled" attribute. <br></br>
        /// This is different from Enabled property, as that applies only to Input elements (and most of the time returns true).
        /// </summary>
        public bool IsDisabled => _webElement.GetAttribute("disabled") != null;

        public bool Selected => _webElement.Selected;

        public Point Location => _webElement.Location;

        public Size Size => _webElement.Size;

        public bool Displayed => _webElement.Displayed;

        public void Clear()
        {
            _webElement.Clear();
        }

        public void Click()
        {
            _webElement.Click();
        }

        public IWebElement FindElement(By by)
        {
            return _webElement.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return _webElement.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            return _webElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return _webElement.GetCssValue(propertyName);
        }

        public string GetProperty(string propertyName)
        {
            return _webElement.GetProperty(propertyName);
        }

        public void SendKeys(string text)
        {
            _webElement.SendKeys(text);
        }

        public void Submit()
        {
            _webElement.Submit();
        }
    }
}
