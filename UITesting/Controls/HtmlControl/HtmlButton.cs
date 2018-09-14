using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace AutomationTest.UITesting.Controls
{
    public class HtmlButton : HtmlControl, IButton 
    {
        public HtmlButton()
            : base()
        { }

        public HtmlButton(ILocator locator)
            : base(locator)
        { 
        }

        public HtmlButton(ILocator locator, string frame)
            : base(locator, frame)
        { }

    }
}
