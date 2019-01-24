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
            Driver.Initialize(
                TestContext.Properties["TargetBrowser"].ToString(),
                bool.Parse(TestContext.Properties["isPrivateMode"].ToString()),
                bool.Parse(TestContext.Properties["isHeadless"].ToString()));
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

