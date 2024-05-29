using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ASTProject.Pages
{
    public class FineManagement : SeleniumSetup
    {
        public JToken? values;
        public FineManagement() { values = json; }
        public void VisitFineManagement()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.Id(FineManagement_Locators.finemanagement_link)).Click();
        }
        public bool CheckFine()
        {
            Thread.Sleep(1000);
            string fine = driver.FindElement(By.Id(FineManagement_Locators.remainingDues)).Text.ToString();
            return Int32.Parse(fine) <= 0;
        }
        public void PayFineButtonClick()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(FineManagement_Locators.finepay_button)).Click();
        }
        public int AddDues()
        {
            driver.FindElement(By.XPath(FineManagement_Locators.enterDues)).SendKeys(values["fine"].ToString());
            return Int32.Parse(values["fine"].ToString());
        }
        public void AddDues(int dues)
        {
            driver.FindElement(By.XPath(FineManagement_Locators.enterDues)).SendKeys(dues.ToString());
        }
        public bool VerifyError()
        {
            return string.Compare("Please enter amount > 0", driver.FindElement(By.XPath(FineManagement_Locators.paymentError)).Text.ToString()) == 0 ? true: false;
        }
        public int TotalDues()
        {
            var a = driver.FindElement(By.XPath(FineManagement_Locators.totalDues)).Text.ToString();
            return Int32.Parse(a);
        }
        public void SubmitDues()
        {
            driver.FindElement(By.XPath(FineManagement_Locators.submitDues)).Click();
        }
        public bool VerifyPenalty(int previous, int submitted)
        {
            Thread.Sleep(1000);
            int fine = Int32.Parse(driver.FindElement(By.XPath(FineManagement_Locators.remainingDues)).Text.ToString());
            return fine == previous - submitted;
        }
    }
}
