using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutomationTest.Generic.Utils
{
    public sealed class Log
    {
        private readonly string logDir;
        private readonly string logFileName;

        private static DateTime startDateTime;

        private static Log log;

        private Log(string logDir, string fileName)
        {
            this.logDir = logDir;
            this.logFileName = fileName;
        }

        public string FullName
        {
            get { return Path.Combine(logDir, logFileName + ".log"); }
        }

        public static Log GetInstance(string logDir, string fileName)
        {
            log = new Log(logDir, fileName);
            return log;
        }

        public static void Trace(string message)
        {
            WriteInformation(message);
        }

        public static void Started(string title)
        {
            startDateTime = DateTime.Now;
            Info("*********************************************************************************************************************************");
            Info("Test case: " + title, title);
            Info("Log file: " + log.FullName, log.FullName);
            Info("Start time: " + startDateTime, startDateTime);
            Info("Log started>>>" );
        }

        public static void Ended(string title)
        {
            var endDateTime = DateTime.Now;
            var elapsed = (endDateTime - startDateTime).TotalMilliseconds / 1000d;
            Info("Test case: " + title, title);
            Info("Stop time: " + endDateTime, endDateTime);
            Info("Execution time: " + elapsed, elapsed);
            Info("Log ended<<<");
            Info("*********************************************************************************************************************************");
        }

        public static void Info(string message, params object[] args)
        {
            WriteInformation(message, false);
        }

        private static void WriteInformation(string message, bool writeDate = true)
        {
            string date = DateTime.Now.ToString();
            if (writeDate == true)
            {
                message = date + " " + message;
            }
            Console.WriteLine(message);
            FileUtil.AppendText(log.FullName, message);
        }
    }
}
