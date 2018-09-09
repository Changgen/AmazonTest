using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.UITesting.Controls
{
    public class HtmlDiv : HtmlControl
    {
        public HtmlDiv()
            : base()
        { }

        public HtmlDiv(ILocator locator)
            : base(locator)
        { 
        }

        public HtmlDiv(ILocator locator, string frame)
            : base(locator, frame)
        { }
    }
}
