using System.Diagnostics;

namespace Calculator.Tests.WinAppDriver.Framework
{
    public static class Wait
    {
        public static bool Until(Func<bool> task, double timeout = 10, int retryInterval = 100)
        {
            bool success = false;
            TimeSpan maxDuration = TimeSpan.FromSeconds(timeout);
            Stopwatch sw = Stopwatch.StartNew();
            while (success != true && (sw.Elapsed < maxDuration))
            {
                Thread.Sleep(retryInterval);
                success = task();
            }

            return success;
        }
    }
}
