using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutomationTest.UITesting.Extensions;

namespace AutomationTest.UITesting.Controls
{
    public class HtmlComboBox : HtmlControl, IComboBox
    {
        public HtmlComboBox()
            : base()
        { }

        public HtmlComboBox(ILocator locator)
            : base(locator)
        { }

        public HtmlComboBox(ILocator locator, string frame)
            : base(locator, frame)
        { }

        /// <summary>
        /// Get options of current combobox.
        /// </summary>
        public IList<string> Options
        {
            get 
            {
                IList<string> optionList = new List<string>();
                foreach(IWebElement optionElment in this.Element.ConvertToSelectElement().Options)
                {
                    optionList.Add(optionElment.Text);
                }
                return optionList;            
            }
        }

        /// <summary>
        /// Select options.
        /// </summary>
        /// <param name="option"></param>
        public void Select(string option)
        {
            //this.Element.SelectByValue(option);
            this.Element.SelectByText(option);
        }
    }
}
