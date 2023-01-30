using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V107.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestProject
{
    /// <summary>
    /// This class stores the locators to all of the elements that can be interacted with on the page
    /// </summary>
    internal class CareersPageMap : BasePage
    {
        public CareersPageMap(IWebDriver driver) : base(driver)
        {

        }

        //Page elements used for synchronisation
        public By CareersHeader => By.XPath("//h1[text()='Careers']");
        public By JoinTheTeamHeader => By.XPath("//h2[text()='JOIN THE TEAM']");
        public By OpenPositionsTitle => By.XPath("//span[text()='Open Positions']");


        //Page elements for interaction
        public IWebElement ViewOpenPositions => Helper.LocateElement(Locators.LinkText, "View Open Positions");
        public IWebElement KeywordToSearch => Helper.LocateElement(Locators.CssSelector, "input#keywords");
        public IEnumerable<IWebElement> OpenPositionsSection => Helper.LocateElements(Locators.Xpath, "//head[@id='ctl00_Head1']/following-sibling::body[1]");
        public IList<IWebElement> AllJobsList => Helper.LocateElements(Locators.ClassName, "jobs");
        public IWebElement ManagerPosition => Helper.LocateElement(Locators.Xpath, "//span[text()='Technical Engagement Manager']");


    }
}
