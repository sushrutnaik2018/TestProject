using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestProject
{
    // Main test class

    [TestFixture]
    public class HomepageTests : BaseTest
    {

        [Test]
        [Description("Launch AGDATA site")]
        [Author("Sushrut Naik")]

        public void LaunchSite()
        {
            Pages.Home.GoTo();
            Pages.Home.ValidateHomePage();
        }
    }
}
