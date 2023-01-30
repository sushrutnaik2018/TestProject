using ApiTestProject.Globals;
using AventStack.ExtentReports;
using Newtonsoft.Json;
using NUnit.Framework.Interfaces;
using System;
using System.Dynamic;
using System.Net;
using System.Net.Http.Json;

namespace ApiTestProject
{
    public class BaseTests
    {
        protected string? url;
        protected HttpResponseMessage? response;
        protected HttpClient client;

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


        /// <summary>
        /// Initial setup required for tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            ExtentReportTestSuiteHandler.CreateTest(TestContext.CurrentContext.Test.Name);
            JsonConfigurationManager.BuildConfiguration();
            var uri = new Uri(JsonConfigurationManager.ApplicationUrl);
            client = Controller.GetClient(uri);
        }

        /// <summary>
        /// Cleanup steps for tests
        /// </summary>
        /// <exception cref="Exception"></exception>
        [TearDown]
        public void Teardown()
        {
            try 
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var message = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)?"":string.Format("<pre>{0}</pre>",TestContext.CurrentContext.Result.Message);
                var stackTrace= string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
                switch(status)
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
                    case TestStatus.Inconclusive: 
                        ExtentReportMessages.Pass("Test Inconclusive");
                        break;
                    default:
                        break;

                }
            }
            catch(Exception ex)
            {
                throw new Exception("Exception: " + ex);
            }
            finally {
                //To Do - Any required test cleanup or flush operations
            }
        }

        // To Do - Implement Test Scope
        // -> Do not use
        public sealed class TestScope : IDisposable
        {
            //protected string? url;
            //protected HttpResponseMessage? response;
            //protected HttpClient client;
            public TestScope()
            {
                //url = "https://jsonplaceholder.typicode.com";
                //JsonConfigurationManager.BuildConfiguration();
                //var uri = new Uri(JsonConfigurationManager.ApplicationUrl);
                //client = Controller.GetClient(uri);
            }

            public void Dispose()
            {
                //clean-up code goes here
                //client?.Dispose();
            }
        }

    }
}


