using Calculator.Tests.WinAppDriver.Framework;

namespace Calculator.Tests.WinAppDriver
{
    public class BaseTest
    {
        [OneTimeSetUp]
        public void BrowserSetup()
        {
            WinAppDriverServer.Start();
        }

        [OneTimeTearDown]
        public void BrowserTearDown()
        {
            WinAppDriverServer.Stop();
        }

    }
}
