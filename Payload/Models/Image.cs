using Newtonsoft.Json;

namespace Payload.Models
{
    public class Image
    {
        [JsonProperty("showImage")]
        public string ShowImage { get; set; }
    }
}