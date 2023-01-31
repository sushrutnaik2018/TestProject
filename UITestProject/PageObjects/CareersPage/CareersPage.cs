using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestProject
{
    /// <summary>
    /// This class stores all of the methods available to the page class
    /// </summary>
    internal class CareersPage:BasePage
    {
        public readonly CareersPageMap Map;

        public CareersPage(IWebDriver driver) : base(driver)
        {
            // Creates a new mapping file when the page object is created
            Map = new CareersPageMap(driver);
        }

        // Test methods available to the test cases.
        // Verify if Careers page is open
        public void ValidateIfOnCareersPage()
        {
            Helper.WaitForPageToLoad(Map.CareersHeader);

            Assert.IsTrue(Map.ViewOpenPositions.Displayed);
        }

        // Navigate to Open Positions Section
        public void NavigateToOpenPositionSection()
        {
            Helper.WaitForPageToLoad(Map.JoinTheTeamHeader, 10);
            Map.ViewOpenPositions.Click();
        }
    }
}
