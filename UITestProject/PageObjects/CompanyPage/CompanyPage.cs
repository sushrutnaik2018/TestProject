using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestProject
{
    /// <summary>
    /// This class stores all of the methods available to the page class
    /// </summary>
    public class CompanyPage:BasePage
    {
        public readonly CompanyPageMap Map;

        public CompanyPage(IWebDriver driver) : base(driver)
        {
            // Creates a new mapping file when the page object is created
            Map = new CompanyPageMap(driver);
        }

        // Test methods available to the test cases.
        // Wait for Company menu to load and then navigate to Careers page
        public void NavigateToCareerPage()
        {
            Helper.WaitForPageToLoad(Map.CompanyMenu);
            Map.CareerMenu.Click();            
        }

        // Wait for Company menu to load and then navigate to Overview page
        public void NavigateToOverviewPage()
        {
            Helper.WaitForPageToLoad(Map.CompanyMenu);
            Map.OverviewMenu.Click();
        }

        // Wait for Company menu to load and then navigate to Leadership page
        public void NavigateToLeadershipPage()
        {
            Helper.WaitForPageToLoad(Map.CompanyMenu);
            Map.LeadershipMenu.Click();
        }
    }
}
