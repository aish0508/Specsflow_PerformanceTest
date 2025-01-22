using AdvancedTaskPart2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2.Pages.AccountMenu
{
    public class UserTab : CommonDriver
    {
        private IWebElement Usertab;

        public void renderUserTab()
        {
            try
            {
                Wait.WaitToBeClickable(dr, "XPath", "//*[starts-with(text(),'Hi')]", 4);
                Usertab = dr.FindElement(By.XPath("//*[starts-with(text(),'Hi')]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void clickUserTab()
        {
            renderUserTab();
            Usertab.Click();
        }
    }
}
