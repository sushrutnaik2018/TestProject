using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestProject
{
    [TestFixture]
    public class CompanyPageTests : BaseTest
    {
        [Test]
        [Description("Navigate Company Section")]
        [Author("Sushrut Naik")]

        public void NavigateToCompaySection()
        {
            Pages.Home.GoTo();
            Pages.Home.ValidateHomePage();
            Pages.Home.HoverCompanyMenu();
            Pages.Company.NavigateToCareerPage();            
        }

    }
}
