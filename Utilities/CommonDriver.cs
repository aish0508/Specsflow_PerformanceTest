using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace AdvancedTaskPart2.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver dr { get; set; }


        public static void InitializeWebDriver()
        {
            dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("http://localhost:5000/Home");
        }

        //public static void TearDown()
        //{
        //    if (dr != null)
        //    {
        //        dr.Quit(); // Use Quit to close all windows and end the WebDriver session
        //        dr = null; // Ensure the driver instance is null after closing
        //    }

        //}
    }
}