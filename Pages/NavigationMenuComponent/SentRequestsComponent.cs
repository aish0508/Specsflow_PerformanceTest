using AdvancedTaskPart2.Model;
using AdvancedTaskPart2.Utilities;
using Microsoft.Graph.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.Pages.NavigationMenuComponent
{
    public class SentRequestsComponent : CommonDriver
    {
        private IWebElement WithdrawButton;
        private IWebElement successMessage;
        private IWebElement closeMessageIcon;

        public void renderWithdrawComponent(string title)
        {
            try
            {
                WithdrawButton = dr.FindElement(By.XPath($"//table[@class='ui single line sortable striped table sortableHeader']//a[text()='{title}']/../following-sibling::td[@class='two wide']/button[text()='Withdraw']"));
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

        public void clickWithdrawButton(SentRequestsData sentRequestsData)
        {
            Thread.Sleep(4000);
            string title = sentRequestsData.Title;
            renderWithdrawComponent(title);
            Thread.Sleep(2000);
            WithdrawButton.Click();
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
