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
    public class HomePageMap : BasePage
    {
        public HomePageMap(IWebDriver driver) : base(driver)
        {
        }

        //Page elements used for synchronisation
        public By AgDataLogo => By.ClassName("site-title");

        //Page elements for interaction
        public IWebElement Solutions => Helper.LocateElement(Locators.Xpath, "//li[@id='menu-item-991']/a[1]");
        public IWebElement Markets => Helper.LocateElement(Locators.Xpath, "//li[@id='menu-item-990']/a[1]");
        public IWebElement Company => Helper.LocateElement(Locators.ID, "menu-item-992");
        public IWebElement Resources => Helper.LocateElement(Locators.Xpath, "//li[@id='menu-item-1825']/a[1]");
        public IWebElement Contact => Helper.LocateElement(Locators.Xpath, "//li[@id='menu-item-274']/a[1]");

    }
}
