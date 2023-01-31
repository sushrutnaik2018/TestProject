using Serilog.Core;
using Serilog.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Formatting.Json;
using UITestProject;

namespace ApiTestProject
{
    internal class LogHelper
    {
        /// <summary>
        /// Method provide serilog logger implementation
        /// </summary>
        /// <returns></returns>
        public static Logger GetLogger()
        {
            LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch(GetLogLevel());
            string subFolder = String.Format(DateTime.Now.ToString("MM-dd-yyyy_hh-mm-ss-tt"));
            string logDirectory = Path.Combine(Utility.GetProjectRootDirectory(), JsonConfigurationManager.SeriLogFolder + subFolder);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            string logPath = Path.Combine(logDirectory, JsonConfigurationManager.SeriLogFileName);
            return new LoggerConfiguration()
                    .MinimumLevel.ControlledBy(levelSwitch)
                    .WriteTo.File(new JsonFormatter(),logPath).CreateLogger();
        }

        /// <summary>
        /// Fetch log level from Json Configuration file
        /// </summary>
        /// <returns>LogEventLevel</returns>
        public static LogEventLevel GetLogLevel()
        {
            return JsonConfigurationManager.SeriLogLevel switch
            {
                "Informational" => LogEventLevel.Information,
                "Debug" => LogEventLevel.Debug,
                "Error" => LogEventLevel.Error,
                "Fatal" => LogEventLevel.Fatal,
                "Warning" => LogEventLevel.Warning,
                _ => LogEventLevel.Information,
            };
        }
    }
}
