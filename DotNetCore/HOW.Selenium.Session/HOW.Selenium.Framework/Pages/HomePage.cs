using OpenQA.Selenium;
using System.Threading;

namespace HOW.Selenium.Framework.Pages
{
    public class HomePage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl($"{Driver.BaseUrl}/");
        }

        public static bool IsAt
        {
            get
            {
                var requestBtns = Driver.Instance.FindElements(By.Id("myCarousel"));

                if(requestBtns.Count > 0)
                {
                    return true;
                }
                else
                {
                    Helper.TakeScreenShot(Driver.Instance, $"{nameof(HomePage)}-{nameof(IsAt)}");
                    return false;
                }
            }
        }

        public static void ClickAlertFromExecuteJS()
        {
            ((IJavaScriptExecutor)Driver.Instance).ExecuteScript(
                "alert('executed from selenium ExecuteScript');");

            IAlert alert = Driver.Instance.SwitchTo().Alert();
            Thread.Sleep(1500);
            alert.Accept();
        }
    }
}
