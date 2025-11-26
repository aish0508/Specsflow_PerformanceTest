using AdvancedTaskPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.Pages.ProfileOverview
{
    public class ProfileMenuTabsComponent:CommonDriver
    {
        private IWebElement EducationTab;
        private IWebElement CertificationsTab;
      //  private IWebElement DescriptionTab;

        public void renderEducationComponents()
        {
            try
            {
                Wait.WaitToBeClickable(dr, "XPath", "//a[text()='Education']", 8);
                EducationTab = dr.FindElement(By.XPath("//a[text()='Education']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderCertificationComponents()
        {
            try
            {
                Wait.WaitToBeClickable(dr, "XPath", "//a[text()='Certifications']", 4);
                CertificationsTab = dr.FindElement(By.XPath("//a[text()='Certifications']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void clickEducationTab()
        {
            renderEducationComponents();
            Thread.Sleep(1000);
            EducationTab.Click();
            Thread.Sleep(4000);
        }
        public void clickCertificationsTab()
        {
            renderCertificationComponents();
            CertificationsTab.Click();
            Thread.Sleep(4000);
        }
    }
}
