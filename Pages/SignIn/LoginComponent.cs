using AdvancedTaskPart2.Model;
using AdvancedTaskPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.Pages.SignIn
{
    public class LoginComponent:CommonDriver
    {
        private IWebElement UsernameTextbox;
        private IWebElement PasswordTextbox;
        private IWebElement LoginButton;

        public void renderLogin()
        {
            try
            {
                UsernameTextbox = dr.FindElement(By.XPath("//input[@name='email']"));
                PasswordTextbox = dr.FindElement(By.XPath("//input[@name='password']"));
                LoginButton = dr.FindElement(By.XPath("//button[text()='Login']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        public void LoginActions(UserInformation userInformation)
        {
            renderLogin();
            UsernameTextbox.SendKeys(userInformation.Email);
            PasswordTextbox.SendKeys(userInformation.Password);
            LoginButton.Click();
        }
        public void LoginActions(string username, string password)
        {
            renderLogin();
            UsernameTextbox.SendKeys(username);
            PasswordTextbox.SendKeys(password);
            LoginButton.Click();
        }
    }
}
