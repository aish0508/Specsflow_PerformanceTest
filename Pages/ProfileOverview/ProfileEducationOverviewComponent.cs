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
    public class ProfileEducationOverviewComponent:CommonDriver
    {
        private IWebElement AddNewButton;
        private IWebElement DeleteButton;
        public void renderAddButton()
        {
            try
            {
                AddNewButton = dr.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderDeleteButton(string country, string universityName, string degree)
        {
            try
            {
                DeleteButton = dr.FindElement(By.XPath($"//div[@data-tab='third']//tr[td[1]='{country}' and td[2]='{universityName}' and td[4]='{degree}']/td[last()]/span[2]"));
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }
        }
        public void clickAddNewButton()
        {
            Thread.Sleep(1000);
            renderAddButton();
            AddNewButton.Click();
        }
        public void clickDeleteButton(EducationData educationData)
        {
            string country = educationData.Country;
            string universityName = educationData.UniversityName;
            string degree = educationData.Degree;
            renderDeleteButton(country, universityName, degree);
            DeleteButton.Click();
            Wait.WaitToBeVisible(dr, "XPath", "//div[@class='ns-box-inner']", 4);
        }

    }
}
