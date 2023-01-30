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
    public class GetCommentsTests:BaseTests
    {
        public GetCommentsTests():base() { }

        /// <summary>
        /// Parameterized Happy path test for Get Comments Request
        /// </summary>
        /// <returns></returns>
        [TestCaseSource(typeof(CommentsFileInputSource<Comments>))]
        public async Task GetCommentsParameterizedTest(Comments param)
        {
            response = await Controller.GetResponse("/comments?postId=" + param.postId, HttpMethodType.Get, client, null);

            Assert.IsTrue(response.IsSuccessStatusCode);

            var result = response.Content.ReadAsStringAsync().Result;

            var commentDetails = JsonConvert.DeserializeObject<List<CommentsDetails>>(result);

            Assert.IsNotNull(commentDetails);

            foreach(var comment in commentDetails)
            {
                if(comment.Id == param.id)
                    FluentAssertionsHelper.AssertJsonModel(comment, param);
            }
                
        }

        /// <summary>
        /// Happy path test for Get Comments Request
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetCommentsHappyPathTest()
        {
            response = await Controller.GetResponse("/comments?postId=99", HttpMethodType.Get, client, null);

            Assert.IsTrue(response.IsSuccessStatusCode);

            var result = response.Content.ReadAsStringAsync().Result;
            var commentDetails = JsonConvert.DeserializeObject<List<CommentsDetails>>(result);

            Assert.IsNotNull(commentDetails);
            foreach (var comment in commentDetails)
                FluentAssertionsHelper.AssertNumbers(((int)comment.PostId), 99);
        }

        /// <summary>
        /// Negative Get post test with invalid api url
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetCommentsTestError()
        {
            response = await Controller.GetResponse("/comment", HttpMethodType.Get, client, null);

            Assert.IsFalse(response.IsSuccessStatusCode);

            StringAssert.IsMatch(response.StatusCode.ToString(), "NotFound");
        }
    }
}
