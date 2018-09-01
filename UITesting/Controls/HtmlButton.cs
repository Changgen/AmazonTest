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

        /// <summary>
        /// Click on specified location of current control or element.
        /// </summary>
        /// <param name="coordinate"></param>
        public void Click(int xCoordinate, int yCoordinate)
        {
            ClickOnElement(this, xCoordinate, yCoordinate);
        }

        /// <summary>
        /// Double click on current element.
        /// </summary>
        public void DoubleClick()
        {
            DoubleClickOnElement(this);
        }

        /// <summary>
        /// Double click on specifed coordinate of current element.
        /// </summary>
        /// <param name="coordinate"></param>
        public void DoubleClick(int xCoordinate, int yCoordinatee)
        {
            DoubleClickOnElement(this, xCoordinate, xCoordinate);
        }
    }
}
