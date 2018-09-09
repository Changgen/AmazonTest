using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomationTest.UITesting;
using AutomationTest.Generic.Utils;

namespace AmazonTest.TestCase
{
    [TestClass]
    public class ProjectTestBase : TestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            TestEnvironmentInitialize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestEnvironmentCleanup();
        }

        protected virtual void CreateDSNFile()
        {
            string dsnFile = Path.Combine(GlobalSetting.Config.TempDirectory, "Demo.dsn");
            FileUtil.CreateFile(dsnFile);
            FileUtil.AppendText(dsnFile, "124", true);
            FileUtil.AppendText(dsnFile, "222", true);
            FileUtil.AppendText(dsnFile, "2234", true);
        }
    }
}
