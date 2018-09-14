using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using AutomationTest.UITesting.Extensions;
using AutomationTest.Generic;
using AutomationTest.UITesting.Events;
using AutomationTest.Generic.Utils;

namespace AutomationTest.UITesting.Controls
{
    /// <summary>
    /// Provide backend method to find element and operate element on web using web driver.
    /// </summary>
    public class HtmlDriverContext
    {
        /// <summary>
        /// Timeout of waiting element exist.
        /// </summary>
        protected int waitTimeout = GlobalSetting.Config.ApplicationActiveTimeout;
        protected readonly Collection<Exception> exceptions = new Collection<Exception>();

        /// <summary>
        /// Fires before the capabilities are set
        /// </summary>
        protected event EventHandler<CapabilitiesSetEventArgs> CapabilitiesSet;

        /// <summary>
        /// Occurs when [driver options set].
        /// </summary>
        protected event EventHandler<DriverOptionsSetEventArgs> DriverOptionsSet;

        /// <summary>
        /// Driver to be used to locate and operate element on web.
        /// </summary>
        private readonly IWebDriver driver;

        private static HtmlDriverContext driverContext;
        private static readonly object syncObject = new object();

        /// <summary>
        /// Initialize HtmlDriverContext.
        /// </summary>
        protected HtmlDriverContext()
        { }

        /// <summary>
        /// Initialize web driver according to web browser type to be tested.
        /// </summary>
        /// <param name="browser"></param>
        protected HtmlDriverContext(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver(GlobalSetting.Config.DriverDirectory, SetDriverOptions(ChromeProfile), TimeSpan.FromSeconds(GlobalSetting.Config.LoadingTimeout));
                    break;
                case BrowserType.IE:
                    driver = new InternetExplorerDriver(GlobalSetting.Config.DriverDirectory, SetDriverOptions(InternetExplorerProfile));
                    break;
            }
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(GlobalSetting.Config.LoadingTimeout);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(GlobalSetting.Config.AsynchronousJavaScriptTimeout);
        
        }

        protected HtmlDriverContext(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(GlobalSetting.Config.LoadingTimeout);
            this.driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(GlobalSetting.Config.AsynchronousJavaScriptTimeout);

        }

        /// <summary>
        /// Get web driver instance.
        /// </summary>
        public IWebDriver Driver
        {
            get
            {
                if (driverContext.driver == null)
                {
                    throw new NullReferenceException("No web driver specified!");
                }
                return driverContext.driver; 
            }
        }

        private ChromeOptions ChromeProfile
        {
            get
            {
                ChromeOptions options = new ChromeOptions();

                options.AddUserProfilePreference("profile.default_content_settings.popups", 0);
                options.AddUserProfilePreference("download.default_directory", GlobalSetting.Config.TestResultDirectory);
                options.AddUserProfilePreference("download.prompt_for_download", false);

                // if there are any extensions
                if (GlobalSetting.Config.ChromeExtensions != null)
                {
                    // loop through all of them
                    for (var i = 0; i < GlobalSetting.Config.ChromeExtensions.Count; i++)
                    {
                        options.AddExtension(GlobalSetting.Config.ChromeExtensions.GetKey(i));
                    }
                }

                //options.AddArgument("start-maximized");
                // if there are any arguments
                if (GlobalSetting.Config.ChromeArguments != null)
                {
                    // loop through all of them
                    for (var i = 0; i < GlobalSetting.Config.ChromeArguments.Count; i++)
                    {
                        options.AddArgument(GlobalSetting.Config.ChromeArguments.GetKey(i));
                    }
                }

                // custom preferences
                // if there are any settings
                if (GlobalSetting.Config.ChromePreferences == null)
                {
                    return options;
                }

                // loop through all of them
                for (var i = 0; i < GlobalSetting.Config.ChromePreferences.Count; i++)
                {
                    // and verify all of them
                    switch (GlobalSetting.Config.ChromePreferences[i])
                    {
                        // if current settings value is "true"
                        case "true":
                            options.AddUserProfilePreference(GlobalSetting.Config.ChromePreferences.GetKey(i), true);
                            break;

                        // if "false"
                        case "false":
                            options.AddUserProfilePreference(GlobalSetting.Config.ChromePreferences.GetKey(i), false);
                            break;

                        // otherwise
                        default:
                            int temp;

                            // an attempt to parse current settings value to an integer. Method TryParse returns True if the attempt is successful (the string is integer) or return False (if the string is just a string and cannot be cast to a number)
                            if (int.TryParse(GlobalSetting.Config.ChromePreferences.Get(i), out temp))
                            {
                                options.AddUserProfilePreference(GlobalSetting.Config.ChromePreferences.GetKey(i), temp);
                            }
                            else
                            {
                                options.AddUserProfilePreference(GlobalSetting.Config.ChromePreferences.GetKey(i), GlobalSetting.Config.ChromePreferences[i]);
                            }
                            break;
                    }
                }
                return options;
            }
        }

