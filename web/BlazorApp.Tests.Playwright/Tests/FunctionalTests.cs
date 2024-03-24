using Microsoft.Playwright;

namespace BlazorApp.Tests.Playwright.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class FunctionalTests : ContextTest
    {
        private IPage Page { get; set; }

        [SetUp]
        public async Task PageSetup()
        {
            Page = await Context.NewPageAsync().ConfigureAwait(false);
            Task task = Task.Run(async () => await Page.GotoAsync("http://localhost:5135/counter"));
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        [Test]
        public async Task ClickButtonShouldIncreaseCounter()
        {
            await Expect(Page.Locator("role=status")).ToHaveTextAsync("Current count: 0");

            await Page.Locator("css=.btn-primary").ClickAsync();
            await Expect(Page.Locator("role=status")).ToHaveTextAsync("Current count: 1");
        }
    }
}
