using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTest.UITesting;
using AutomationTest.UITesting.Controls;
using OpenQA.Selenium;

namespace BaiduTest.Objects
{
    public class HomePage : ApplicationBase 
    {
        private readonly static string homepageUrl = GlobalSettings.Config.Url;

        public HomePage()
            : base(homepageUrl)
        {
        }

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

        public HtmlComboBox CmbSortBy
        {
            get
            {
                ILocator locator = new Locator(LocateMethod.CssSelector, "select[id='sort'][name='sort']");
                return new HtmlComboBox(locator);
            }
        }
    }
}