        private InternetExplorerOptions InternetExplorerProfile
        {
            get
            {
                var options = new InternetExplorerOptions
                {
                    EnsureCleanSession = true,
                    IgnoreZoomLevel = true,
                };

                // custom preferences
                // if there are any settings
                if (GlobalSetting.Config.InternetExplorerPreferences == null)
                {
                    return options;
                }

                // loop through all of them
                for (var i = 0; i < GlobalSetting.Config.InternetExplorerPreferences.Count; i++)
                {
                    // and verify all of them
                    switch (GlobalSetting.Config.InternetExplorerPreferences.GetKey(i))
                    {
                        case "EnsureCleanSession":
                            options.EnsureCleanSession = Convert.ToBoolean(GlobalSetting.Config.InternetExplorerPreferences[i], CultureInfo.CurrentCulture);
                            break;

                        case "IgnoreZoomLevel":
                            options.IgnoreZoomLevel = Convert.ToBoolean(GlobalSetting.Config.InternetExplorerPreferences[i], CultureInfo.CurrentCulture);
                            break;
                    }
                }
                return options;
            }
        }
        /// <summary>
        /// Get actions to simulate mouse event and keyboard event.
        /// </summary>
        protected Actions Actions
        {
            get
            {
                return new Actions(this.Driver);
            }
        }

        /// <summary>
        /// Get WebDriverWait instance to wait element exist.
        /// </summary>
        protected WebDriverWait Wait
        {
            get
            {
                return new WebDriverWait(this.Driver, TimeSpan.FromSeconds(waitTimeout));
            }
        }

        /// <summary>
        /// Collection for exceptions.
        /// </summary>
        public Collection<Exception> Exceptions
        {
            get
            {
                return this.exceptions;
            }
        }

        /// <summary>
        /// Get the rectangle of window.
        /// </summary>
        public virtual Rectangle Rectangle
        {
            get
            {
                Rectangle rectangle=new Rectangle();
                rectangle.X = this.Driver.Manage().Window.Position.X;
                rectangle.Y = this.Driver.Manage().Window.Position.Y;
                rectangle.Height = this.Driver.Manage().Window.Size.Height;
                rectangle.Width = this.Driver.Manage().Window.Size.Width;
                return rectangle;           
            }
        }

        /// <summary>
        /// Create instance for driver context.
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        public static HtmlDriverContext CreateInstance(BrowserType browser)
        {
            Log.Trace("Start " + browser + " driver......");
            driverContext = new HtmlDriverContext(browser);
            Log.Trace(driverContext.driver + " started!");

            return driverContext;
        }

        /// <summary>
        /// Get instance from existing driver.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static HtmlDriverContext GetInstance(IWebDriver driver)
        {
            driverContext = new HtmlDriverContext(driver);

            return driverContext;
        }

        /// <summary>
        /// Wait until element exist, exception will be thrown if parameter throwException is true.
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="throwException"></param>
        /// <returns></returns>
        protected bool WaitForExist(ILocator locator, int timeout, bool throwException = true)
        {
            waitTimeout = timeout;
            try 
            {
                Wait.Until(driver => Driver.FindElement(@locator.ToBy()));
                return true;
            }
            catch(Exception ex)
            {
                if (throwException == true)
                {
                    throw new NoSuchElementException("Fail to locate element >>" + locator.Value, ex);
                }

                return false;
            }
        }

        /// <summary>
        /// Wait until element enabled, exception will be thrown if parameter throwException is true.
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="throwException"></param>
        /// <returns></returns>
        protected bool WaitForEnabled(ILocator locator, int timeout, bool throwException = true)
        {
            waitTimeout = timeout;
            try
            {
                Wait.Until(driver => Driver.FindElement(@locator.ToBy()).Enabled);
                return true;
            }
            catch (Exception ex)
            {
                if (throwException == true)
                {
                    throw new ElementNotInteractableException("Element<" + locator.Value + "> is disabled!!!", ex);
                }

                return false;
            }
        }
        /// <summary>
        /// Find element matched specifed locator criteria..
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public IWebElement FindElement(ILocator locator)
        {
            WaitForExist(locator, waitTimeout);
            return this.Driver.FindElement(@locator.ToBy());
        }

        /// <summary>
        /// Find element list mateched specified locator criteria.
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        protected IList<IWebElement> FindElements(ILocator locator)
        {
            WaitForExist(locator, waitTimeout);
            return this.Driver.FindElements(@locator.ToBy());
        }

        /// <summary>
        /// Click on web element.
        /// </summary>
        /// <param name="element"></param>
        protected virtual void ClickOnElement(IWebElement element)
        {
            this.Actions.Click(element).Build().Perform();
            Thread.Sleep(500);
        }

