using Newtonsoft.Json;

namespace Payload.Models
{
    public class NextEpisode
    {
        [JsonProperty("channel")]
        public object Channel { get; set; }
        [JsonProperty("channelLogo")]
        public string ChannelLogo { get; set; }
        [JsonProperty("date")]
        public object Date { get; set; }
        [JsonProperty("html")]
        public string Html { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}