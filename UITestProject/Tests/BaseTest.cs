using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

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
            ExtentReportTestSuiteHandler.CreateParentTest(GetType().Name);
        }

        /// <summary>
        /// One time cleanup events
        /// </summary>
        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            ExtentReportService.Instance.Flush();
            //ExtentReportService.BuildExtentReport().Flush();
        }

        [SetUp]
        public void TestSetup()
        {
            ExtentReportTestSuiteHandler.CreateTest(TestContext.CurrentContext.Test.Name);
            JsonConfigurationManager.BuildConfiguration();
            var factory = new WebDriverInstances();            
            Driver = factory.GetDriver(Network.Local, BrowserType.Chrome);
            Driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromMinutes(3));            
            Pages.Init(Driver);
        }

        [TearDown]
        public void TestEnding()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
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
                throw new Exception("Exception: " + ex);
            }
            finally
            {
                Driver.Close();
                Driver.Quit();
            }
            
        }
    }
}