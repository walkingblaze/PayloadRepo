using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Payload.IServices;
using Payload.Models;
using Payload.Services;

namespace Payload.Controllers
{
    public class PayloadsController : ApiController
    {
        private IFilterShowsService _filterShowsService;
        [HttpPost]
        public HttpResponseMessage FilterShows(PayloadViewModel data)
        {
            _filterShowsService = new FilterShowsService();
            var response = _filterShowsService.Filter(data);
            return Request.CreateResponse(response.Status,response.ResponseData);


        }
    }
}
