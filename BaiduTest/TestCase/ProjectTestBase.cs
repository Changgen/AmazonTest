using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutomationTest.UITesting;
using AutomationTest.Generic.Asserts;

namespace BaiduTest.TestCase
{
    public class ProjectTestBase : TestBase
    {
        [SetUp]
        public virtual void Initialize()
        {
            //this.TestName = TestContext.CurrentContext.Test.Name;
            Console.WriteLine(TestName);
            TestEnvironmentInitialize();
        }

        [TearDown]
        public virtual void Cleanup()
        {
            //IsTestFailed = TestContext.CurrentContext.Result.Status == TestStatus.Failed || !Verify.Errors.Count.Equals(0);
            TestEnvironmentCleanup();
        }
    }
}
