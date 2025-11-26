using AdvancedTaskPart2.Model;
using AdvancedTaskPart2.Utilities;
using Aspose.Cells.Charts;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.Pages.ProfileOverview
{
    public class AddAndDeleteEducationComponent : CommonDriver
    {
        private IReadOnlyCollection<IWebElement> deleteButtons;
        private IWebElement UniversityNameTextbox;
        private IWebElement CountryOfUniversity;
        private IWebElement Title;
        private IWebElement Degree;
        private IWebElement YearOfGraduation;
        private IWebElement AddButton;
        private IWebElement successMessage;
        private IWebElement closeMessageIcon;
        private IWebElement AlertMessage;
        public void renderDeleteAllRecordsComponents()
        {
            try
            {
                deleteButtons = dr.FindElements(By.XPath("//div[@data-tab='third']//i[@class='remove icon']"));
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
                Thread.Sleep(1000);
                UniversityNameTextbox = dr.FindElement(By.XPath("//input[@name='instituteName']"));
                CountryOfUniversity = dr.FindElement(By.XPath("//select[@name='country']"));
                Title = dr.FindElement(By.XPath("//select[@name='title']"));
                Degree = dr.FindElement(By.XPath("//input[@name='degree']"));
                YearOfGraduation = dr.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
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
        public void DeleteAllEducation()
        {
            try
            {
                Wait.WaitToBeClickable(dr, "XPath", "//div[@data-tab='third']//i[@class='remove icon']", 4);
            }
            catch (WebDriverTimeoutException e)
            {
                return;
            }
            renderDeleteAllRecordsComponents();
            //Delete all records in the list
            foreach (IWebElement deleteButton in deleteButtons)
            {
                deleteButton.Click();
            }
        }
       
        public void addEducation(EducationData educationData)
        {
            Thread.Sleep(2000);
            renderAddComponents();
            Wait.WaitToBeClickable(dr, "XPath", "//input[@name='instituteName']", 4);
            UniversityNameTextbox.SendKeys(educationData.UniversityName);
            CountryOfUniversity.SendKeys(educationData.Country);
            Title.SendKeys(educationData.Title);
            Degree.SendKeys(educationData.Degree);
            YearOfGraduation.SendKeys(educationData.YearOfGraduation);
            AddButton.Click();
            Wait.WaitToBeVisible(dr, "XPath", "//div[@class='ns-box-inner']", 4);
        }

        public string getMessage()
        {
            renderSuccessMessage();
            string message = successMessage.Text;
            Thread.Sleep(2000);
            closeMessageIcon.Click();
            Thread.Sleep(6000);
            return message;
        }
    }
}
