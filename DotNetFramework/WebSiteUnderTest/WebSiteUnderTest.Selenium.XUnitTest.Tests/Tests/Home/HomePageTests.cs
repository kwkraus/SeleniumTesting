using System.Threading;
using WebSiteUnderTest.Selenium.Framework.Pages;
using Xunit;

namespace WebSiteUnderTest.Selenium.XUnit.Tests.Home
{
    public class HomePageTests : TestBase
    {
        [Fact]
        public void Home_Validate_Page_xUnit()
        {
            HomePage.GoTo();
            Assert.True(HomePage.IsAt, "Failed to navigate to HomePage");
        }

        [Fact]
        public void Home_Test_Carousel_Click_xUnit()
        {
            HomePage.GoTo();
            HomePage.ClickCarousel(3);
            //Thread.Sleep(1500);  //just for demo purposes
            Assert.True(HomePage.IsAt, "Could not access homepage after click of carousel");
        }

        [Fact]
        public void Home_Click_Alert_From_ExecuteScript_xUnit()
        {
            HomePage.GoTo();
            HomePage.ClickAlertFromExecuteJS();
            Assert.True(HomePage.IsAt, "Could not access homepage after alert click");
        }
    }
}
