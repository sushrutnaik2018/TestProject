using Serilog.Core;
using Serilog.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Formatting.Json;

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
            LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch(LogEventLevel.Information);
            string subFolder = String.Format(DateTime.Now.ToString("MM-dd-yyyy_hh-mm-ss-tt"));
            string logDirectory = Path.Combine(Utility.GetProjectRootDirectory(), "Logs\\" + subFolder);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            string logPath = Path.Combine(logDirectory, "serilog.json");
            return new LoggerConfiguration()
                    .MinimumLevel.ControlledBy(levelSwitch)
                    .WriteTo.File(new JsonFormatter(),logPath).CreateLogger();
        }
    }
}
