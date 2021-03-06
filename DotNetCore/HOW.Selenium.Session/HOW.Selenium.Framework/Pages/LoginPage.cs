﻿using HOW.Selenium.Framework.Pages.Classes;
using OpenQA.Selenium;

namespace HOW.Selenium.Framework.Pages
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl($"{Driver.BaseUrl}/Identity/Account/Login");

        }

        public static bool IsAt
        {
            get
            {
                var headers = Driver.Instance.FindElements(By.XPath("/html/body/div/h2"));

                if (headers.Count > 0)
                    return headers[0].Text.Trim() == "Log in";

                return false;
            }
        }

        public static bool IsTextPresent(string textToLocate)
        {
            return Driver.Instance.PageSource.Contains(textToLocate);
        }

        public static LoginCommand AddUser(UserData userdata)
        {
            return new LoginCommand(userdata);
        }

        public class LoginCommand
        {
            private readonly UserData userdata;

            public LoginCommand(UserData userdata)
            {
                this.userdata = userdata;
            }

            public void Login()
            {
                var loginElement = Driver.Instance.FindElement(By.Id("Input_Email"));

                loginElement.Clear();
                loginElement.SendKeys(userdata.userid);

                Driver.Instance.FindElement(By.Id("Input_Password")).SendKeys(userdata.password);
                if (userdata.rememberMe)
                    Driver.Instance.FindElement(By.Id("Input_RememberMe")).Click();

                loginElement.Submit();
            }
        }
    }
}
