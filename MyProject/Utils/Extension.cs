using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Linq.Expressions;
using FluentAssertions;

namespace MyProject.Utils
{
    public static class Extensions
    {
        private static TimeSpan timeout = TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings["explicitTimeout"]));
        
        public static bool ElementIsVisible(this IWebElement element)
        {
            bool isDisplayed = true;
            try
            {
                if (!element.Displayed)
                {
                    isDisplayed = false;
                }
            }
            catch
            {
                isDisplayed = false;
            }
            return isDisplayed;
        }

        public static bool ElementIsNotVisible(this IWebElement element)
        {
            bool isDisplayed = false;
            try
            {
                if (element.Displayed)
                {
                    isDisplayed = false;
                }
            }
            catch
            {
                isDisplayed = true;
            }
            return isDisplayed;
        }
    }
}