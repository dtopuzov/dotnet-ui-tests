using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BlazorApp.Tests.Selenium
{
    public class Browser
    {
        public IWebDriver Driver;
        public WebDriverWait Wait;

        public Browser()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1280,720");

            Driver = new ChromeDriver(options);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
        }

        public void Visit(string url)
        {
            Driver.Url = url;

            // Hack to wait for Blazor to load (page be in interactive state).
            // Please delete it for non Blazor projects!
            var loaded = Wait.Until((Driver) =>
            {
                var source = Driver.PageSource;
                return source.Contains("<body>") && !source.Contains("<!--bl-root-->");
            });

            if (!loaded)
            {
                var d = Driver.PageSource;
                throw new Exception($"Failed to load {url}");
            }
        }

        public IWebElement Find(By locator)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void Click(By locator)
        {
            Find(locator).Click();
        }

        public void Stop()
        {
            Driver.Quit();
        }
    }
}
