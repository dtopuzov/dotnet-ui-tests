using Deque.AxeCore.Commons;
using Deque.AxeCore.Selenium;

namespace BlazorApp.Tests.Selenium.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class AccessibilityTests : WebTest
    {

        [Test]
        public void HomePageShouldBeAccessible()
        {
            Browser.Visit("http://localhost:5135/");

            AxeResult axeResult = new AxeBuilder(Browser.Driver).Analyze();
            Assert.Multiple(() =>
            {
                Assert.That(axeResult.Violations, Has.Length.EqualTo(1));
                Assert.That(axeResult.Violations.First().Id, Is.EqualTo("region"));
            });
        }

        [Test]
        public void WeatherPageShouldBeAccesibe()
        {
            Browser.Visit("http://localhost:5135/weather");

            AxeResult axeResult = new AxeBuilder(Browser.Driver).Analyze();
            Assert.Multiple(() =>
            {
                Assert.That(axeResult.Violations, Has.Length.EqualTo(1));
                Assert.That(axeResult.Violations.First().Id, Is.EqualTo("region"));
            });
        }
    }
}
