using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestProject
{
    [TestFixture]
    public class CareersPageTests: BaseTest
    {
        [Test]
        [Description("Navigate Second Manager Jobs Page")]
        [Author("Sushrut Naik")]
        public void NavigateToSecondManagerJobsPage()
        {
            Pages.Home.GoTo();
            Pages.Home.ValidateHomePage();
            Pages.Home.HoverCompanyMenu();
            Pages.Company.NavigateToCareerPage();
            Pages.Careers.NavigateToOpenPositionSection();
            Pages.OpenPositions.ValidateOpenPositionSection();
            Pages.OpenPositions.ClickSecondManagerLink();
            
        }
    }
}
