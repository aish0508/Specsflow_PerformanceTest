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
    public class NavigationMenuTabsComponent : CommonDriver
    {
        private IWebElement ManageListingsTab;
        private IWebElement ManageRequestsTab;

        public void renderManageListings()
        {
            try
            {
                Wait.WaitToBeClickable(dr, "XPath", "//a[text()='Manage Listings']", 10);
                ManageListingsTab = dr.FindElement(By.XPath("//a[text()='Manage Listings']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderManageRequests()
        {
            try
            {
                Wait.WaitToBeClickable(dr, "XPath", "//div[text()='Manage Requests']", 10);
                ManageRequestsTab = dr.FindElement(By.XPath("//div[text()='Manage Requests']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void clickManageListingsTab()
        {
            renderManageListings();
            ManageListingsTab.Click();
        }

        public void clickManageRequestsTab()
        {
            renderManageRequests();
            Thread.Sleep(1000);
            ManageRequestsTab.Click();
        }
    }
}
