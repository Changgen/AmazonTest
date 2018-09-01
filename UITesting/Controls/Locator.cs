using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationTest.UITesting.Controls
{
    /// <summary>
    /// Locate method for UI control or web element.
    /// </summary>
    public enum LocateMethod
    {
        /// <summary>
        /// The Id selector
        /// </summary>
        Id,

        /// <summary>
        /// The class name selector
        /// </summary>
        ClassName,

        /// <summary>
        /// The link text selector
        /// </summary>
        LinkText,

        /// <summary>
        /// The name selector
        /// </summary>
        Name,

        /// <summary>
        /// The partial link text selector
        /// </summary>
        PartialLinkText,

        /// <summary>
        /// The tag name selector
        /// </summary>
        TagName,

        /// <summary>
        /// The XPath selector
        /// </summary>
        XPath,

        /// <summary>
        /// The CSS selector
        /// </summary>
        CssSelector,
    }

    /// <summary>
    /// Represents locator of UI control or element.
    /// </summary>
    public class Locator : ILocator
    {
        private LocateMethod method = LocateMethod.XPath;
        private string value;

        /// <summary>
        /// Initialize locator with value.
        /// Default method XPath will be used.
        /// </summary>
        /// <param name="value"></param>
        public Locator(string value)
        {
            this.value = value;
        }

        /// <summary>
        /// Initialize locator with method and value.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="value"></param>
        public Locator(LocateMethod method, string value)
            : this(value)
        {
            this.method = method;
        }

        /// <summary>
        /// Get locate method used.
        /// </summary>
        public LocateMethod Method
        {
            get { return this.method; }
        }

        /// <summary>
        /// Get locator value.
        /// </summary>
        public string Value
        {
            get { return this.value; }
        }

        ///// <summary>
        ///// Convert to locator By which is used by webdriver.
        ///// </summary>
        ///// <returns></returns>
        //public By ToBy()
        //{ 
        //    By by;
        //    switch (this.method)
        //    {
        //        case LocateMethod.Id:
        //            by = By.Id(this.value);
        //            break;
        //        case LocateMethod.ClassName:
        //            by = By.ClassName(this.value);
        //            break;
        //        case LocateMethod.LinkText:
        //            by = By.LinkText(this.value);
        //            break;
        //        case LocateMethod.Name:
        //            by = By.Name(this.value);
        //            break;
        //        case LocateMethod.PartialLinkText:
        //            by = By.PartialLinkText(this.value);
        //            break;
        //        case LocateMethod.TagName:
        //            by = By.TagName(this.value);
        //            break;
        //        case LocateMethod.XPath:
        //            by = By.XPath(this.value);
        //            break;
        //        case LocateMethod.CssSelector:
        //            by = By.CssSelector(this.value);
        //            break;
        //        default:
        //            by = By.XPath(this.value);
        //            break;
        //    }

        //    return by;
        //}
    }
}
