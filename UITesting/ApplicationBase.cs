using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AutomationTest.Generic.Utils;

namespace AutomationTest.UITesting.Controls
{
    public abstract class ApplicationBase : HtmlDriverContext
    {
        private IWebDriver driver;
        private string windowHandle;

        protected string url;

        public ApplicationBase()
        {
            this.waitTimeout = GlobalSetting.Config.ApplicationActiveTimeout;
            this.driver = this.Driver;
            this.windowHandle = this.Driver.CurrentWindowHandle;
        }

        public ApplicationBase(string url) 
        {
            this.waitTimeout = GlobalSetting.Config.ApplicationActiveTimeout;
            HtmlDriverContext.CreateInstance(GlobalSetting.Config.Browser);
            this.driver = this.Driver;
            this.windowHandle = this.Driver.CurrentWindowHandle;
            Log.Trace("Current driver =>" + this.Driver);
            Log.Trace("Current WindowHandle =>" + windowHandle);
            this.url = url;
            GoToUrl(url);
        }


        public string WindowHandle
        {
            get
            {
                return this.Driver.CurrentWindowHandle;
            }
        }

        public override void SetActive()
        {
            HtmlDriverContext.GetInstance(driver);
            SetWindowActive(windowHandle);
        }

        public void Maximize()
        {
            this.Driver.Manage().Window.Maximize();
        }

        public void Minimize()
        {
            this.Driver.Manage().Window.Minimize();
        }

        public void Refresh()
        {
            this.Driver.Navigate().Refresh();
        }

        public void Forward()
        {
            this.Driver.Navigate().Forward();
        }

        public void Back()
        {
            this.Driver.Navigate().Back();
        }

        public void Exit()
        {
            this.Driver.Close();
            this.Driver.Quit();
        }

        public void MoveMouseTo(IControl<IWebElement> control)
        {
            MoveMouseToElement(control);
        }

        public void MoveMouseTo(ILocator locator)
        {
            IControl<IWebElement> element = new HtmlControl(locator);
            MoveMouseToElement(element);
        }

        /// <summary>
        /// Move mouse to specified xpath on current page.
        /// </summary>
        /// <param name="xPath"></param>
        public void MoveMouseTo(string xPath)
        {
            ILocator locator = new Locator(xPath);
            IControl<IWebElement> element = new HtmlControl(locator);
            MoveMouseToElement(element);
        }
    }
}
