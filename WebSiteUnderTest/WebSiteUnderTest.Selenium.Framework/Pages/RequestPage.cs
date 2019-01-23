using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using WebSiteUnderTest.Selenium.Framework.Classes;

namespace WebSiteUnderTest.Selenium.Framework.Pages
{
    public class RequestPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl($"{Driver.BaseUrl}/Requests");

        }

        public static bool IsAt
        {
            get
            {
                var titles = Driver.Instance.FindElements(By.CssSelector("body div h2"));

                if (titles.Count > 0)
                    return titles[0].Text.Trim() == "Index";

                return false;
            }
        }

        public static RequestCommand AddRequestData(RequestData request = null)
        {
            return new RequestCommand(request);
        }

        public static void ClickCreateRequestButton()
        {
            Driver.Instance.FindElement(By.XPath("/html/body/div/p/a")).Click();
        }

        public static bool IsTextPresent(string textToLocate)
        {
            return Driver.Instance.PageSource.Contains(textToLocate);
        }

        public class RequestCommand
        {
            private RequestData _request;
            private readonly int _retryCount = 3;

            public RequestCommand(RequestData request)
            {
                this._request = request;
            }

            public RequestData Submit()
            {
                int currentRetry = 0;

                if (_request == null)
                    _request = RequestData.GenerateRandomRequestData();

                for (; ; )
                {
                    try
                    {
                        Driver.Instance.FindElement(By.Id("Title")).SendKeys(_request.Title);
                        Driver.Instance.FindElement(By.Id("Body")).SendKeys(_request.Body);
                        SelectElement select = new SelectElement(Driver.Instance.FindElement(By.Id("Level")));

                        select.SelectByText(_request.Level);

                        new WebDriverWait(Driver.Instance, new TimeSpan(0, 0, 5))
                            .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input.btn.btn-default"))).Click();

                        // Return or break.
                        break;
                    }
                    catch (WebDriverTimeoutException)
                    {
                        currentRetry++;

                        if (currentRetry > _retryCount)
                        {
                            throw;
                        }

                        //sometimes the modal looks like it's opening, but the page never renders
                        //if we are in this state, press escape to leave failed modal and try again
                        //Actions clickAnywhere = new Actions(Driver.Instance);
                        //clickAnywhere.SendKeys(Keys.Escape);
                    }
                }

                return _request;
            }
        }
    }
}
