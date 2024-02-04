using Deque.AxeCore.Commons;
using Deque.AxeCore.Playwright;
using Microsoft.Playwright;

namespace BlazorApp.Tests.Playwright.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class AccessibilityTests : PageTest
    {

        [Test]
        public async Task HomePageShouldBeAccessible()
        {
            await Page.GotoAsync("http://localhost:5135/");
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            AxeResult axeResults = await Page.RunAxe();
            Assert.Multiple(() =>
            {
                Assert.That(axeResults.Violations, Has.Length.EqualTo(1));
                Assert.That(axeResults.Violations.First().Id, Is.EqualTo("region"));
            });
        }

        [Test]
        public async Task WeatherPageShouldBeAccesibe()
        {
            await Page.GotoAsync("http://localhost:5135/weather");
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            AxeResult axeResults = await Page.RunAxe();
            Assert.Multiple(() =>
            {
                Assert.That(axeResults.Violations, Has.Length.EqualTo(1));
                Assert.That(axeResults.Violations.First().Id, Is.EqualTo("region"));
            });
        }
    }
}
