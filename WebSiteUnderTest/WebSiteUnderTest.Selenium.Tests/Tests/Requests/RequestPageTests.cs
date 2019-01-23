using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using WebSiteUnderTest.Selenium.Framework.Classes;
using WebSiteUnderTest.Selenium.Framework.Pages;

namespace WebSiteUnderTest.Selenium.MSTest.Tests.Tests.Requests
{
    [TestClass]
    public class RequestPageTests : TestBase
    {
        [TestMethod]
        public void Requests_Verify_Page_Navigation()
        {
            LoginPage.GoTo();

            UserData userdata = new UserData
            {
                userid = "a@a.com",
                password = "Pass@word1",
                rememberMe = false
            };

            LoginPage.AddUser(userdata).Login();

            RequestPage.GoTo();
            Assert.IsTrue(RequestPage.IsAt, "failed to navigate to Requests page");
        }

        [TestMethod]
        public void Requests_Create_Request()
        {
            RequestPage.GoTo();

            UserData userdata = new UserData
            {
                userid = "a@a.com",
                password = "Pass@word1",
                rememberMe = false
            };

            System.Diagnostics.Debug.WriteLine("have a nice day");
            

            TestContext.WriteLine("this is extra info for my test");

            LoginPage.AddUser(userdata).Login();
            RequestPage.ClickCreateRequestButton();
            RequestData request = RequestPage.AddRequestData().Submit();
            //Thread.Sleep(1000);
            RequestPage.GoTo();

            Assert.IsTrue(RequestPage.IsAt, "Failed to create new request");

        }
    }
}
