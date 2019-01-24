using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace WebSiteUnderTest.Selenium.Framework
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string BaseUrl { get; set; }

        public static void Initialize(string driverType)
        {
            switch (driverType)
            {
                case "IE":
                    InternetExplorerDriverService service = InternetExplorerDriverService.CreateDefaultService();
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.IgnoreZoomLevel = true;
                    Instance = new InternetExplorerDriver(service, options);
                    break;

                case "Chrome":
                    //chrome
                    ChromeDriverService svc = ChromeDriverService.CreateDefaultService();
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("incognito");
                    //chromeOptions.AddArgument("headless");
                    Instance = new ChromeDriver(svc, chromeOptions);
                    break;

                case "Firefox":
                    //firefox
                    Instance = new FirefoxDriver();
                    break;

                //case "Phantom":
                //    //Phantom Webdriver
                //    Instance = new PhantomJSDriver();
                //    break;

                default:
                    Instance = new ChromeDriver();
                    break;
            }

            Instance.Manage().Window.Maximize();
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static void Quit()
        {
            Instance.Quit();
        }
    }
}
