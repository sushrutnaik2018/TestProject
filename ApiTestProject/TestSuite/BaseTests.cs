using ApiTestProject.Globals;
using AventStack.ExtentReports;
using MongoDB.Libmongocrypt;
using Newtonsoft.Json;
using NUnit.Framework.Interfaces;
using Serilog;
using Serilog.Core;
using Serilog.Events;
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


        /// <summary>
        /// Initial setup required for tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            ExtentReportTestSuiteHandler.CreateTest(TestContext.CurrentContext.Test.Name);
            
            JsonConfigurationManager.BuildConfiguration();
            Log.Information("Loaded AppEnvConfig.json file properties");

            var uri = new Uri(JsonConfigurationManager.ApplicationUrl);
            Log.Information("Getting Application API url: "+ uri.ToString());

            client = Controller.GetClient(uri);
            Log.Information("Fetch http client info: "+client.ToString());
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
                Log.Information("Test Outcome: " + status.ToString());
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
                Log.Error("Test failed to execute with an exception: " + ex.Message);
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


