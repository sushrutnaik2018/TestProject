using OpenQA.Selenium;
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
    public class CompanyPageMap : BasePage
    {
        public CompanyPageMap(IWebDriver driver) : base(driver)
        {
        }

        //Page elements used for synchronisation
        public By CompanyTab => By.XPath("//li[@id='menu-item-992']/a[1]");

        //Page elements for interaction
        public IWebElement CompanyMenu => Helper.LocateElement(Locators.Xpath, "//li[@id='menu-item-992']/a[1]");
        public IWebElement OverviewMenu => Helper.LocateElement(Locators.Xpath, "//li[@id='menu-item-829']/a[1]");
        public IWebElement LeadershipMenu => Helper.LocateElement(Locators.Xpath, "//li[@id='menu-item-271']/a[1]");
        public IWebElement CareerMenu => Helper.LocateElement(Locators.Xpath, "//li[@id='menu-item-269']/a[1]");
    }
}
