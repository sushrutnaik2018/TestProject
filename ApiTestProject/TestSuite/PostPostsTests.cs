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
    public class PostPostsTests:BaseTests
    {
        public PostPostsTests() : base()
        {

        }

        /// <summary>
        /// Happy Path test for Post Posts request 
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task PostPostsHappyPathTest()
        {
            var postDetails = new
            {
                userId = 10,
                title = "sed labore harum quidem eveniet",
                body = "cupiditate, modi nesciunt soluta"
            };

            response = await Controller.GetResponse("/posts", HttpMethodType.Post, client, postDetails);

            Assert.IsTrue(response.IsSuccessStatusCode);

            var result = response.Content.ReadAsStringAsync().Result;
            var postResponseDetails = JsonConvert.DeserializeObject<UserPostDetails>(result);
            

            Assert.IsNotNull(postResponseDetails);
            FluentAssertionsHelper.AssertStrings(postResponseDetails.Title, postDetails.title); 
            FluentAssertionsHelper.AssertStrings(postResponseDetails.Body,postDetails.body);
            FluentAssertionsHelper.AssertNumbers((int)postResponseDetails.UserId, postDetails.userId);
        }

        /// <summary>
        /// Negative Post Posts test with invalid data
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task PostPostsNegativePathTest()
        {   
            response = await Controller.GetResponse("/posts/99", HttpMethodType.Post, client, null);

            Assert.IsFalse(response.IsSuccessStatusCode);

            StringAssert.IsMatch(response.StatusCode.ToString(), "NotFound");
        }
    }
}
