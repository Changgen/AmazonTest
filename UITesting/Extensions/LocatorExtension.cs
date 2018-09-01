using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AutomationTest.UITesting.Controls;

namespace AutomationTest.UITesting.Extensions
{
    public static class LocatorExtensions
    {
        /// <summary>
        /// Convert to locator By which is used by webdriver.
        /// </summary>
        /// <returns></returns>
        public static By ToBy(this ILocator locator)
        {
            By by;
            switch (locator.Method)
            {
                case LocateMethod.Id:
                    by = By.Id(locator.Value);
                    break;
                case LocateMethod.ClassName:
                    by = By.ClassName(locator.Value);
                    break;
                case LocateMethod.LinkText:
                    by = By.LinkText(locator.Value);
                    break;
                case LocateMethod.Name:
                    by = By.Name(locator.Value);
                    break;
                case LocateMethod.PartialLinkText:
                    by = By.PartialLinkText(locator.Value);
                    break;
                case LocateMethod.TagName:
                    by = By.TagName(locator.Value);
                    break;
                case LocateMethod.XPath:
                    by = By.XPath(locator.Value);
                    break;
                case LocateMethod.CssSelector:
                    by = By.CssSelector(locator.Value);
                    break;
                default:
                    by = By.XPath(locator.Value);
                    break;
            }
            return by;
        }
    }
}
