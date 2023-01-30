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
            Map.ViewOpenPositions.Click();
            Helper.WaitForTextToBePresent(Map.KeywordToSearch, "Keywords to search", 10);
        }

        // Retrieve all Jobs list and iterate to second manager job and click on it
        public void ClickSecondManagerLink()
        {
            int managerCount = 0;
            IList<IWebElement> list = Map.AllJobsList;
            foreach (IWebElement element in list)
            {
                var findManager = element.FindElement(By.ClassName("job"));
                if (findManager.Text.Contains("Manager"))
                {
                    managerCount++;                        
                }
                if (managerCount > 1)
                {
                    findManager.Click();
                    Helper.WaitForTextToBePresent(Map.ManagerPosition, "Technical Engagement Manager");
                    break;
                }
            }
            
        }

    }
}
