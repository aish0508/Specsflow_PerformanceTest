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
    public class ProfileCertificationsOverviewComponent:CommonDriver
    {
        private IWebElement AddNewButton;
        private IWebElement DeleteButton;

        public void renderAddButton()
        {
            try
            {
                AddNewButton = dr.FindElement(By.XPath("//div[@class='four wide column' and h3='Certification']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']//div"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderDeleteButton(string certificate, string certifiedFrom)
        {
            try
            {
                DeleteButton = dr.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));
                //DeleteButton = dr.FindElement(By.XPath($"//div[@data-tab='fourth']//tr[td[1]='{certificate}' and td[2] ='{certifiedFrom}']/td[last()]/span[2]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickAddNewButton()
        {
            Thread.Sleep(8000);
            renderAddButton();
            AddNewButton.Click();
        }

        public void clickDeleteButton(CertificationData certificationData)
        {
            //Thread.Sleep(6000);
            string certificate = certificationData.Certificate;
            string certifiedFrom = certificationData.CertifiedFrom;
            renderDeleteButton(certificate, certifiedFrom);
           // Wait.WaitToBeClickable(dr, "XPath", $"//div[@data-tab='fourth']//tr[td[1]='{certificate}' and td[2] ='{certifiedFrom}']/td[last()]/span[2]", 15);
            DeleteButton.Click();
            Wait.WaitToBeVisible(dr, "XPath", "//div[@class='ns-box-inner']", 4);
        }
    }





}
