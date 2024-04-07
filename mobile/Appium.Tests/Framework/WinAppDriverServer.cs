namespace Calculator.Tests.WinAppDriver.Framework
{
    public static class WinAppDriverServer
    {
        private static readonly string DriverExecutable = "WinAppDriver";

        public static Uri ServiceUri => new Uri("http://127.0.0.1:4723");

        public static void Start()
        {
            Process.KillProcessByName(DriverExecutable);

            var driverHomePath = Environment.GetEnvironmentVariable("DRIVER_HOME");
            if (driverHomePath == null)
            {
                driverHomePath = @"c:\Program Files (x86)\Windows Application Driver\";
            }

            Process.ExecuteCmd($"{DriverExecutable}.exe", driverHomePath, waitToFinish: false);
            Console.WriteLine("Start WinAppDriver server.");
        }

        public static void Stop()
        {
            Process.KillProcessByName(DriverExecutable);
            Console.WriteLine("Stop WinAppDriver server.");
        }
    }
}
