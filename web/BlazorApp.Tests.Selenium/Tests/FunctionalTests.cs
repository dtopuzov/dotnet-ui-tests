using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace BlazorApp.Tests.Selenium.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class FunctionalTests : WebTest
    {
        [SetUp]
        public void PageSetup()
        {
            Browser.Visit("http://localhost:5135/counter");
        }

        [Test]
        public void ClickButtonShouldIncreaseCounter()
        {
            var status = Browser.Find(By.CssSelector("[role='status']"));
            Assert.That(status.Text, Is.EqualTo("Current count: 0"));

            Browser.Click(By.CssSelector(".btn-primary"));
            var textChanged = ExpectedConditions.TextToBePresentInElement(status, "Current count: 1");
            Assert.That(Browser.Wait.Until(textChanged), Is.True);
        }
    }
}
