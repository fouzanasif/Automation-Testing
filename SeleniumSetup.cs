using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Edge;

namespace ASTProject
{
    public class SeleniumSetup
    {
        public static JObject json = JObject.Parse(File.ReadAllText(@"..\..\..\information.json"));
        public static EdgeDriver driver;
        public string URL = string.Empty;

        private void DriverInitialize()
        {
            if (driver == null)
            {
                driver = new EdgeDriver();
            }
        }
        public EdgeDriver GetDriverInstance()
        {
            URL = json["URL"]?.ToString();
            DriverInitialize();
            return driver;
        }
        public void OpenBrowser()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);
        }
        public void CloseBrowserInstance()
        {
            driver.Close();
            driver.Dispose();
            driver = null;
        }
    }
}
