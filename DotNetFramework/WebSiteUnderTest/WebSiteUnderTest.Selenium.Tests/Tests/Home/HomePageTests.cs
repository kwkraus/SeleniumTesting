using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using WebSiteUnderTest.Selenium.Framework.Pages;

namespace WebSiteUnderTest.Selenium.MSTest.Tests.Home
{
    [TestClass]
    public class HomePageTests : TestBase
    {

        [TestMethod]
        [TestCategory("Smoke")]
        public void Home_Validate_Page()
        {
            HomePage.GoTo();
            Assert.IsTrue(HomePage.IsAt, "Failed to navigate to HomePage");
        }

        [TestMethod]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\data.csv", "data#csv", DataAccessMethod.Sequential)]
        public void Home_Test_Carousel_Click()
        {
            HomePage.GoTo();
            HomePage.ClickCarousel(3);
            //Thread.Sleep(1500);  //just for demo purposes
            Assert.IsTrue(HomePage.IsAt, "Could not access homepage after click of carousel");
        }

        [TestMethod]
        public void Home_Click_Alert_From_ExecuteScript()
        {
            HomePage.GoTo();
            HomePage.ClickAlertFromExecuteJS();
            Assert.IsTrue(HomePage.IsAt, "Could not access homepage after alert click");
        }
    }
}

