using AdvancedTaskPart2.Model;
using AdvancedTaskPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.Pages.ProfileOverview
{
    public class AddAndDeleteCertificationsComponent:CommonDriver
    {
        private IWebElement deleteButton;
        private IWebElement CertificateTextbox;
        private IWebElement CertifiedFromTextbox;
        private IWebElement Year;
        private IWebElement AddButton;
        private IWebElement successMessage;
        private IWebElement closeMessageIcon;

        public void renderDeleteAllCertificationsComponents()
        {
            try
            {
                deleteButton = dr.FindElement(By.XPath("//div[@data-tab='fourth']//i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderAddComponents()
        {
            try
            {
                CertificateTextbox = dr.FindElement(By.XPath("//input[@name='certificationName']"));
                CertifiedFromTextbox = dr.FindElement(By.XPath("//input[@name='certificationFrom']"));
                Year = dr.FindElement(By.XPath("//select[@name='certificationYear']"));
                AddButton = dr.FindElement(By.XPath("//input[@value='Add']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderSuccessMessage()
        {
            try
            {
                successMessage = dr.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                closeMessageIcon = dr.FindElement(By.XPath("//*[@class='ns-close']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void DeleteAllCertifications()
        {
            int rowcount = dr.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody")).Count;
            for (int i = 1; i <= rowcount;)

            {
                renderDeleteAllCertificationsComponents();

                try
                {

                    Wait.WaitToBeClickable(dr, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i", 12);
                }
                catch (WebDriverTimeoutException e)
                {
                    return;
                }
                deleteButton.Click();
                Thread.Sleep(1000);
                rowcount--;
                Thread.Sleep(5000);

            }
        }

        public void addCertification(CertificationData certificationData)
        {
            renderAddComponents();
            CertificateTextbox.SendKeys(certificationData.Certificate);
            CertifiedFromTextbox.SendKeys(certificationData.CertifiedFrom);
            Year.SendKeys(certificationData.Year);
            AddButton.Click();
            Wait.WaitToBeVisible(dr, "XPath", "//div[@class='ns-box-inner']", 4);
        }

        public string getMessage()
        {
            renderSuccessMessage();
            string message = successMessage.Text;
            closeMessageIcon.Click();
            Thread.Sleep(6000);
            return message;
        }
    }
}
