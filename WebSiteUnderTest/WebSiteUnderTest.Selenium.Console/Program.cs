using System.Configuration;
using WebSiteUnderTest.Selenium.Framework;
using WebSiteUnderTest.Selenium.Framework.Pages;

namespace WebSiteUnderTest.Selenium.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver.BaseUrl = ConfigurationManager.AppSettings["BaseUrl"].ToString(); // "http://localhost:2889";
            Driver.Initialize(
                ConfigurationManager.AppSettings["TargetBrowser"].ToString(),
                bool.Parse(ConfigurationManager.AppSettings["isPrivateMode"].ToString()),
                bool.Parse(ConfigurationManager.AppSettings["isHeadless"].ToString()));
            HomePage.GoTo();
            if(HomePage.IsAt)
            {
                System.Console.Write("Test Succeeded");
            }
            else
            {
                System.Console.Write("Test Failed");
            }
            Driver.Quit();
            System.Console.Read();
        }
    }
}
