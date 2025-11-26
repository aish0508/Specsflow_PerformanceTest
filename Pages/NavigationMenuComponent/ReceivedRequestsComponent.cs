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
    public class ReceivedRequestsComponent : CommonDriver
    {
        private IWebElement AcceptButton;
        private IWebElement successMessage;
        private IWebElement closeMessageIcon;
        private IWebElement DeclineButton;
        private IWebElement CompleteButton;

        public void renderAcceptComponent(string title)
        {
            try
            {
                AcceptButton = dr.FindElement(By.XPath($"//table[@class='ui single line sortable striped table sortableHeader']//a[text()='{title}']/../following-sibling::td[@class='two wide']/button[text()='Accept']"));
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

        public void renderDeclineComponent(string title)
        {
            try
            {
                DeclineButton = dr.FindElement(By.XPath($"//table[@class='ui single line sortable striped table sortableHeader']//a[text()='{title}']/../following-sibling::td[@class='two wide']/button[text()='Decline']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderCompleteComponent(string title)
        {
            try
            {
                CompleteButton = dr.FindElement(By.XPath($"//table[@class='ui single line sortable striped table sortableHeader']//a[text()='{title}']/../following-sibling::td[@class='two wide']/button[text()='Complete']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickAcceptButton(ReceivedRequestsData receivedRequestsData)
        {
            Thread.Sleep(50000);
            string title = receivedRequestsData.Title;
            Thread.Sleep(3000);
            renderAcceptComponent(title);
            Thread.Sleep(3000);
            AcceptButton.Click();
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

        public void clickDeclineButton(ReceivedRequestsData receivedRequestsData)
        {
            Thread.Sleep(30000);
            string title = receivedRequestsData.Title;
            Thread.Sleep(3000);
            renderDeclineComponent(title);
            Thread.Sleep(1000);
            DeclineButton.Click();
            Wait.WaitToBeVisible(dr, "XPath", "//div[@class='ns-box-inner']", 4);
        }

        public void clickCompleteButton(ReceivedRequestsData receivedRequestsData)
        {
            Thread.Sleep(30000);
            string title = receivedRequestsData.Title;
            Thread.Sleep(3000);
            renderCompleteComponent(title);
            Thread.Sleep(3000);
            CompleteButton.Click();
            Wait.WaitToBeVisible(dr, "XPath", "//div[@class='ns-box-inner']", 4);
        }
    }
}
