using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;

namespace AutomationTest.UITesting.Events
{

    /// <summary>
    /// Before Capabilities Set Handler. <see href="https://github.com/ObjectivityLtd/Test.Automation/wiki/Advanced-Browser-Capabilities-and-options">More details on wiki</see>
    /// </summary>
    public class CapabilitiesSetEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CapabilitiesSetEventArgs"/> class.
        /// </summary>
        /// <param name="capabilities">The existing capabilities</param>
        public CapabilitiesSetEventArgs(DesiredCapabilities capabilities)
        {
            this.Capabilities = capabilities;
        }

        /// <summary>
        /// Gets the current capabilities
        /// </summary>
        public DesiredCapabilities Capabilities { get; set;}
    }
}