        /// <summary>
        /// Click on specified control or element.
        /// </summary>
        /// <param name="control"></param>
        protected virtual void ClickOnElement(IControl<IWebElement> control)
        {
            this.Actions.Click(control.Element).Build().Perform();
            Thread.Sleep(500);
        }

        /// <summary>
        /// Click on specified offset of top-left of specified control or element.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        protected virtual void ClickOnElement(IControl<IWebElement> control, int xOffset, int yOffset)
        {
            MoveMouseToElementByOffset(control, xOffset, yOffset);
            Thread.Sleep(500);
            ClickOnElement(control);
        }

        /// <summary>
        /// Double click on specified element.
        /// </summary>
        /// <param name="control"></param>
        protected virtual void DoubleClickOnElement(IControl<IWebElement> control)
        {
            this.Actions.DoubleClick(control.Element).Build().Perform();
            Thread.Sleep(500);
        }

        /// <summary>
        /// Double click on specified offset of specified element.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        protected virtual void DoubleClickOnElement(IControl<IWebElement> control, int xOffset = 0, int yOffset = 0)
        {
            MoveMouseToElementByOffset(control, xOffset, yOffset);
            this.Actions.DoubleClick(control.Element).Build().Perform();
            Thread.Sleep(500);
        }

        /// <summary>
        /// Right click on specified control or element.
        /// </summary>
        /// <param name="control"></param>
        protected virtual void ContextClickOnElement(IControl<IWebElement> control)
        {
            this.Actions.ContextClick(control.Element).Build().Perform();
            Thread.Sleep(500);
        }

        /// <summary>
        /// Right click on specified offset of Top-left corner of specified control or element.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        protected virtual void ContextClickOnElement(IControl<IWebElement> control, int xOffset, int yOffset)
        {
            MoveMouseToElementByOffset(control, xOffset, yOffset);
            this.Actions.ContextClick(control.Element).Build().Perform();
            Thread.Sleep(500);
        }

        /// <summary>
        /// Click on specified text area.
        /// </summary>
        /// <param name="text"></param>
        public virtual void TextClick(string text)
        {
            ILocator locator = new Locator("//*[text()='" + text + "']");
            IControl<IWebElement> control = new HtmlControl(locator);
            ClickOnElement(control);
        }

        /// <summary>
        /// Move mouse to specified element.
        /// </summary>
        /// <param name="control"></param>
        protected virtual void MoveMouseToElement(IControl<IWebElement> control)
        {
            this.Actions.MoveToElement(control.Element).Build().Perform();
            Thread.Sleep(500);
        }

        protected virtual void MoveByOffsetOfCurrentPos(int xOffset, int yOffset)
        {
            this.Actions.MoveByOffset(xOffset, yOffset).Build().Perform();
            Thread.Sleep(500);
        }

        /// <summary>
        /// Move mouse to specified offset of specified element.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        protected virtual void MoveMouseToElementByOffset(IControl<IWebElement> control, int xOffset, int yOffset)
        {
            this.Actions.MoveToElement(control.Element, xOffset, yOffset).Build().Perform();
            Thread.Sleep(500);
        }

        /// <summary>
        /// Return true if element exist in specified timeout.
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        protected bool Exist(IControl<IWebElement> control, int timeout)
        {
            return WaitForExist(control.Locator, timeout, false);
        }

        /// <summary>
        /// Set application active before interaction.
        /// </summary>
        public virtual void SetActive()
        { 
        }

        protected virtual void SetWindowActive(string windowName)
        {
            Log.Trace("Switch to window =>" + windowName);
            IList<string> windows = this.Driver.WindowHandles;
            Log.Trace("Active windows: " + windows.ToList());
            foreach (string window in windows)
            {
                if (window == windowName)
                {
                    Log.Trace("Switch to window =>" + window);
                    this.Driver.SwitchTo().Window(window);
                }
            }
            this.Driver.SwitchTo().Window(windowName);
        }

        protected void SwitchToDefaultContent()
        {
            this.Driver.SwitchTo().DefaultContent();
        }

        protected void SwitchToFrame(string frameName)
        {
            this.Driver.SwitchTo().Frame(frameName);
        }

        protected void GoToUrl(string url)
        {
            Log.Trace("Go to url =>" + url);
            this.Driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Take screenshot during test case execution or done.
        /// </summary>
        public static void TakeScreenshot(string fileName)
        {
            Screenshot screenshot = ((ITakesScreenshot)driverContext.Driver).GetScreenshot();
            screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
        }       

        private T SetDriverOptions<T>(T options)
            where T : DriverOptions
        {
            //this.DriverOptionsSet.Invoke(this, new DriverOptionsSetEventArgs(options));
            return options;
        }
    }
}
