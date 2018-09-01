using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTest.UITesting.Extensions
{
    public static class WebElementExtensions
    {
        /// <summary>
        /// Extension method to convert web element to select element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static SelectElement ConvertToSelectElement(this IWebElement element)
        {
            return new SelectElement(element);
        }

        /// <summary>
        /// Extension method to select option by value.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectByValue(this IWebElement element, string value)
        {
            ConvertToSelectElement(element).SelectByValue(value);
        }

        public static void SelectByText(this IWebElement element, string text)
        {
            ConvertToSelectElement(element).SelectByText(text);
        }

    }
}
