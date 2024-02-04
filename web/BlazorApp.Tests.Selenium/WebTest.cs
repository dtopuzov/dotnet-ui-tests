namespace BlazorApp.Tests.Selenium
{
    public class WebTest
    {
        public Browser Browser { get; internal set; } = null!;

        [OneTimeSetUp]
        public void BrowserSetup()
        {
            Browser = new Browser();
        }

        [OneTimeTearDown]
        public void BrowserTearDown()
        {
            Browser.Stop();
        }
    }

}
