using Newtonsoft.Json;
using System.Collections.Generic;

namespace EaseCentral.Models
{
    public class RedditJson
    {
        [JsonProperty("data")]
        public RedditData Data { get; set; }
    }

    public class RedditData
    {
        [JsonProperty("children")]
        public List<Child> Children { get; set; }
    }

    public class Child
    {
        [JsonProperty("data")]
        public ChildData Data { get; set; }
    }

    public class ChildData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }
    }

    public class RedditResponse
    {
        [JsonProperty("reddit_id")]
        public string Id { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }
    }

    public class FavoriteResponse
    {
        public Status Status { get; set; }

        public string Message { get; set; }
    }

    public enum Status
    {
        Success,
        Failure
    }
}