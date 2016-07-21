using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Payload.Models
{
    public class Response
    {
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}