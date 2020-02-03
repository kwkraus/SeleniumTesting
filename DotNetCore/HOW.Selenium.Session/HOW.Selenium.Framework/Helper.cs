using OpenQA.Selenium;
using System;

namespace HOW.Selenium.Framework
{
    internal static class Helper
    {
        internal static void TakeScreenShot(IWebDriver driver, string fileName)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            //Use it as you want now
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile($"{fileName}-{DateTime.Now.ToString("yyyyMMddss")}.png", ScreenshotImageFormat.Png); //use any of the built in image formating

        }
    }
}
