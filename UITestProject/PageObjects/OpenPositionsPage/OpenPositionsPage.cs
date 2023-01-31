using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestProject.PageObjects.OpenPositionsPage
{
    internal class OpenPositionsPage : BasePage
    {
        public readonly OpenPositionsPageMap Map;
        public OpenPositionsPage(IWebDriver driver) : base(driver)
        {
            // Creates a new mapping file when the page object is created
            Map = new OpenPositionsPageMap(driver);
        }

        // Navigate to Open Positions Section
        public void ValidateOpenPositionSection()
        {
            Helper.SwitchToIFrame(Map.HBIFrame);
            Helper.WaitForPageToLoad(Map.AllDepartmentDropDown, 10);
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
                    var allChildElements = findManager.FindElements(By.XPath("*"));
                    foreach(var childElement in allChildElements)
                    {
                        if(childElement.TagName== "a")
                        {
                            Helper.ClickOnElementUsingJS(childElement);
                            Helper.WaitForTextToBePresent(Map.ManagerPosition, "Technical Engagement Manager");
                        }
                        break;
                    }
                    
                    break;
                }
            }
            Helper.SwitchToDefaultContent();
        }
    }
}
