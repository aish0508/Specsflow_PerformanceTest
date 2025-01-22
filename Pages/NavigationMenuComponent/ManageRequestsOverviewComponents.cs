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
    public class ManageRequestsOverviewComponents : CommonDriver
    {
        private IWebElement ReceivedRequestsDropdown;
        private IWebElement SentRequestsDropdown;

        public void renderReceivedRequestsComponent()
        {
            try
            {
                Wait.WaitToBeClickable(dr, "XPath", "//a[text()='Received Requests']", 6);
                ReceivedRequestsDropdown = dr.FindElement(By.XPath("//a[text()='Received Requests']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderSentRequestsComponent()
        {
            try
            {
                Wait.WaitToBeClickable(dr, "XPath", "//a[text()='Sent Requests']", 6);
                SentRequestsDropdown = dr.FindElement(By.XPath("//a[text()='Sent Requests']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickReceivedRequests()
        {
            renderReceivedRequestsComponent();
            ReceivedRequestsDropdown.Click();
        }

        public void clickSentRequests()
        {
            renderSentRequestsComponent();
            SentRequestsDropdown.Click();
        }
    }
}
