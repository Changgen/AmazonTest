using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTest.UITesting.Controls;

namespace BaiduTest.Objects
{
    public class BaiduSearchPage : ApplicationBase
    {

        public HtmlTextField TxtSearch
        {
            get
            {
                ILocator locator = new Locator(LocateMethod.CssSelector, "input[id='kw'][name='wd']");
                return new HtmlTextField(locator);
            }
        }

        public HtmlButton BtnGo
        {
            get
            {
                ILocator locator = new Locator(LocateMethod.CssSelector, "input[id='su']");
                return new HtmlButton(locator);
            }
        }

        public HtmlHyperLink hlkImage
        {
            get
            {
                ILocator locator = new Locator(LocateMethod.CssSelector, "a[onmousedown*='pic']");
                return new HtmlHyperLink(locator);
            }
        }

        
    }
}
