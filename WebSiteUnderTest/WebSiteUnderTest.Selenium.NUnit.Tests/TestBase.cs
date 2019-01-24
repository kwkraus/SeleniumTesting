using NUnit.Framework;
using System.Configuration;
using WebSiteUnderTest.Selenium.Framework;

namespace WebSiteUnderTest.Selenium.NUnit.Tests
{
    public abstract class TestBase
    {
        [SetUp]
        public void SetUp()
        {
            Driver.Initialize(
                ConfigurationSettings.AppSettings["TargetBrowser"].ToString(),
                bool.Parse(ConfigurationSettings.AppSettings["isPrivateMode"].ToString()),
                bool.Parse(ConfigurationSettings.AppSettings["isHeadless"].ToString()));
            Driver.BaseUrl = ConfigurationSettings.AppSettings["BaseUrl"].ToString();
        }


        [TearDown]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}
