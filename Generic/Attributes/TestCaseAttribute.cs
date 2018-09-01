using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.Generic.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class TestCaseAttribute : Attribute 
    {
        private string testcase;

        /// <summary>
        /// Initialize TestCaseAttribute with testcase id.
        /// </summary>
        /// <param name="testcase"></param>
        public TestCaseAttribute(string testcase)
        {
            this.testcase = testcase;
        }

        /// <summary>
        /// Get testcase id.
        /// </summary>
        public string TestCase
        {
            get { return this.testcase; }
        }
    }
}
