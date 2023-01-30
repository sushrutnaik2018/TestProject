using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject
{
    /// <summary>
    /// Model for Comments test
    /// </summary>
    public partial class CommentsDetails
    {
        [JsonProperty("postId")]
        public long PostId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }

    /// <summary>
    /// To be removed - Do not use
    /// </summary>
    public partial class CommentsDetails
    {
        public static List<CommentsDetails> FromJson(string json) => JsonConvert.DeserializeObject<List<CommentsDetails>>(json, Converter.Settings);
    }

    /// <summary>
    /// To be removed - Do not use
    /// </summary>
    public static class SerializeCommentsDetails
    {
        public static string ToJson(this List<CommentsDetails> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}

