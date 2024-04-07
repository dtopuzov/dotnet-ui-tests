using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using Calculator.Tests.WinAppDriver.Framework;

namespace Calculator.Tests.WinAppDriver
{
    public class Calculator
    {
        public Calculator(Uri serviceUrl)
        {
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            var timeout = System.Diagnostics.Debugger.IsAttached ? 999999 : 30;
            options.AddAdditionalCapability("newCommandTimeout", timeout);

            Driver = new WindowsDriver<WindowsElement>(serviceUrl, options);
        }

        public WindowsDriver<WindowsElement> Driver { get; protected set; }

        public void Stop()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }
        public WindowsElement Find(By locator, int timeout = 10)
        {
            var found = Wait.Until(() => Driver.FindElements(locator).Count > 0, timeout);
            if (found)
            {
                return Driver.FindElement(locator);
            }
            else
            {
                throw new Exception($"Failed to find element located by {locator}");
            }
        }
    }
}
