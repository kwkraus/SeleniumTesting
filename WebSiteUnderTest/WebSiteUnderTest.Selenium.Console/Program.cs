using WebSiteUnderTest.Selenium.Framework;
using WebSiteUnderTest.Selenium.Framework.Pages;

namespace WebSiteUnderTest.Selenium.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver.BaseUrl = "http://localhost:2889";
            Driver.Initialize("Firefox");
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
