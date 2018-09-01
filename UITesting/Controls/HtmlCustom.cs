using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AutomationTest.UITesting.Controls
{
    public class HtmlCustom : HtmlControl 
    {
        public HtmlCustom()
            : base()
        { }

        public HtmlCustom(ILocator locator)
            : base(locator)
        { }

        /// <summary>
        /// Click on specified location of current control or element.
        /// </summary>
        /// <param name="coordinate"></param>
        public void Click(int xCoordinate, int yCoordinate)
        {
            ClickOnElement(this, xCoordinate, yCoordinate);
        }

        /// <summary>
        /// Right click on specified coordinate.
        /// </summary>
        /// <param name="coordinate"></param>
        public void ContextClick(int xCoordinate, int yCoordinate)
        {
            ContextClickOnElement(this, xCoordinate, yCoordinate);
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
        /// Move mouse to specified location.
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        public void MoveMouseTo(int xCoordinate, int yCoordinate)
        {
            MoveMouseToElement(this);
            MoveByOffsetOfCurrentPos(xCoordinate, yCoordinate);
        }

        /// <summary>
        /// Move mouse by specified offset of current element.
        /// </summary>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        public void MoveMouseByOffset(int xOffset, int yOffset)
        {
            MoveMouseToElementByOffset(this, xOffset, yOffset);
        }
    }
}
