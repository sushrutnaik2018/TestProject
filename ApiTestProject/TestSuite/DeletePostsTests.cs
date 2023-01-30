using ApiTestProject.Globals;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject
{
    [Parallelizable]
    public class DeletePostsTests:BaseTests
    {
        public DeletePostsTests():base() { }

        /// <summary>
        /// Happy path test for Delete Request
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task DeletePostsHappyPathTest()
        {
            response = await Controller.GetResponse("/posts/100", HttpMethodType.Delete, client, null);

            Assert.IsTrue(response.IsSuccessStatusCode);

            StringAssert.IsMatch(response.StatusCode.ToString(), "OK");
        }
        
        /// <summary>
        /// Negative path test for Delete request
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task DeletePostsNegativePathTest()
        {
            response = await Controller.GetResponse("/posts", HttpMethodType.Delete, client, null);

            Assert.IsFalse(response.IsSuccessStatusCode);

            StringAssert.IsMatch(response.StatusCode.ToString(), "NotFound");
        }

    }
}
