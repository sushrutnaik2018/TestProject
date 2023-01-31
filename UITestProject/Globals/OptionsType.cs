using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestProject
{
    internal class OptionsType
    {
        public static readonly string StartMaximized = "start-maximized";
        public static readonly string EnableAutomation = "enable-automation";
        public static readonly string Headless = "--headless";
        public static readonly string NoSandbox = "--no-sandbox";
        public static readonly string Incognito = "--incognito";
        public static readonly string DisableDevShmUsage = "--disable-dev-shm-usage";
        public static readonly string DisableBrowserSideNavigation = "--disable-browser-side-navigation";
        public static readonly string DisableGpu = "--disable-gpu";
        public static readonly string IgnoreCertificateErrors = "--ignore-certificate-errors";            
    }
}
