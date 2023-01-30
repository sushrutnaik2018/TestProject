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
    public class PutPostsTests:BaseTests
    {
        public PutPostsTests() : base()
        {

        }

        /// <summary>
        /// Happy path test for Put request
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task PutPostsHappyPathTest()
        {
            var postDetails = new
            {
                userId = 10,
                id = 100,
                title = "sed labore harum quidem eveniet",
                body = "cupiditate, modi nesciunt soluta"
            };

            response = await Controller.GetResponse("/posts/100", HttpMethodType.Put, client, postDetails);

            Assert.IsTrue(response.IsSuccessStatusCode);

            var result = response.Content.ReadAsStringAsync().Result;
            var postResponseDetails = JsonConvert.DeserializeObject<UserPostDetails>(result);

            Assert.IsNotNull(postResponseDetails);
            FluentAssertionsHelper.AssertJsonModel(postResponseDetails, postDetails);


        }

        /// <summary>
        /// Negative path test for Put request with invalid data
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task PutPostsNegativePathTest()
        {
            var postDetails = new
            {
                userId = 10,
                id = 101,
                title = "sed labore harum quidem eveniet",
                body = "cupiditate, modi nesciunt soluta"
            };

            response = await Controller.GetResponse("/post", HttpMethodType.Put, client, postDetails);

            Assert.IsFalse(response.IsSuccessStatusCode);

            StringAssert.IsMatch(response.StatusCode.ToString(), "NotFound");
        }
    }
}
