using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium;

namespace AutomationTest.UITesting.Controls
{
    public class HtmlControl : HtmlDriverContext, IControl<IWebElement> 
    {
        private ILocator locator;

        public HtmlControl()
        {
            this.waitTimeout = GlobalSettings.Config.ControlActiveTimeout;
            SetFrameActive();
        }

        public HtmlControl(ILocator locator) 
            : this()
        {
            this.locator = locator;
        }

        public HtmlControl(ILocator locator, string frame)
            : this(locator)
        {
            SetFrameActive(frame);
        }

        /// <summary>
        /// Get the locator of current control.
        /// </summary>
        public ILocator Locator
        {
            get 
            {
                return this.locator;
            }
        }

        /// <summary>
        /// Get the element of current control.
        /// </summary>
        public IWebElement Element
        {
            get { return FindElement(locator); }
        }

        /// <summary>
        /// Get the location of current control.
        /// </summary>
        public Point Location
        {
            get
            {
                return this.Element.Location;
            }
        }

        /// <summary>
        /// Get the size of current control.
        /// </summary>
        public Size Size
        {
            get
            {
                return this.Element.Size;
            }
        }

        /// <summary>
        /// Get rectangle of this control.
        /// </summary>
        public override Rectangle Rectangle
        {
            get
            { 
                Rectangle rectangle = new Rectangle();
                rectangle.X = this.Element.Location.X;
                rectangle.Y = this.Element.Location.Y;
                rectangle.Height = this.Element.Size.Height;
                rectangle.Width = this.Element.Size.Width;
                return rectangle;
            }
        }

        /// <summary>
        /// Get a value indicating that whether this control is enabled or not.
        /// </summary>
        public bool Enabled
        {
            get
            {
                return this.Element.Enabled;
            }
        }

        /// <summary>
        /// Get a value indicating that whether this control is selected or not.
        /// </summary>
        public bool Selected
        {
            get
            {
                return this.Element.Selected;
            }
        }

        /// <summary>
        /// Get the inner text on this control.
        /// </summary>
        public string Text
        {
            get
            {
                return this.Element.Text;
            }
        }

        /// <summary>
        /// Clear context in this control.
        /// </summary>
        protected void Clear()
        {
            this.Element.Click();
            this.Element.Clear();
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Return true if current element exist.
        /// </summary>
        /// <returns></returns>
        public bool Exist()
        {
            return false;
        }

        /// <summary>
        /// Return a value that indicating whether current element exist or not at specified timeout.
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public bool Exist(int timeout)
        {
            return Exist(this, timeout);
        }

        /// <summary>
        /// Get specified property of current control or element.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string GetProperty(string propertyName)
        {
            return this.Element.GetProperty(propertyName);
        }

        /// <summary>
        /// Sendkeys to current element.
        /// </summary>
        /// <param name="text"></param>
        public void SendKeys(string text)
        {
            this.Element.SendKeys(text);
            Thread.Sleep(1000);
        }
    }
}
