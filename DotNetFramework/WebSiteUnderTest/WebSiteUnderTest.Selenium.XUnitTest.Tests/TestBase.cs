using System;
using System.Configuration;
using WebSiteUnderTest.Selenium.Framework;

namespace WebSiteUnderTest.Selenium.XUnit.Tests
{
    public abstract class TestBase : IDisposable
    {
        protected TestBase()
        {
            Driver.Initialize(
                ConfigurationSettings.AppSettings["TargetBrowser"].ToString(),
                bool.Parse(ConfigurationSettings.AppSettings["isPrivateMode"].ToString()),
                bool.Parse(ConfigurationSettings.AppSettings["isHeadless"].ToString()));
            Driver.BaseUrl = ConfigurationSettings.AppSettings["BaseUrl"].ToString();
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
