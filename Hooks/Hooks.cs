using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using AdvancedTaskPart2.Utilities;

namespace AdvancedTaskPart2.Hooks
{

        [Binding]
        public  sealed class Hooks : CommonDriver
        {
            public static ExtentReports extent;
            public static ExtentTest test;

            [BeforeTestRun]
            public static void ExtentStart()
            {
                extent = new ExtentReports();
                var SparkReporter = new ExtentSparkReporter("D:\\Advanced Task Part2-Mars-QA\\AdvancedTaskPart2\\AdvancedTaskPart2\\Extent Reports\\ExtentReport.html");
                extent.AttachReporter(SparkReporter);
            }

            [BeforeScenario]
            public void BeforeScenario()
            {
                InitializeWebDriver();
                test = extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
            }
            

            [AfterScenario]

            public void AfterScenario()
            {
                // Capture screenshot if scenario fails
                if (ScenarioContext.Current.TestError != null)
                {
                    string scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
                    Console.WriteLine($"Scenario '{scenarioTitle}' failed: {ScenarioContext.Current.TestError.Message}");
                    CaptureScreenshot(scenarioTitle);
                    test.Fail($"Scenario '{scenarioTitle}' failed: {ScenarioContext.Current.TestError.Message}");
                }
                else
                {
                    test.Pass("Scenario passed");
                }

              dr.Quit();

            }

            [AfterTestRun]
            public static void ExtentClose()
            {
                extent.Flush();
            }



            public void CaptureScreenshot(string scenarioTitle)
            {
                string screenshotFileName = $"screenshot_{scenarioTitle}";
                ITakesScreenshot ts = (ITakesScreenshot)dr;
                Screenshot screenshot = ts.GetScreenshot();
                string filePath = "D:\\Advanced Task Part2-Mars-QA\\AdvancedTask_specsflow\\Screenshots";
                string screenshotPath = Path.Combine(filePath, $"{screenshotFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                screenshot.SaveAsFile(screenshotPath);
            }

           
        }
    }



