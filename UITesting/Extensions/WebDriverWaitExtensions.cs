using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


namespace AutomationTest.UITesting.Extensions
{
    public static class WebDriverWaitExtensions
    {
        private static IClock clock = new SystemClock();
        private static TimeSpan timeout = TimeSpan.FromMilliseconds(500);
        private static TimeSpan sleepInterval = TimeSpan.FromMilliseconds(500);

        public static void Until(this WebDriverWait webDriverWait, Action condition)
        {
            if (condition == null)
            {
                throw new ArgumentNullException("condition", "condition cannot be null");
            }

            Exception lastException = null;
            var endTime = clock.LaterBy(timeout);
            while (true)
            {
                try
                {
                    Console.WriteLine("Click on element");
                    condition();
                    break;
                }
                catch (Exception ex)
                {
                    lastException = ex;
                }

                // Check the timeout after evaluating the function to ensure conditions
                // with a zero timeout can succeed.
                if (!clock.IsNowBefore(endTime))
                {
                    string timeoutMessage = string.Format(CultureInfo.InvariantCulture, "Timed out after {0} seconds", timeout.TotalSeconds);
                    throw new WebDriverTimeoutException(timeoutMessage, lastException);
                }

                Thread.Sleep(sleepInterval);
            }
        }
    }
}
