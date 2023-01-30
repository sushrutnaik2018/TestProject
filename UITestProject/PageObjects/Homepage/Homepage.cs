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
    public class HomePage : BasePage
    {
        public readonly HomePageMap Map;
        public HomePage(IWebDriver driver) : base(driver)
        {
            // Creates a new mapping file when the page object is created

            Map = new HomePageMap(driver);
        }

        // Test methods available to the test cases.
        // Navigate to application home page
        public void GoTo()
        {                      
            Helper.GoToUrl(JsonConfigurationManager.ApplicationUrl);
        }

        // Validate if Home Page was loaded
        public void ValidateHomePage()
        {
            Helper.WaitForPageToLoad(Map.AgDataLogo);
            Assert.That(Helper.GetTitle(), Is.EqualTo("HOME - AGDATA"));
            Assert.IsTrue(Map.Company.Displayed);            
        }

        // Highlight Company Menu option
        public void HoverCompanyMenu()
        {
            Helper.HighlightElement(Map.Company);
        }

    }

}
