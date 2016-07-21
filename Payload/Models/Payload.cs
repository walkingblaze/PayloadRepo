using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Payload.Models
{
    public class Payload
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("drm")]
        public bool Drm { get; set; }
        [JsonProperty("episodeCount")]
        public int EpisodeCount { get; set; }
        [JsonProperty("genre")]
        public string Genre { get; set; }
        [JsonProperty("image")]
        public Image Image { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("nextEpisode")]
        public NextEpisode NextEpisode { get; set; }
        [JsonProperty("primaryColour")]
        public string PrimaryColour { get; set; }
        [JsonProperty("seasons")]
        public IList<Season> Seasons { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("tvChannel")]
        public string TvChannel { get; set; }
    }
}