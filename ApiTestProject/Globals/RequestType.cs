using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject.Globals
{
    /// <summary>
    /// This class is defined to provide Http Method Type constants for HTTPRequestMessage
    /// </summary>
    public class HttpMethodType
    {
        /// <summary>
        /// Set HttpRequestMessage type to 'get'
        /// </summary>
        public const string Get = nameof(Get);

        /// <summary>
        /// Set HttpRequestMessage type to 'delete'
        /// </summary>
        public const string Delete = nameof(Delete);

        /// <summary>
        /// Set HttpRequestMessage type to 'post'
        /// </summary>
        public const string Post = nameof(Post);

        /// <summary>
        /// Set HttpRequestMessage type to 'put'
        /// </summary>
        public const string Put = nameof(Put);

        /// <summary>
        /// Set HttpRequestMessage type to 'patch'
        /// </summary>
        public const string Patch = nameof(Patch);
    }
}
