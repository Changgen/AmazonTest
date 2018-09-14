using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutomationTest.UITesting.Controls
{
    public class HtmlHyperLink : HtmlControl, IHyperLink
    {
        public HtmlHyperLink()
            : base()
        { }

        public HtmlHyperLink(ILocator locator)
            : base(locator)
        { }

        /// <summary>
        /// Click on this control.
        /// </summary>
        public void Click()
        {
            try
            {
                this.Element.Click();
            }
            catch
            {
                ClickOnElement(this);
            }

            Thread.Sleep(1000);
        }
    }
}
