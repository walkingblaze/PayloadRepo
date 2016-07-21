using Newtonsoft.Json;

namespace Payload.Models
{
    public class ErrorViewModel
    {
        [JsonProperty("error")]
        public string Error { get; set; } = "Could not decode request: JSON parsing failed";

        public static ErrorViewModel New()
        {
            return new ErrorViewModel();
        }
    }
}