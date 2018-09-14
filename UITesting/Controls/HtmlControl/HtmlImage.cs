using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutomationTest.UITesting.Controls
{
    public class HtmlImage : HtmlControl, IImage
    {
        public HtmlImage()
            : base()
        { }

        public HtmlImage(ILocator locator)
            : base(locator)
        { }

        /// <summary>
        /// Click on this image.
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
        /// Click on specified location of current image.
        /// </summary>
        /// <param name="coordinate"></param>
        public void Click(int xCoordinate, int yCoordinate)
        {
            ClickOnElement(this, xCoordinate, yCoordinate);
        }

        /// <summary>
        /// Double click on current image.
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

        /// <summary>
        /// Context click on this image.
        /// </summary>
        public void ContextClick()
        {
            ContextClickOnElement(this);
        }

        /// <summary>
        /// Right click on specified coordinate.
        /// </summary>
        /// <param name="coordinate"></param>
        public void ContextClick(int xCoordinate, int yCoordinate)
        {
            ContextClickOnElement(this, xCoordinate, yCoordinate);
        }
    }
}
