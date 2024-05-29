using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ASTProject;

namespace ASTProject.Pages
{
    public class IssuesRequest: SeleniumSetup
    {
        private JToken? issues;
        public IssuesRequest() { issues = json; }

        public void ClickIssue(int book)
        {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(Issue_Locators.issueBook.Replace("{book}",book.ToString()))).Click();
        }
        public void EnterDate()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.Id(Issue_Locators.duedate)).SendKeys(issues["IncorrectDueDate"].ToString());
        }
        public void EnterDate(string date)
        {
            Thread.Sleep(1000);
            driver.FindElement(By.Id(Issue_Locators.duedate)).SendKeys(date);
        }
        public void ClickRequestIssue()
        {
            driver.FindElement(By.Id(Issue_Locators.issueButton)).Click();
        }
        public bool VerifyError()
        {
            Thread.Sleep(1000);
            return string.Compare("Due Date should be greater than current date", driver.FindElement(By.Id(Issue_Locators.error)).Text.ToString(), StringComparison.OrdinalIgnoreCase) == 0 ? true : false;
        }
        public bool VerifyGreaterThanMonthError()
        {
            Thread.Sleep(1000);
            return string.Compare("Due Date should be lesser than a month", driver.FindElement(By.Id(Issue_Locators.error)).Text.ToString(), StringComparison.OrdinalIgnoreCase) == 0 ? true : false;
        }
        public bool VerifyEntryInTable()
        {
            int total = ReadIntegerFromFile();
            string xpath = "//tbody/tr[{row}]/td[3]";
            int row = 1; int found = 0;
            try
            {
                while (true)
                {
                    Thread.Sleep(500);
                    string newxpath = xpath.Replace("{row}", row.ToString());
                    string value = driver.FindElement(By.XPath(newxpath)).Text.ToString();
                    if (value == "English")
                        found += 1;
                    row += 1;
                }                
            }
            catch(Exception ex)
            {
                WriteIntegerToFile(found);
                return found > total;
            }
        }
        public string MarkAsReturnedOrCancelled(bool forVerification)
        {
            string xpath = "//tbody/tr[{row}]/td[5]";
            int row = 1; 
            try
            {
                while (true)
                {
                    string newxpath = xpath.Replace("{row}", row.ToString());
                    string value = driver.FindElement(By.XPath(newxpath)).Text.ToString();
                    if (string.Compare(value, "Returned", StringComparison.OrdinalIgnoreCase) != 0 &&
                        string.Compare(value, "Cancelled", StringComparison.OrdinalIgnoreCase) != 0 && !forVerification)
                    {
                        Thread.Sleep(1000);
                        newxpath = newxpath.Replace("td[5]", "td[6]");
                        driver.FindElement(By.XPath(newxpath)).Click();
                        return driver.FindElement(By.XPath(newxpath.Replace("td[6]", "td[5]"))).Text.ToString();
                    }
                    else if (string.Compare(value, "Returned", StringComparison.OrdinalIgnoreCase) != 0 &&
                        string.Compare(value, "Cancelled", StringComparison.OrdinalIgnoreCase) != 0 && forVerification)
                    {
                        Thread.Sleep(1000);
                        return true.ToString();
                    }
                    row += 1;
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(1000);
                return string.Empty;
            }
        }
        
        public static int ReadIntegerFromFile()
        {
            try
            {
                string text = File.ReadAllText("count.txt");
                int value = Convert.ToInt32(text);
                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading integer from file: {ex.Message}");
                return -1;
            }
        }
        public static void WriteIntegerToFile(int value)
        {
            try
            {
                string text = value.ToString();
                Thread.Sleep(1000);
                File.WriteAllText("count.txt", text);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing integer to file: {ex.Message}");
            }
        }


    }
}
