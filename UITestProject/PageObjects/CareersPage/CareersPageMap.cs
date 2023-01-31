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
        

        //Page elements for interaction
        public IWebElement ViewOpenPositions => Helper.LocateElement(Locators.Xpath, "//a[@href='#openings']");        

    }
}
