using Calculator.Tests.WinAppDriver.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Calculator.Tests.WinAppDriver.Tests
{
    [TestFixture]
    public class FunctionalTests : BaseTest
    {
        private Calculator calc;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            calc = new Calculator(WinAppDriverServer.ServiceUri);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            calc.Stop();
        }

        [Test]
        public void SumTwoNumbers()
        {
            calc.Find(By.Name("One")).Click();
            calc.Find(By.Name("Plus")).Click();
            calc.Find(By.Name("One")).Click();
            calc.Find(By.Name("Equals")).Click();

            var result = calc.Find(MobileBy.AccessibilityId("CalculatorResults"));
            Assert.That(result.Text, Is.EqualTo("Display is 2"));
        }
    }
}
