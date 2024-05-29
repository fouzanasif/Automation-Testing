using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ASTProject.Pages
{
    public class Signup : SeleniumSetup
    {
        private JToken? signup;
        public Signup() { signup = json["Signup"]; }
        public void AddName()
        {
            driver.FindElement(By.Id(Signup_Locators.name)).SendKeys(signup["name"]?.ToString());
        }
        public void AddEmail()
        {
            driver.FindElement(By.Id(Signup_Locators.email)).SendKeys(signup["email"]?.ToString());
        }
        public void AddPassword()
        {
            driver.FindElement(By.Id(Signup_Locators.password)).SendKeys(signup["password"]?.ToString());
            Thread.Sleep(1000);
        }
        public void AddMembership()
        {
            driver.FindElement(By.Id(Signup_Locators.membership)).SendKeys(signup[nameof(Signup_Locators.membership)]?.ToString());
        }
        public void AddSubPeriod()
        {
            driver.FindElement(By.Id(Signup_Locators.subperiod)).SendKeys(signup[nameof(Signup_Locators.subperiod)]?.ToString());
        }
        public void ClickSignup()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.Id(Signup_Locators.signupButton)).Click();
        }
        public bool VerifySignup()
        {
            Thread.Sleep(1000);
            return driver.FindElement(By.Id(Signup_Locators.verificationTag)).Text.ToString().Contains(signup[nameof(Signup_Locators.name)].ToString(),StringComparison.OrdinalIgnoreCase);
        }
    }
}
