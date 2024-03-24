using FlaUI.Core;
using System.Diagnostics;

namespace Calculator.Tests.FlaUI.Tests
{
    [TestFixture]
    public class FunctionalTests
    {
        private Application calc;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            calc = Application.LaunchStoreApp("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            calc.WaitWhileBusy();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            calc.Dispose();

            // There is an issue with calculator starting separate process, so standard Dispose() does not work.
            // This hack should not be required for most of WinForms/WPF apps.
            KillAllInstances("CalculatorApp");
        }

        [Test]
        public void SumTwoNumbers()
        {
            Thread.Sleep(1000);
        }

        private static void KillAllInstances(string appName)
        {
            foreach (var process in Process.GetProcessesByName(appName))
            {
                process.Kill();
            }
        }
    }
}
