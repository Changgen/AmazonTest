using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.UITesting.Controls
{
    public class HtmlCheckBox : HtmlControl 
    {
        public HtmlCheckBox()
            : base()
        { }

        public HtmlCheckBox(ILocator locator)
            : base(locator)
        { 
        }

        public HtmlCheckBox(ILocator locator, string frame)
            : base(locator, frame)
        { }
    }
}
