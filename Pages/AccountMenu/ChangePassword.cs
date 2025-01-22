using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTaskPart2.Utilities;
using AdvancedTaskPart2.Model;
using Pj.Library;
using AdvancedTaskPart2.Utilities;

namespace AdvancedTaskPart2.Pages.AccountMenu
{
    public class ChangePassword : CommonDriver
    {


        private IWebElement ChangePasswordDropdown;
        private IWebElement AlertMessage;
        private IWebElement AlertMessage1;
        private IWebElement AlertMessage2;
        private IWebElement CurrentPassword;
        private IWebElement NewPassword;
        private IWebElement ConfirmPassword;
        private IWebElement SaveButton;
        private IWebElement successMessage;

        public void renderChangePasswordDropdown()
        {
            try
            {
                Wait.WaitToBeClickable(dr, "XPath", "//a[text()='Change Password']", 4);
                ChangePasswordDropdown = dr.FindElement(By.XPath("//a[text()='Change Password']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void renderDirectlyClickSaveButton()
        {
            Thread.Sleep(2000);
            SaveButton = dr.FindElement(By.XPath("//button[@class='ui button ui teal button']"));
        }
        public void renderEmptyScenarioMessage()
        {
            try
            {
                Wait.WaitToBeVisible(dr, "XPath", "//div[@class='ns-box-inner']", 4);
                AlertMessage = dr.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
            }
        }
        public void renderChangePasswordComponents()
        {
            try
            {
                Wait.WaitToExist(dr, "XPath", "//input[@placeholder='Current Password']", 4);
                CurrentPassword = dr.FindElement(By.XPath("//input[@placeholder='Current Password']"));
                NewPassword = dr.FindElement(By.XPath("//input[@placeholder='New Password']"));
                ConfirmPassword = dr.FindElement(By.XPath("//input[@placeholder='Confirm Password']"));
                SaveButton = dr.FindElement(By.XPath("//button[@type='button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void renderMessage()
        {
            try
            {
                Wait.WaitToBeVisible(dr, "XPath", "//div[@class='ns-box-inner']", 4);
                successMessage = dr.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderPasswordFailed()
        {
            try
            {
                Wait.WaitToBeVisible(dr, "XPath", "//div[@class='ns-box-inner']", 4);
                AlertMessage1 = dr.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderPasswordDoNotMatch()
        {
            try
            {
                Wait.WaitToBeVisible(dr, "XPath", "//div[@class='ns-box-inner']", 4);
                AlertMessage2 = dr.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void EmptyScenarioPassword()
        {
            renderChangePasswordDropdown();
            ChangePasswordDropdown.Click();
            renderDirectlyClickSaveButton();
            SaveButton.Click();

        }
        public string getEmptyMessageAlert()
        {
            renderEmptyScenarioMessage();
            return AlertMessage.Text;
        }
        public void WrongCurrentPassword(ChangePasswordData changePasswordData)
        {
            renderChangePasswordDropdown();
            ChangePasswordDropdown.Click();
            renderChangePasswordComponents();
            CurrentPassword.SendKeys(changePasswordData.CurrentPassword);
            NewPassword.SendKeys(changePasswordData.NewPassword);
            ConfirmPassword.SendKeys(changePasswordData.ConfirmPassword);
            SaveButton.Click();

            



        }
        public string getPasswordVerificationFailedMessage()
        {
            renderPasswordFailed();
            return AlertMessage1.Text;
        }
        public void DifferentPasswordScenario(ChangePasswordData changePasswordData)
        {
            renderChangePasswordDropdown();
            ChangePasswordDropdown.Click();
            renderChangePasswordComponents();
            CurrentPassword.SendKeys(changePasswordData.CurrentPassword);
            NewPassword.SendKeys(changePasswordData.NewPassword);
            ConfirmPassword.SendKeys(changePasswordData.ConfirmPassword);
            SaveButton.Click();

        }
        public string PasswordDoNotMatch()
        { 
            renderPasswordDoNotMatch();
            return AlertMessage2.Text;
        }
        public void changePassword(ChangePasswordData changePasswordData)
        {
            renderChangePasswordDropdown();
            ChangePasswordDropdown.Click();
            renderChangePasswordComponents();
            CurrentPassword.SendKeys(changePasswordData.CurrentPassword);
            NewPassword.SendKeys(changePasswordData.NewPassword);
            ConfirmPassword.SendKeys(changePasswordData.ConfirmPassword);
            SaveButton.Click();
        }

        public string getMessage()
        {
            renderMessage();
            return successMessage.Text;
        }

    }
}
