using Microsoft.Azure.CosmosRepository;
using Newtonsoft.Json;
using System;

namespace Data
{
    public class Image : Item
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("explanation")]
        public string Explanation { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public bool IsNew => Date > DateTime.Today.AddDays(-3);

    }
}