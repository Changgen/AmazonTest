using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.ComponentModel;
using System.Globalization;
using AutomationTest.Generic.Utils;
using AutomationTest.Generic;

namespace AutomationTest.UITesting
{
    public sealed class GlobalSetting
    {
        //Project
        private readonly string project = ConfigurationManager.AppSettings["Project"];
        private readonly string tempFolder = ConfigurationManager.AppSettings["TempFolder"];
        private readonly string dataInFolder = ConfigurationManager.AppSettings["DataInFolder"];
        private readonly string testResultFolder = ConfigurationManager.AppSettings["TestResultFolder"];
        private readonly string browser = ConfigurationManager.AppSettings["Browser"];
        private readonly string url = ConfigurationManager.AppSettings["Url"];
        private readonly string solutionDirectory = DirectoryUtil.GetCurrentSolutionDirectory();
        //private readonly string projectDirectory = DirectoryUtil.GetProjectDirectory(solutionDirectory, project);
        //Timeout
        private readonly int loadingTimeout = Convert.ToInt16(ConfigurationManager.AppSettings["LoadingTimeout"], CultureInfo.CurrentCulture);
        private readonly int asynchronousJavaScriptTimeout = Convert.ToInt16(ConfigurationManager.AppSettings["AsynchronousJavaScriptTimeout"], CultureInfo.CurrentCulture);
        private readonly int implicitWaitTimeout = Convert.ToInt16(ConfigurationManager.AppSettings["ImplicitWaitTimeout"], CultureInfo.CurrentCulture);
        private readonly int applicationActiveTimeout = Convert.ToInt16(ConfigurationManager.AppSettings["ApplicationActiveTimeout"], CultureInfo.CurrentCulture);
        private readonly int windowActiveTimeout = Convert.ToInt16(ConfigurationManager.AppSettings["WindowActiveTimeout"], CultureInfo.CurrentCulture);
        private readonly int controlActiveTimeout = Convert.ToInt16(ConfigurationManager.AppSettings["ControlActiveTimeout"], CultureInfo.CurrentCulture);
        private readonly string driverFolder =ConfigurationManager.AppSettings["DriverFolder"]; 
        // retrieving settings from config file
        private readonly NameValueCollection chromePreferences = ConfigurationManager.GetSection("ChromePreferences") as NameValueCollection;
        private readonly NameValueCollection chromeExtensions = ConfigurationManager.GetSection("ChromeExtensions") as NameValueCollection;
        private readonly NameValueCollection chromeArguments = ConfigurationManager.GetSection("ChromeArguments") as NameValueCollection;

        private readonly NameValueCollection internetExplorerPreferences = ConfigurationManager.GetSection("InternetExplorerPreferences") as NameValueCollection;

        public GlobalSetting()
        { 
        }


        public static GlobalSetting Config
        {
            get
            {
                return new GlobalSetting();
            }
 
        }

        /// <summary>
        /// Get test browser.
        /// </summary>
        public BrowserType Browser
        {
            get
            {
                switch (browser)
                {
                    case "Chrome":
                        return BrowserType.Chrome;
                    case "IE":
                        return BrowserType.IE;
                    default:
                        throw new NullReferenceException(browser+"is not supported!");
                }
            }
        }

        public string Url
        {
            get
            {
                return url;
            }
        }

        public string ProjectDirectory
        {
            get
            {
                return DirectoryUtil.GetCurrentProjectDirectory();
            }
        }

        public string DriverDirectory
        {
            get
            {
                return Path.Combine(solutionDirectory, driverFolder);
            }
        }

        /// <summary>
        /// Get directory of temp folder.
        /// </summary>
        public string TempDirectory
        {
            get
            {
                return Path.Combine(ProjectDirectory, tempFolder);
            }
        }

        /// <summary>
        /// Get directory of data in folder.
        /// </summary>
        public string DataInDirectory
        {
            get
            {
                return Path.Combine(ProjectDirectory, dataInFolder);
            }
        }

        /// <summary>
        /// Get the directory of test result.
        /// </summary>
        public string TestResultDirectory
        {
            get
            {
                return Path.Combine(solutionDirectory, testResultFolder);
            }
        }

        public NameValueCollection ChromePreferences
        {
            get
            {
                return chromePreferences;
            }
        }

        public NameValueCollection ChromeExtensions
        {
            get
            {
                return chromeExtensions;
            }
        }

        public NameValueCollection ChromeArguments
        {
            get
            {
                return chromeArguments;
            }
        }

        public NameValueCollection InternetExplorerPreferences
        {
            get
            {
                return internetExplorerPreferences;
            }
        }

        public int LoadingTimeout
        {
            get
            {
                return loadingTimeout;
            }
        }

        public int ApplicationActiveTimeout
        {
            get { return applicationActiveTimeout; }
        }

        public int AsynchronousJavaScriptTimeout
        {
            get { return asynchronousJavaScriptTimeout; }
        }

        public int ImplicitWaitTimeout
        {
            get { return implicitWaitTimeout; }
        }

        public int WindowActiveTimeout
        {
            get { return windowActiveTimeout; }
        }

        public int ControlActiveTimeout
        {
            get { return controlActiveTimeout; }
        }
    }
}
