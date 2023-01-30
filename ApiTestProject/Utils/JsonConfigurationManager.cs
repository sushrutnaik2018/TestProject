using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject
{
    /// <summary>
    /// Purpose of this class is to support reading of global configuration values from Json config file
    /// </summary>
    public class JsonConfigurationManager
    {
        /// <summary>
        /// Get Application Under Test API url
        /// </summary>
        public static string ApplicationUrl => ConfigurationRoot[nameof(ApplicationUrl)];

        /// <summary>
        /// Getter\Setter for Accessing loaded Json configuration values
        /// </summary>
        public static IConfigurationRoot ConfigurationRoot { get; private set; }

        /// <summary>
        /// Read Json configuration file from project directory and load configuration values
        /// </summary>
        public static void BuildConfiguration()
        {
            if (ConfigurationRoot != null)
            {
                return;
            }

            //Get and read Json configuration file
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Configs/AppEnvConfig.json", false).AddEnvironmentVariables();
            //Load Json configuration values
            ConfigurationRoot = builder.Build();
        }
    }
}
