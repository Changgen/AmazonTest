using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutomationTest.UITesting.Controls
{
    public class HtmlSpan : HtmlControl 
    {
        public HtmlSpan()
            : base()
        { }

        public HtmlSpan(ILocator locator)
            : base(locator)
        { 
        }

        public HtmlSpan(ILocator locator, string frame)
            : base(locator, frame)
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
