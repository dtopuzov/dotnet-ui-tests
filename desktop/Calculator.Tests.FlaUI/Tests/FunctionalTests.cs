using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System.Diagnostics;

namespace Calculator.Tests.FlaUI.Tests
{
    [TestFixture]
    public class FunctionalTests
    {
        private Window calc;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var app = Application.LaunchStoreApp("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            app.WaitWhileBusy();

            var automation = new UIA3Automation();
            calc = app.GetMainWindow(automation);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // There is an issue with calculator starting separate process, so standard Dispose() does not work.
            // This hack should not be required for most of WinForms/WPF apps.
            KillAllInstances("CalculatorApp");
        }

        [Test]
        public void SumTwoNumbers()
        {
            calc.FindFirstDescendant(c => c.ByName("One")).Click();
            calc.FindFirstDescendant(c => c.ByName("Plus")).Click();
            calc.FindFirstDescendant(c => c.ByName("One")).Click();
            calc.FindFirstDescendant(c => c.ByName("Equals")).Click();
            var result = calc.FindFirstDescendant(c => c.ByAutomationId("CalculatorResults"));
            Assert.That(result.Name, Is.EqualTo("Display is 2"));
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
