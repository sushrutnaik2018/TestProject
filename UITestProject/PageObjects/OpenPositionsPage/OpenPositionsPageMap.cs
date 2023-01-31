using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestProject
{
    internal class OpenPositionsPageMap: BasePage
    {
        public OpenPositionsPageMap(IWebDriver driver) : base(driver)
        {
        }

        //Page elements used for synchronisation
        public By OpenPositionsTitle => By.XPath("//span[text()='Open Positions']");
        public By AllDepartmentDropDown => By.XPath("//label[text()='Department']/following-sibling::select");
        //public By OpenP => By.XPath("//span[text()='Open Positions']");

        //Page elements for interaction
        public IWebElement HBIFrame => Helper.LocateElement(Locators.ID, "HBIFRAME");
        public IWebElement KeywordToSearch => Helper.LocateElement(Locators.Xpath, "//input[@placeholder='Keywords to search']");
        public IEnumerable<IWebElement> OpenPositionsSection => Helper.LocateElements(Locators.Xpath, "//head[@id='ctl00_Head1']/following-sibling::body[1]");
        public IList<IWebElement> AllJobsList => Helper.LocateElements(Locators.ClassName, "jobs");
        public IWebElement ManagerPosition => Helper.LocateElement(Locators.Xpath, "//span[text()='Technical Engagement Manager']");


    }
}
