using System.Collections.Generic;
using Newtonsoft.Json;

namespace Payload.Models
{
    public class PayloadViewModel
    {
        [JsonProperty("payload")]
        public IList<Payload> Payload { get; set; }
        [JsonProperty("skip")]
        public int Skip { get; set; }
        [JsonProperty("take")]
        public int Take { get; set; }
        [JsonProperty("totalRecords")]
        public int TotalRecords { get; set; }
    }
}