using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTProject
{
    public class Login_Locators
    {
        public const string email = "email";
        public const string password = "password";
        public const string loginButton = "loginButton";
        public const string signupButton = "signupButton";

        public const string verificationTag = "catalog";
        public const string verificationText = "Catalog";

        public const string logoutHelper = "dropdownBasic1";
        public const string logoutButton = "//button[contains(text(),'Logout')]";

        public const string logoutVerificationTag = "//h1[contains(text(),'Login')]";
        public const string logoutVerificationText = "Login";

        public const string invalidEmail = "invalidemail";
        public const string invalidPassword = "invalidpassword";
        public const string invalidEmailText = "Email is Invalid";
        public const string invalidPasswordText = "Password is Invalid";
    }

    public class Signup_Locators
    {
        public const string name = "username";
        public const string email = "useremail";
        public const string password = "userpassword";
        public const string membership = "membership";
        public const string subperiod = "subperiod";
        public const string signupButton = "signupbutton";

        public const string verificationTag = "dropdownBasic1";
    }
    public class Issue_Locators
    {
        public const string issueBook = "//tbody/tr[{book}]/td[4]/button[1]";
        public const string duedate = "duedate";
        public const string error = "error";
        public const string issueButton = "issuerequest";
        public const string issuesTable = "issuestable";
    }
    
    public class FineManagement_Locators
    {
        public const string finemanagement_link = "finemanagement";
        public const string finepay_button = "//button[contains(text(),'Pay')]";
        public const string enterDues = "//body/app-root[1]/app-dashboard[1]/div[1]/div[1]/app-pay-form[1]/div[1]/div[1]/div[1]/form[1]/div[2]/input[1]";
        public const string totalDues = "//body/app-root[1]/app-dashboard[1]/div[1]/div[1]/app-pay-form[1]/div[1]/div[1]/div[1]/form[1]/div[1]/input[1]";
        public const string submitDues = "//button[contains(text(),'Submit Dues')]";
        public const string remainingDues = "penalty";
        public const string paymentError = "paymenterror";
    }

    public class Reporting_Locators
    {
        public const string reporting_link = "";

    }
}

