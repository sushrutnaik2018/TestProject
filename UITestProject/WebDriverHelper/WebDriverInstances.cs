using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace UITestProject
{
    /// <summary>
    /// Purpose of this class to setup required instance of Webdriver
    /// </summary>
    internal class WebDriverInstances
    {
        /// <summary>
        /// Methods help to setup desired intance of WebDriver
        /// </summary>
        /// <param name="type">Network Type</param>
        /// <param name="name">Browser Type</param>
        /// <returns>Webdriver Instance</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal IWebDriver GetDriver(Network type, BrowserType name)
        {
            return type switch
            {
                Network.Local => (name switch
                {
                    BrowserType.Chrome => GetChromeDriver(),
                    BrowserType.Edge => GetEdgeDriver(),
                    BrowserType.Firefox => GetFirefoxDriver(),
                    _ => throw new ArgumentOutOfRangeException(name.ToString(), $"No such browser {name.ToString()}")
                }),
                Network.Remote => (name switch
                {
                    BrowserType.Sauce => GetDockerDriver(),
                    BrowserType.Docker => GetSauceDriver(),
                    _ => throw new ArgumentOutOfRangeException(type.ToString(), $"Unknown Environment {type.ToString()}")
                }),
                _ => throw new NotImplementedException()
            };
        }

        /// <summary>
        /// Initiate Chrome Driver instance with required options/capabilities
        /// </summary>
        /// <returns>Chrome Driver</returns>
        private IWebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments(
            OptionsType.StartMaximized,
            OptionsType.EnableAutomation,
            //OptionsType.Headless//"--headless",
            OptionsType.NoSandbox,
            OptionsType.DisableInfobars,
            OptionsType.DisableDevShmUsage,
            OptionsType.DisableBrowserSideNavigation,
            OptionsType.DisableGpu,
            OptionsType.IgnoreCertificateErrors);

            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver("..\\DriverFiles", options, TimeSpan.FromMinutes(3));
        }

        /// <summary>
        /// Initiate Edge Driver instance with required options/capabilities
        /// </summary>
        /// <returns>Edge Driver</returns>
        private IWebDriver GetEdgeDriver()
        {
            var options = new EdgeOptions();
            options.AddArgument(OptionsType.StartMaximized);
            options.AddArgument(OptionsType.NoSandbox);

            new DriverManager().SetUpDriver(new EdgeConfig());
            return new EdgeDriver(options);
        }

        /// <summary>
        /// Initiate Firefox Driver instance with required options/capabilities
        /// </summary>
        /// <returns>Firefox Driver</returns>
        private IWebDriver GetFirefoxDriver()
        {
            var options = new FirefoxOptions();
            options.AddArgument(OptionsType.StartMaximized);
            options.AddArgument(OptionsType.NoSandbox);

            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver(options);
        }

        /// <summary>
        /// Initiate Docker Remote Driver instance with required options/capabilities
        /// </summary>
        /// <returns>Remote Driver</returns>
        public IWebDriver GetDockerDriver()
        {
            //To Do - in progress implementation and testing of this method for Docker integration
            //Do not use
            var options = new ChromeOptions
            {
                PlatformName = "Windows 10",
                BrowserVersion = "latest",
                UseSpecCompliantProtocol = true
            };

            return new RemoteWebDriver(new Uri(JsonConfigurationManager.DockerUrl), options.ToCapabilities(), TimeSpan.FromSeconds(600));
        }

        /// <summary>
        /// Initiate SauceLabs Remote Driver instance with required options/capabilities
        /// </summary>
        /// <returns>Remote Driver</returns>
        private IWebDriver GetSauceDriver()
        {
            //To Do - in progress implementation and testing of this method for SauceLabs integration
            //Do not use
            var sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            var sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);
            var options = new ChromeOptions
            {
                PlatformName = "Windows 10",
                BrowserVersion = "latest",
                UseSpecCompliantProtocol = true
            };

            var sauceOptions = new Dictionary<string, object>
            {
                { "username", sauceUserName },
                { "accessKey", sauceAccessKey }
            };

            return new RemoteWebDriver(new Uri(JsonConfigurationManager.SauceLabsUrl),
                options.ToCapabilities(), TimeSpan.FromSeconds(600));
        }
    }
}
