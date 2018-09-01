using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.UITesting.Controls
{
    public class HtmlTextField : HtmlControl, ITextField
    {
        public HtmlTextField()
        {}

        public HtmlTextField(ILocator locator)
            : base(locator)
        { }

        public HtmlTextField(ILocator locator, string frame)
            : base(locator, frame)
        { }

        /// <summary>
        /// Clear content of current text field.
        /// </summary>
        public void ClearContent()
        {
            Clear();
        }

        /// <summary>
        /// Input text to current text field.
        /// </summary>
        /// <param name="text"></param>
        public void InputText(string text)
        {
            ClearContent();
            SendKeys(text);
        }

        /// <summary>
        /// Get text of current text field.
        /// </summary>
        /// <returns></returns>
        public string GetText()
        {
            return this.Text;
        }
    }
}
