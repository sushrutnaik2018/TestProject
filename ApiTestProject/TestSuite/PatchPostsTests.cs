using ApiTestProject.Globals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject
{
    [Parallelizable]
    public class PatchPostsTests:BaseTests
    {
        public PatchPostsTests() : base()
        {

        }

        /// <summary>
        /// Happy path test for Patch request
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task PatchPostsHappyPathTest()
        {
            var postDetails = new
            {
                body = "cupiditate, modi nesciunt soluta"
            };

            response = await Controller.GetResponse("/posts/100", HttpMethodType.Patch, client, postDetails);

            Assert.IsTrue(response.IsSuccessStatusCode);

            var result = response.Content.ReadAsStringAsync().Result;
            var postResponseDetails = JsonConvert.DeserializeObject<UserPostDetails>(result);

            Assert.IsNotNull(postResponseDetails);
            FluentAssertionsHelper.AssertStrings(postResponseDetails.Body, postDetails.body);
        }

        /// <summary>
        /// Negative path test for Patch request with invalid data
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task PatchPostsNegativePathTest()
        {
            var postDetails = new {};            

            response = await Controller.GetResponse("/post", HttpMethodType.Patch, client, postDetails);

            Assert.IsFalse(response.IsSuccessStatusCode);
            StringAssert.IsMatch(response.StatusCode.ToString(), "NotFound");

        }



    }
}
