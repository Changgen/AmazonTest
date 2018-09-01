using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutomationTest.Generic.Utils
{
    public sealed class LogUtil
    {
        private readonly string logDir;
        private readonly string logFileName;

        private static LogUtil log;

        private LogUtil(string logDir, string fileName)
        {
            this.logDir = logDir;
            this.logFileName = fileName;
        }

        public string FullName
        {
            get { return Path.Combine(logDir, logFileName); }
        }

        public LogUtil GetInstance(string logDir, string fileName)
        {
            return new LogUtil(logDir, fileName);
        }


        public static void WriteInformation(string message)
        {
            Console.WriteLine(message);
            //FileUtil.AppendText(log.FullName, message);
        }

        public static void Trace(string message)
        {
            Console.WriteLine(message);
        }

    }
}
