using NUnit.Framework;
using WebSiteUnderTest.Selenium.Framework.Pages;

namespace WebSiteUnderTest.Selenium.NUnit.Tests.Tests.Home
{
    [TestFixture]
    class HomePageTests : TestBase
    {
        [Test]
        public void Home_Validate_Page_NUnit()
        {
            HomePage.GoTo();
            Assert.True(HomePage.IsAt, "Failed to navigate to HomePage");
        }

        [Test]
        public void Home_Test_Carousel_Click_NUnit()
        {
            HomePage.GoTo();
            HomePage.ClickCarousel(3);
            //Thread.Sleep(1500);  //just for demo purposes
            Assert.True(HomePage.IsAt, "Could not access homepage after click of carousel");
        }

        [Test]
        public void Home_Click_Alert_From_ExecuteScript_NUnit()
        {
            HomePage.GoTo();
            HomePage.ClickAlertFromExecuteJS();
            Assert.True(HomePage.IsAt, "Could not access homepage after alert click");
        }
    }
}
