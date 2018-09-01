using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.Generic.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class HeadlineAttribute : Attribute 
    {
        private string headline;

        /// <summary>
        /// Initialize HeadlineAttribute.
        /// </summary>
        /// <param name="headline"></param>
        public HeadlineAttribute(string headline)
        {
            this.headline = headline;
        }

        /// <summary>
        /// Get test case headlie.
        /// </summary>
        public string Headline
        {
            get { return this.headline; }
        }
    }
}
