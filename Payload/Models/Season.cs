using Newtonsoft.Json;

namespace Payload.Models
{
    public class Season
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}