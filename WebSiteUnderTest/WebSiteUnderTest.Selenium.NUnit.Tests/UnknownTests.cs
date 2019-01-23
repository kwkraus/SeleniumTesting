using NUnit.Framework;

namespace WebSiteUnderTest.Selenium.NUnit.Tests
{
    [TestFixture]
    public class UnknownTests
    {
        [Test]
        public void NUnit_Test_Assert_True()
        {
            Assert.IsTrue(true, "");
        }
    }
}
