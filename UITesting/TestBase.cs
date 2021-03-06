﻿
//#define MSUnit
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using AutomationTest.Generic.Configuration;
using AutomationTest.Generic.Utils;
using AutomationTest.UITesting.Controls;
using AutomationTest.Generic.Asserts;

#if MSUnit
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

#if NUnit
using NUnit.Framework;
#endif


namespace AutomationTest.UITesting
{

    public abstract class TestBase
    {
        public DriverContext DriverContext
        {
            get
            {
                return new HtmlDriverContextFactory().CreateDriverContext();
            }
        }

        public DriverContext ScreenshotDriver
        {
            get
            {
                return new HtmlDriverContextFactory().CreateDriverContext();
                //return HtmlDriverContext.GetInstance();
            }
        }

        public Action TakeScreenshot(string screenshotName)
        {
            return () => ScreenshotDriver.TakeScreenshot(Path.Combine(this.TestResultsDirectory, screenshotName));
        }

#if MSUnit
        /// <summary>
        /// Get test context using MS unit test framework.
        /// </summary>
        public TestContext TestContext { get; set; }
#endif

        /// <summary>
        /// Get or set test case name.
        /// </summary>
        protected string TestName
        {
            get
            {
#if MSUnit
                return this.TestContext.TestName;
#endif
#if NUnit
                string testFullName = NUnit.Framework.TestContext.CurrentContext.Test.Name;
                Regex reg = new Regex(@"(\w*)(\()*");
                string methodName = reg.Match(testFullName).Groups[1].Value;

                return methodName;
#endif
            }
        }

        /// <summary>
        /// Get test data directory.
        /// </summary>
        protected string TestDataDirectory
        {
            get
            {
                return GlobalSetting.Config.DataInDirectory;
            }
        }

        /// <summary>
        /// Get test temp folder directory.
        /// </summary>
        protected string TestTempDirectory
        {
            get
            {
                return GlobalSetting.Config.TempDirectory;
            }
        }

        /// <summary>
        /// Get test results directory.
        /// </summary>
        protected string TestResultsDirectory
        {
            get
            {
                return Path.Combine(GlobalSetting.Config.TestResultDirectory, this.TestName);
            }
        }

#if MSUnit
        protected UnitTestOutcome TestOutcome
        {
            get
            {
                return TestContext.CurrentTestOutcome;
            }
        }
#endif

#if NUnit
        protected TestStatus TestOutcome
        {
            get
            {
                return NUnit.Framework.TestContext.CurrentContext.Result.Status;
            }
        }
#endif

        protected bool IsTestFailed
        {
            get
            {
#if MSUnit
                if (TestOutcome != UnitTestOutcome.Passed || !Verify.Errors.Count.Equals(0))
#endif
#if NUnit
                if (TestOutcome != NUnit.Framework.TestStatus.Passed || !Verify.Errors.Count.Equals(0))
#endif
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        /// <summary>
        /// Initialize test environment.
        /// </summary>
        protected virtual void TestEnvironmentInitialize()
        {
            Log.GetInstance(this.TestResultsDirectory, this.TestName);
            Log.Started(this.TestName);
            OS.DisableTurnOffDisplay();
            OS.DisableWindowsUpdate();
            OS.DisableSleep();
            KillReleatedProcess();
            DeleteTempFiles();
            CreateOutputFolder();
            CopyFilesToTempFolder("Test");  
        }

        /// <summary>
        /// Clean up test environment.
        /// </summary>
        protected virtual void TestEnvironmentCleanup()
        {
            if (Verify.Errors.Count > 0)
            {
                Assert.Fail();
            }
            Log.Ended(this.TestName);
        }

        protected void Steps(int stepNo, string description)
        { }

        protected void CheckPoint(int checkPointNo, string description)
        { }

        protected void ExecuteTest(Action action)
        { }

        /// <summary>
        /// Kill all releated processes.
        /// </summary>
        private void KillReleatedProcess()
        {
            IList<string> processList = new List<string>();
            string[] processes = { 
                                     "chromedriver",
                                     "chrome",
                                     "ie"
                                 };
            processList = processes;
            ProcessUtil.KillProcesses(processList);
        }

        /// <summary>
        /// Delete all temp files.
        /// </summary>
        private void DeleteTempFiles()
        {
            DirectoryUtil.EmptyFolder(GlobalSetting.Config.TempDirectory);
        }

        /// <summary>
        /// Create output file before test case execution.
        /// </summary>
        private void CreateOutputFolder()
        {
            string outputDirectory = Path.Combine(GlobalSetting.Config.TestResultDirectory, this.TestName);
            DirectoryUtil.CreateFolder(outputDirectory, false);
        }

        /// <summary>
        /// Copy test model to temp folder.
        /// </summary>
        /// <param name="testModel"></param>
        protected virtual void CopyFilesToTempFolder(string testModel)
        {
            string sourceDir = Path.Combine(GlobalSetting.Config.DataInDirectory, testModel);
            FileUtil.CopyFiles(sourceDir, GlobalSetting.Config.TempDirectory);
        }



        private string GetStackTraceMethodName()
        {
            StackTrace st = new StackTrace();
            StackFrame[] sfs = st.GetFrames();
            string methodName="";

            for (int i = 0; i <= sfs.Length; i++ )
            {
                methodName = sfs[i].GetMethod().Name;
                if (i == sfs.Length)
                {
                    methodName = sfs[i].GetMethod().Name;
                    break;
                }
            }
            return methodName;
        }
    }
}
