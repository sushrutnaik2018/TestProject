using OpenQA.Selenium.Support.UI;

using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Http;
using OpenQA.Selenium.Interactions;
using System.Security.Policy;

namespace UITestProject.WebDriverHelper
{
    /// <summary>
    /// Purpose of this class to provide required Webdriver helper methods
    /// </summary>
    public class WebDriverHelpers
    {
        private IWebDriver Driver { get; }
        protected Actions actions;

        public WebDriverHelpers(IWebDriver driver)
        {
            Driver = driver;

            //Instantiate Action Class
            actions = new Actions(driver);
        }

        //Helper function to highlight Web element
        public void HighlightElement(IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)Driver;
            jsDriver.ExecuteScript("arguments[0].style.border='3px solid red'", element);
        }

        //Helper function to wait for Page Load till Expected condition is met
        public void WaitForPageToLoad(By name, int duration = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(duration));
            wait.Until(ExpectedConditions.ElementIsVisible(name));
        }

        //Helper function to wait for Web Element to be present till Expected condition is met
        public void WaitForTextToBePresent(IWebElement element, string text, int duration = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(duration));
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }

        //Helper function to locate Web Element with required Locator Type
        public IWebElement LocateElement(Locators type, string name)
        {
            return type switch
            {
                Locators.Xpath => Driver.FindElement(By.XPath(name)),
                Locators.CssSelector => Driver.FindElement(By.CssSelector(name)),
                Locators.ID => Driver.FindElement(By.Id(name)),
                Locators.Name => Driver.FindElement(By.Name(name)),
                Locators.LinkText => Driver.FindElement(By.LinkText(name)),
                Locators.ClassName => Driver.FindElement(By.ClassName(name)),
                Locators.PartialLinkText => Driver.FindElement(By.PartialLinkText(name)),
                Locators.TagName => Driver.FindElement(By.TagName(name)),
                _ => throw new ArgumentOutOfRangeException(type.ToString(), $"Invalid Type, {type.ToString()}")
            };
        }

        //Helper function to locate Web Elements with required Locator Type
        public IList<IWebElement> LocateElements(Locators type, string name)
        {
            return type switch
            {
                Locators.Xpath => Driver.FindElements(By.XPath(name)),
                Locators.CssSelector => Driver.FindElements(By.CssSelector(name)),
                Locators.ID => Driver.FindElements(By.Id(name)),
                Locators.Name => Driver.FindElements(By.Name(name)),
                Locators.LinkText => Driver.FindElements(By.LinkText(name)),
                Locators.ClassName => Driver.FindElements(By.ClassName(name)),
                Locators.PartialLinkText => Driver.FindElements(By.PartialLinkText(name)),
                Locators.TagName => Driver.FindElements(By.TagName(name)),
                _ => throw new ArgumentOutOfRangeException(type.ToString(), $"Invalid Type, {type.ToString()}")
            };
        }

        //Helper function to get current url
        public string GetCurrentUrl()
        {
            return Driver.Url;
        }

        //Helper function to get Page Title
        public string GetTitle()
        {
            return Driver.Title;
        }

        //Helper function to navigate to desired url
        public void GoToUrl(string url)
        {
            var uri= new Uri(url);
            Driver.Navigate().GoToUrl(uri);
        }

        //Helper function to get Text of Web Element
        public string GetText(IWebElement element)
        {
            return element.Text;
        }

        public void TakeScreenshot()
        {
            ITakesScreenshot? screenshotDriver =
            Driver as ITakesScreenshot;

            Screenshot screenshot = screenshotDriver.GetScreenshot();

            string fileName = "Test"+String.Format(DateTime.Now.ToString("MM-dd-yyyy_hh-mm-ss-tt"))+ ".png";
            string screenshotDirectory = Path.Combine(Utility.GetProjectRootDirectory(), "TestScreenshots\\");
            if (!Directory.Exists(screenshotDirectory))
            {
                Directory.CreateDirectory(screenshotDirectory);
            }

            string path = Path.Combine(screenshotDirectory, fileName);

            screenshot.SaveAsFile(fileName);
        }

        /// <summary>
        /// Function to selection a option from SubMenu
        /// </summary>
        /// <param name="menuOption">Parent Menu</param>
        /// <param name="subMenuOption">Sub Menu</param>
        public void SelectMenuOption(IWebElement menuOption,IWebElement subMenuOption)
        {       

            //Retrieve Parent Menu WebElement to perform mouse hover 
            //menuOption = Map.CompanyMenu;            //Mouse hover parent menuOption
            actions.MoveToElement(menuOption).Build().Perform();

            //Now Select 'Rock' from sub menu which has got displayed on mouse hover of 'Music'
            //IWebElement subMenuOption = Map.CareerMenu;            //Mouse hover menuOption Sub Menu
            actions.MoveToElement(subMenuOption).Build().Perform();

            //Now , finally, it displays the desired menu list from which required option needs to be selected
            //Now Select 'Alternative' from sub menu which has got displayed on mouse hover of Sub Menu
            subMenuOption.Click();
        }

        /// <summary>
        /// Switch to IFrame
        /// </summary>
        /// <param name="iFrame"></param>
        public void SwitchToIFrame(IWebElement iFrame)
        {
            Driver.SwitchTo().Frame(iFrame);
        }

        /// <summary>
        /// Switch To Parent IFrame
        /// </summary>
        public void SwitchToParentIFrame()
        {
            Driver.SwitchTo().ParentFrame();
        }

        /// <summary>
        /// Switch to default content
        /// </summary>
        public void SwitchToDefaultContent()
        {
            Driver.SwitchTo().DefaultContent();
        }

        /// <summary>
        /// Click on Element using JavaScriptExecutor
        /// </summary>
        /// <param name="element">IWebElement</param>
        public void ClickOnElementUsingJS(IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)Driver;
            jsDriver.ExecuteScript("arguments[0].click()", element);
        }
    }
}
