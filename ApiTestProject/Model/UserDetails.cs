using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApiTestProject
{
    /// <summary>
    /// Model for Posts test
    /// </summary>
    public partial class UserPostDetails
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }

    /// <summary>
    /// To be removed - Do not use
    /// </summary>
    public partial class UserPostDetails
    {
        public static List<UserPostDetails> FromJson(string json) => JsonConvert.DeserializeObject<List<UserPostDetails>>(json, Converter.Settings);
    }

    /// <summary>
    /// To be removed - Do not use
    /// </summary>
    public static class SerializeUserPostDetails
    {
        public static string ToJson(this List<UserPostDetails> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    
}
