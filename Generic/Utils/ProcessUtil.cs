using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AutomationTest.Generic.Utils
{
    public static class ProcessUtil
    {
        /// <summary>
        /// Kill specified process.
        /// </summary>
        /// <param name="processName"></param>
        public static void KillProcess(string processName)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.ProcessName == processName && !process.HasExited)
                {
                    process.Kill();
                }
            }    
        }

        /// <summary>
        /// Kill specified process by name.
        /// </summary>
        /// <param name="processName"></param>
        public static void KillProcessByName(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Any())
            {
                foreach (Process process in processes)
                {
                    if (!process.HasExited)
                    {
                        process.Kill();
                    }
                }
            }
        }

        /// <summary>
        /// Kill all releated processes.
        /// </summary>
        /// <param name="processes"></param>
        public static void KillProcesses(IList<string> processes)
        {
            foreach (string process in processes)
            {
                KillProcessByName(process);
            }
        }

        /// <summary>
        /// Start exe application.
        /// </summary>
        /// <param name="applicationPath"></param>
        public static void Start(string applicationPath)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(applicationPath);
            try
            {
                Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to start exe >>" + applicationPath, ex);
            }
        }

    }
}
