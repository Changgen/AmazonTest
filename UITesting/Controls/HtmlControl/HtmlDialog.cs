using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.UITesting.Controls
{
    public class HtmlDialog : HtmlControl 
    {
        public HtmlDialog()
            : base()
        { }

        public HtmlDialog(ILocator locator)
            : base(locator)
        { 
        }

        public HtmlDialog(ILocator locator, string frame)
            : base(locator, frame)
        { }
    }
}
