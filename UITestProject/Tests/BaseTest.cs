using ApiTestProject;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Serilog;
using System;

namespace UITestProject
{
    public class BaseTest
    {
        private IWebDriver Driver { get; set; }

        /// <summary>
        /// One time initiation events 
        /// </summary>
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            JsonConfigurationManager.BuildConfiguration();
            Log.Information("Loaded AppEnvConfig.json file properties");

            Log.Logger = LogHelper.GetLogger();
            Log.Information("Extent Report Initiate");

            ExtentReportTestSuiteHandler.CreateParentTest(GetType().Name);
        }

        /// <summary>
        /// One time cleanup events
        /// </summary>
        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            Log.Information("Extent Report Clean up");
            ExtentReportService.Instance.Flush();
        }

        [SetUp]
        public void TestSetup()
        {
            ExtentReportTestSuiteHandler.CreateTest(TestContext.CurrentContext.Test.Name);
            Log.Information("Added Extent Report Test Name :"+ TestContext.CurrentContext.Test.Name);
                        
            var factory = new WebDriverInstances();            
            Driver = factory.GetDriver(Network.Local, BrowserType.Chrome);
            Log.Information("Set Driver intance: " + Driver);
                      
            Driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromMinutes(3));            
            Pages.Init(Driver);
            Log.Information("Driver initialized: " + Driver);
        }

        [TearDown]
        public void TestEnding()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                Log.Information("Test Outcome: " + status.ToString());
                var message = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message) ? "" : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);
                var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
                switch (status)
                {
                    case TestStatus.Failed:
                        ExtentReportMessages.Fail("Test Failed");
                        ExtentReportMessages.Fail(message);
                        ExtentReportMessages.Fail(stackTrace);
                        break;
                    case TestStatus.Passed:
                        ExtentReportMessages.Pass("Test Passed");
                        break;
                    case TestStatus.Skipped:
                        ExtentReportMessages.Pass("Test Skipped");
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                Log.Error("Test failed to execute with an exception: " + ex.Message);
                throw new Exception("Exception: " + ex);
            }
            finally
            {
                Driver.Close();
                Log.Information("Close all browser instances");
                Driver.Quit();
                Log.Information("Quite Driver");
            }
            
        }
    }
}