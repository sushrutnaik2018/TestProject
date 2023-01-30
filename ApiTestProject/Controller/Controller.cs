using ApiTestProject.Globals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject
{
    /// <summary>
    /// This provides methods for building HTTP Request and provides HTTP Response
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Purpose of this method is to Setup HTTPClient for HTTPRequest
        /// </summary>
        /// <param name="uri">uri</param>
        /// <returns>http client</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static HttpClient GetClient(Uri uri)
        {
            var httpClientHandler = new HttpClientHandler();

            if (uri is null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            var client = new HttpClient(httpClientHandler)
            {
                BaseAddress = uri
            };

            return client;
        }

        /// <summary>
        /// Purpose of this method is to build reqest and return response
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="requestType"></param>
        /// <param name="client"></param>
        /// <param name="model"></param>
        /// <returns>Task<HttpResponseMessage></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public static Task<HttpResponseMessage> GetResponse(string uri, string requestType, HttpClient client, object model)
        {
            #region Build Request
            HttpRequestMessage request;

            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentException($"'{nameof(uri)}' cannot be null or empty.", nameof(uri));
            }

            if (string.IsNullOrEmpty(requestType))
            {
                throw new ArgumentException($"'{nameof(requestType)}' cannot be null or empty.", nameof(requestType));
            }

            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            request = GetMessage(uri, requestType);

            if (model != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, MimeTypes.ApplicationJson);
            } 
            #endregion

            return client.SendAsync(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="requestType"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static HttpRequestMessage GetMessage(string uri, string requestType)
        {
            HttpRequestMessage request;

            #region Determine and set HTTP Method Type
            switch (requestType)
            {
                case HttpMethodType.Get:
                    request = new HttpRequestMessage(HttpMethod.Get, uri);
                    ExtentReportMessages.Pass(requestType);
                    break;
                case HttpMethodType.Delete:
                    request = new HttpRequestMessage(HttpMethod.Delete, uri);
                    ExtentReportMessages.Pass(requestType);
                    break;
                case HttpMethodType.Post:
                    request = new HttpRequestMessage(HttpMethod.Post, uri);
                    ExtentReportMessages.Pass(requestType);
                    break;
                case HttpMethodType.Put:
                    request = new HttpRequestMessage(HttpMethod.Put, uri);
                    ExtentReportMessages.Pass(requestType);
                    break;
                case HttpMethodType.Patch:
                    request = new HttpRequestMessage(new HttpMethod("PATCH"), uri);
                    ExtentReportMessages.Pass(requestType);
                    break;
                default:
                    ExtentReportMessages.Fail($"Request type: {requestType} is not implemented.");
                    throw new NotImplementedException($"Request type: {requestType} is not implemented.");
            } 
            #endregion

            return request;
        }
    }
}
