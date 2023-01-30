using ApiTestProject.Globals;
using Newtonsoft.Json;

namespace ApiTestProject
{
    [Parallelizable]
    public class GetPostTests: BaseTests
    {
        public GetPostTests():base() 
        {

        }

        /// <summary>
        /// Parameterized Happy path test for Get Posts Request
        /// </summary>
        /// <returns></returns>
        [TestCaseSource(typeof(PostsFileInputSource<Posts>))]
        [Ignore("Run this test when required since it runs for 100+ iterations")]
        public async Task GetPostsParameterizedTest(Posts param)
        {
            response = await Controller.GetResponse("/posts/"+param.id, HttpMethodType.Get, client, null);

            Assert.IsTrue(response.IsSuccessStatusCode);

            var result = response.Content.ReadAsStringAsync().Result;

            var userDetails = JsonConvert.DeserializeObject<UserPostDetails>(result);

            Assert.IsNotNull(userDetails);

            FluentAssertionsHelper.AssertJsonModel(userDetails, param);
        }

        /// <summary>
        /// Happy path test for Get Posts Request
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetPostsHappyPathTest()
        {
            response = await Controller.GetResponse("/posts/1", HttpMethodType.Get, client, null);

            Assert.IsTrue(response.IsSuccessStatusCode);

            var result = response.Content.ReadAsStringAsync().Result;

            var userDetails = JsonConvert.DeserializeObject<UserPostDetails>(result);
            
            Assert.IsNotNull(userDetails);

            FluentAssertionsHelper.AssertNumbers(((int)userDetails.Id), 1);
            FluentAssertionsHelper.AssertNumbers(((int)userDetails.UserId), 1);
            FluentAssertionsHelper.AssertStrings(userDetails.Body, "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto");
            FluentAssertionsHelper.AssertStrings(userDetails.Title, "sunt aut facere repellat provident occaecati excepturi optio reprehenderit");
        }

        /// <summary>
        /// Negative Get post test with invalid id
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetPostsNotFoundNegativeTest()
        {
            response = await Controller.GetResponse("/posts/1011", HttpMethodType.Get, client, null);

            Assert.IsFalse(response.IsSuccessStatusCode);

            StringAssert.IsMatch(response.StatusCode.ToString(), "NotFound");           
        }

        /// <summary>
        /// Negative Get post test with invalid api url
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetPostsInvalidUrlNegativeTest()
        {
            response = await Controller.GetResponse("/post", HttpMethodType.Get, client, null);

            Assert.IsFalse(response.IsSuccessStatusCode);

            StringAssert.IsMatch(response.StatusCode.ToString(), "NotFound");
        }

    }
}
