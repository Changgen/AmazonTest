using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.UITesting.Controls
{
    public abstract class DriverContext : ITakeSnapshot
    {
        public abstract void TakeScreenshot(string screenshotName);

        public abstract Action TakeSnapshot(string screenshotName);

    }
}
