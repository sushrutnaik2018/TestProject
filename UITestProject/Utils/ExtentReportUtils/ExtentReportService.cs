using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestProject
{
    public class ExtentReportService
    {
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());
        public static ExtentReports Instance { get { return _lazy.Value; } }

        /// <summary>
        /// Buid Extent HTML report
        /// </summary>
        static ExtentReportService()
        {
            string subFolder = String.Format(DateTime.Now.ToString("MM-dd-yyyy_hh-mm-ss-tt"));
            string reportDirectory = Path.Combine(Utility.GetProjectRootDirectory(), "Report\\"+ subFolder);
            if (!Directory.Exists(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }
            
            string path = Path.Combine(reportDirectory, "index.html");
            var htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.DocumentTitle = "API Test Project Report";
            htmlReporter.Config.ReportName = "API Test Results";
            htmlReporter.Config.Theme = Theme.Standard;

            Instance.AttachReporter(htmlReporter);
        }

        private ExtentReportService()
        {
        }
    }
}
