using Calculator.Tests.WinAppDriver.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

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
        public void SumTwoNumbers1()
        {
            calc.Find(By.Name("One")).Click();
            calc.Find(By.Name("Plus")).Click();
            calc.Find(By.Name("One")).Click();
            calc.Find(By.Name("Equals")).Click();

            var result = calc.Find(MobileBy.AccessibilityId("CalculatorResults"));
            Assert.That(result.Text, Is.EqualTo("Display is 2"));
        }

        [Test]
        public void SumTwoNumbers()
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            var serverUri = new Uri("http://127.0.0.1:4723");
            var driver = new WindowsDriver<WindowsElement>(serverUri, options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.Name("One")).Click();
            driver.FindElement(By.Name("Plus")).Click();
            driver.FindElement(By.Name("One")).Click();
            driver.FindElement(By.Name("Equals")).Click();

            var result = driver.FindElement(MobileBy.AccessibilityId("CalculatorResults"));
            Assert.That(result.Text, Is.EqualTo("Display is 2"));
        }
    }
}
