using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ASTProject.Pages
{
    public class Login: SeleniumSetup
    {
        private JToken? credentials;
        public Login() { credentials = json["Credentials"]; }

        public Login(JToken signupObject) { credentials = signupObject; }

        public void EnterEmail()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.Id(Login_Locators.email)).SendKeys(credentials["email"]?.ToString());
        }
        public void EnterEmail(string email)
        {
            Thread.Sleep(1000);
            driver.FindElement(By.Id(Login_Locators.email)).SendKeys(email);
        }
        public void EnterPassword()
        {
            driver.FindElement(By.Id(Login_Locators.password)).SendKeys(credentials["password"]?.ToString());
        }
        public void ClickLogin()
        {
            driver.FindElement(By.Id(Login_Locators.loginButton)).Click();
        }
        public void ClickSignup()
        {
            driver.FindElement(By.Id(Login_Locators.signupButton)).Click();
        }
        public void CleanLogin()
        {
            driver.FindElement(By.Id(Login_Locators.email)).Clear();
            driver.FindElement(By.Id(Login_Locators.password)).Clear();
        }
        public bool VerifyLogin()
        {
            Thread.Sleep(2000);
            return string.Compare(Login_Locators.verificationText, driver.FindElement(By.Id(Login_Locators.verificationTag)).Text.ToString()) == 0? true: false;
        }
        public void Logout()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(Login_Locators.logoutButton)).Click();
        }
        public void LogoutDropdown()
        {
            driver.FindElement(By.Id(Login_Locators.logoutHelper)).Click();
            Thread.Sleep(1000);
        }
        public bool LogoutVerification()
        {
            return string.Compare(Login_Locators.logoutVerificationText, driver.FindElement(By.XPath(Login_Locators.logoutVerificationTag)).Text.ToString(), StringComparison.OrdinalIgnoreCase) == 0 ? true : false;
        }
        public bool InvalidEmail()
        {
            driver.FindElement(By.Id(Login_Locators.email)).Clear();
            return string.Compare(Login_Locators.invalidEmailText, driver.FindElement(By.Id(Login_Locators.invalidEmail)).Text.ToString(), StringComparison.OrdinalIgnoreCase) == 0 ? true : false;
        }
    }
}
