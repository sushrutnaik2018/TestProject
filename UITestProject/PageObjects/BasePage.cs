using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITestProject.WebDriverHelper;

namespace UITestProject
{
    /// <summary>
    /// This class serves as Base page to the page classes
    /// </summary>
    public class BasePage
    {
        protected WebDriverHelpers Helper { get; }

        protected BasePage(IWebDriver driver)
        {
            Helper = new WebDriverHelpers(driver);
        }
    }
}
