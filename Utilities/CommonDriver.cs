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

       
    }
}