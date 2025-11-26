using AdvancedTaskPart2.Model;
using AdvancedTaskPart2.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.Pages.NavigationMenuComponent
{
    public class ManageListingsComponent: CommonDriver
    {
        private IWebElement TitleTextbox;
        private IWebElement DescriptionTextbox;
        private IWebElement StartDate;
        private IWebElement EndDate;
        private IWebElement SaveButton;
        private IWebElement newTitle;
        private IWebElement TagsTextbox;
        private IWebElement ServiceTypeRadioButton;
        private IWebElement LocationTypeRadioButton;
        private IWebElement SkillTradeRadioButton;
        private IWebElement ActiveRadioButton;
        private IWebElement CategoryDropdown;
        private IWebElement SubcategoryDropdown;
        private IWebElement CreditTextbox;

        public void renderAddComponents() 
        {
            try 
            {
                TitleTextbox = dr.FindElement(By.XPath("//input[@placeholder='Write a title to describe the service you provide.']"));
                DescriptionTextbox = dr.FindElement(By.XPath("//textarea[@name='description']"));
                TagsTextbox = dr.FindElement(By.XPath("(//input[contains(@placeholder,'Add new tag')])[1]"));
                ServiceTypeRadioButton = dr.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'Hourly basis service')]"));
                LocationTypeRadioButton = dr.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'On-site')]"));
                StartDate = dr.FindElement(By.XPath("//input[@placeholder='Start date']"));
                EndDate = dr.FindElement(By.XPath("//input[@placeholder='End date']"));
                SkillTradeRadioButton = dr.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'Credit')]/preceding-sibling::input[@type='radio']"));
                ActiveRadioButton = dr.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'Active')]"));
                SaveButton = dr.FindElement(By.XPath("//input[@value='Save']"));
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
        }
        public void renderCategory()
        {
            try
            {
                Wait.WaitToBeClickable(dr, "XPath", "//select[@name='categoryId']", 4);
                CategoryDropdown = dr.FindElement(By.XPath("//select[@name='categoryId']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderSubcategory()
        {
            try
            {
                SubcategoryDropdown = dr.FindElement(By.XPath("//select[@name='subcategoryId']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderCredit()
        {
            try
            {
                CreditTextbox = dr.FindElement(By.XPath("//input[@placeholder='Amount']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderUpdateComponents()
        {
            try
            {
                Wait.WaitToBeVisible(dr, "XPath", "//input[@name='title']", 4);
                TitleTextbox = dr.FindElement(By.XPath("//input[@name='title']"));
                DescriptionTextbox = dr.FindElement(By.XPath("//textarea[@name='description']"));
                SaveButton = dr.FindElement(By.XPath("//input[@value='Save']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderTitle(string title)
        {
            try
            {
                newTitle = dr.FindElement(By.XPath($"//td[@class='four wide'][text()='{title}'][1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void addShareSkill(ShareSkillData shareSkillData)
        {
            renderAddComponents();
            Thread.Sleep(3000);
            TitleTextbox.SendKeys(shareSkillData.Title);
            DescriptionTextbox.SendKeys(shareSkillData.Description);
            renderCategory();
            SelectElement chooseCategory = new SelectElement(CategoryDropdown);
            chooseCategory.SelectByText(shareSkillData.Category);
            renderSubcategory();
            SelectElement chooseSubcategory = new SelectElement(SubcategoryDropdown);
            chooseSubcategory.SelectByText(shareSkillData.Subcategory);
            TagsTextbox.SendKeys(shareSkillData.Tags);
            TagsTextbox.SendKeys(Keys.Enter);
            ServiceTypeRadioButton.Click();
            LocationTypeRadioButton.Click();
            StartDate.SendKeys(shareSkillData.StartDate);
            EndDate.SendKeys(shareSkillData.EndDate);
            SkillTradeRadioButton.Click();
            renderCredit();
            CreditTextbox.SendKeys(shareSkillData.Credit);
            ActiveRadioButton.Click();
            SaveButton.Click();
        }

        public void updateShareSkill(ShareSkillData shareSkillData)
        {
            renderUpdateComponents();
            TitleTextbox.Clear();
            TitleTextbox.SendKeys(shareSkillData.UpdateTitle);
            DescriptionTextbox.Clear();
            DescriptionTextbox.SendKeys(shareSkillData.UpdateDescription);
            SaveButton.Click();
        }

        public string getTitle(string title)
        {
            Thread.Sleep(6000);
            renderTitle(title);
            Thread.Sleep(2000);
            return newTitle.Text;
        }
    }
}
