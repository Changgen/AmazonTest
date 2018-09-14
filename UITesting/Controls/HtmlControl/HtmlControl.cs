using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium;
using AutomationTest.UITesting.Extensions;

namespace AutomationTest.UITesting.Controls
{
    public class HtmlControl : HtmlDriverContext, IControl<IWebElement> 
    {
        private IControl<IWebElement> parent;
        private ILocator locator;

        public HtmlControl()
        {
            this.waitTimeout = GlobalSetting.Config.ControlActiveTimeout;
            SwitchToDefaultContent();
        }

        public HtmlControl(ILocator locator) 
            : this()
        {
            this.locator = locator;
        }

        public HtmlControl(ILocator locator, string frame)
            : this(locator)
        {
            SwitchToFrame(frame);
        }

        public HtmlControl(IControl<IWebElement> parent, ILocator locator)
            : this(locator)
        {
            this.parent = parent;
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
            get 
            {
                if (parent == null)
                {
                    return FindElement(locator);
                }
                else
                {
                    return parent.FindElementEx(locator);
                }
            }
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
            return Exist(this, this.waitTimeout);
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
                Wait.Until(() => this.Element.Click());
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

        /// <summary>
        /// Click on specified text.
        /// </summary>
        /// <param name="text"></param>
        public override void TextClick(string text)
        {
            ILocator locator = new Locator(".//*[text()='" + text + "']");
            IWebElement element = FindElementEx(locator);
            ClickOnElement(element);
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

        /// <summary>
        /// Find child element under current control.
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public IWebElement FindElementEx(ILocator locator)
        {
            return Wait.Until(parent => Element.FindElement(locator.ToBy()));
        }
    }
}
