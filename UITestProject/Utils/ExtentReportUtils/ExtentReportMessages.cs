using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestProject
{
    public class ExtentReportMessages
    {
        public static void Pass(string message)
        {
            ExtentReportTestSuiteHandler.GetTest().Pass(message);
        }

        public static void Fail(string message,MediaEntityModelProvider media=null)
        {
            ExtentReportTestSuiteHandler.GetTest().Fail(message,media);
        }

        public static void Skip(string message)
        {
            ExtentReportTestSuiteHandler.GetTest().Skip(message);
        }
    }
}
