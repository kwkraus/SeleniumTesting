using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSiteUnderTest.Selenium.Framework;

namespace WebSiteUnderTest.Selenium.MSTest.Tests
{
    public class TestBase
    {
        //Snippet selbase
        [TestInitialize()]
        public void Initialize()
        {
            Driver.Initialize(TestContext.Properties["TargetBrowser"].ToString());
            Driver.BaseUrl = TestContext.Properties["BaseUrl"].ToString();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Driver.Quit();
        }

        public TestContext TestContext { get; set; }
    }
}

