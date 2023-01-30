using ApiTestProject.Globals;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject
{
    [Parallelizable]
    public class PostCommentsTests:BaseTests
    {
        public PostCommentsTests():base() { }

        /// <summary>
        /// Happy path test for Post comments request
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task PostCommentsHappyPathTest()
        {
            var commentDetails = new
            {
                postid = 100,
                name = "Nulla ut dolor vel molestiae neque sunt temporibus",
                email = "Alice_Considine@daren.com",
                body = "Occaecati sed sit, sed quis, dolores et similique"
            };

            response = await Controller.GetResponse("/posts/100/comments", HttpMethodType.Post, client, commentDetails);

            Assert.IsTrue(response.IsSuccessStatusCode);

            var result = response.Content.ReadAsStringAsync().Result;
            var commentResponseDetails = JsonConvert.DeserializeObject<CommentsDetails>(result);

            Assert.IsNotNull(commentResponseDetails);
            FluentAssertionsHelper.AssertStrings(commentResponseDetails.Name, commentDetails.name);
            FluentAssertionsHelper.AssertStrings(commentResponseDetails.Email, commentDetails.email);
            FluentAssertionsHelper.AssertStrings(commentResponseDetails.Body, commentDetails.body);
            FluentAssertionsHelper.AssertNumbers((int)commentResponseDetails.PostId, commentDetails.postid);
        }

        /// <summary>
        /// Negative Post Comments test with invalid data
        /// </summary>
        /// <returns></returns>
        [Test()]
        public async Task PostCommentsNegativeTest()
        {
            response = await Controller.GetResponse("/comment", HttpMethodType.Post, client, null);

            Assert.IsFalse(response.IsSuccessStatusCode);

            StringAssert.IsMatch(response.StatusCode.ToString(), "NotFound");
        }
    }
}
