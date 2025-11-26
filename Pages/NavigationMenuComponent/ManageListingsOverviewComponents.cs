using AdvancedTaskPart2.Model;
using AdvancedTaskPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.Pages.NavigationMenuComponent
{
    public class ManageListingsOverviewComponents:CommonDriver
    {
        private IWebElement ShareSkillButton;
        private IWebElement EditButton;
        private IWebElement DeleteButton;
        private IWebElement YesButton;
        private IWebElement successMessage;
        private IWebElement ActiveCheckbox;
        private IWebElement ViewButton;
        private IWebElement ViewTitle;
        public void renderShareSkill()
        {
            try
            {
                ShareSkillButton = dr.FindElement(By.XPath("//*[@id='listing-management-section']/section[1]/div/div[2]/a"));
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void renderEditButton(string existingTitle)
        {
            try
            {
                EditButton = dr.FindElement(By.XPath($"//td[text()='{existingTitle}']/following-sibling::td/div/button[@class='ui button']/i[@class='outline write icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderViewComponents(string title)
        {
            try
            {
                ViewButton = dr.FindElement(By.XPath($"//td[text()='{title}']/following-sibling::td/div/button[@class='ui button']/i[@class='eye icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderViewTitle(string title)
        {
            try
            {
                ViewTitle = dr.FindElement(By.XPath($"//span[text()='{title}']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderDeleteButton(string title)
        {
            try
            {
                DeleteButton = dr.FindElement(By.XPath($"//td[text()='{title}']/following-sibling::td/div/button[@class='ui button']/i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderYesButton()
        {
            try
            {
                YesButton = dr.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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

        public void renderActiveChechbox(string title)
        {
            try
            {
                ActiveCheckbox = dr.FindElement(By.XPath($"//td[text()='{title}']/following-sibling::td/div[@class='ui toggle checkbox']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickShareSkillButton()
        {
            Thread.Sleep(4000);
            renderShareSkill();
            ShareSkillButton.Click();
        }

        public void clickUpdateButton(ShareSkillData shareSkillData)
        {
            string existingTitle = shareSkillData.Title;
            Thread.Sleep(6000);
            renderEditButton(existingTitle);
            EditButton.Click();
        }

        public void clickViewButton(ShareSkillData shareSkillData)
        {
            string title = shareSkillData.UpdateTitle;
            Thread.Sleep(6000);
            renderViewComponents(title);
            Thread.Sleep(2000);
            ViewButton.Click();
        }

        public string getViewTitle(string title)
        {
            Thread.Sleep(6000);
            renderViewTitle(title);
            return ViewTitle.Text;
        }

        public void clickDeleteButton(ShareSkillData shareSkillData)
        {
            string title = shareSkillData.Title;
            Thread.Sleep(6000);
            renderDeleteButton(title);
            DeleteButton.Click();
            renderYesButton();
            YesButton.Click();
        }

        public string getMessage()
        {
            renderMessage();
            return successMessage.Text;
        }

        public void disableActiveCheckbox(ShareSkillData shareSkillData)
        {
            string title = shareSkillData.Title;
            Thread.Sleep(6000);
            renderActiveChechbox(title);
            ActiveCheckbox.Click();
        }

        public void enableActiveCheckbox(ShareSkillData shareSkillData)
        {
            string title = shareSkillData.Title;
            Thread.Sleep(4000);
            renderActiveChechbox(title);
            ActiveCheckbox.Click();
        }

    }
}
