using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Payload.Models
{
    public class PayloadResponse
    {
        public HttpStatusCode Status { get; set; }

        public object ResponseData { get;set;}

        public static PayloadResponse Create(HttpStatusCode status, object responseData)
        {
            return new PayloadResponse {Status = status, ResponseData = responseData};
        }

    }
}