namespace Calculator.Tests.FlaUI.WinAppDriver
{
    [TestFixture]
    public class FunctionalTests
    {
        private Application calc;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            calc = Application.(@"C:Program FilesMicrosoft OfficeOffice16WINWORD.EXE");
            var automation = new UIA3Automation();
            var mainWindow = msApplication.GetMainWindow(automation);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }

        [Test]
        public void SumTwoNumbers()
        {
        }
    }
}
