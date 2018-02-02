using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitTaskSample
{
    public static class DtUtils
    {
        private static Dictionary<string, DateTime> _stopWatchDic = new Dictionary<string, DateTime>();

        public static void ConsoleWriteLine(string log, string stopWatchKey = null)
        {
            TimeSpan? ts = null;

            if (!string.IsNullOrEmpty(stopWatchKey))
            {
                if (_stopWatchDic.ContainsKey(stopWatchKey))
                {
                    ts = DateTime.Now - _stopWatchDic[stopWatchKey];
                    _stopWatchDic.Remove(stopWatchKey);
                }
                else
                {
                    _stopWatchDic[stopWatchKey] = DateTime.Now;
                }
            }

            if (ts == null)
            {
                Console.WriteLine($"TID[{Thread.CurrentThread.ManagedThreadId}] {log}");
            }
            else
            {
                Console.WriteLine($"TID[{Thread.CurrentThread.ManagedThreadId}] {stopWatchKey}[{ts?.TotalMilliseconds.ToString("F0")}ms] {log}");
            }
        }
    }
}
