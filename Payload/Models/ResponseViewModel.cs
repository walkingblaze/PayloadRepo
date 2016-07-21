using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Payload.Models
{
    public class ResponseViewModel
    {
        [JsonProperty("response")]
        public List<Response> Response { get; set; }

        
    }
}