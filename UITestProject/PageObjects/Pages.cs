using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITestProject.PageObjects.OpenPositionsPage;

namespace UITestProject
{
    internal class Pages : BaseTest
    {

        // This class is utilised by giving all of the page objects values when the initialise method is called prior to the tests execution. When this occurs, they can be referenced in the tests.

        public static HomePage Home;
        public static CompanyPage Company;
        public static CareersPage Careers;
        public static OpenPositionsPage OpenPositions;

        public static void Init(IWebDriver driver)
        {
            Home = new HomePage(driver);
            Company = new CompanyPage(driver);
            Careers = new CareersPage(driver);
            OpenPositions = new OpenPositionsPage(driver);
        }
    
    }
}
