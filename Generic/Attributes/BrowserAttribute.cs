using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.Generic.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class BrowserAttribute : Attribute
    {
        private BrowserType type;

        /// <summary>
        /// Initialize BrowserAttribute with browser.
        /// </summary>
        /// <param name="browser"></param>
        public BrowserAttribute(BrowserType browser)
        {
            this.type = browser;
        }

        /// <summary>
        /// Get browser type.
        /// </summary>
        public BrowserType Type
        {
            get { return this.type; }
        }
    }
}
