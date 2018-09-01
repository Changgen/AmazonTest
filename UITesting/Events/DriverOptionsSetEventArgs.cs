using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationTest.UITesting.Events
{
    /// <summary>
    /// Before Capabilities Set Handler. <see href="https://github.com/ObjectivityLtd/Test.Automation/wiki/Advanced-Browser-Capabilities-and-options">More details on wiki</see>
    /// </summary>
    public class DriverOptionsSetEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DriverOptionsSetEventArgs" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public DriverOptionsSetEventArgs(DriverOptions options)
        {
            this.DriverOptions = options;
        }

        /// <summary>
        /// Gets the current capabilities
        /// </summary>
        public DriverOptions DriverOptions { get; set; }
    }
}
