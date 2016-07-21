using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Payload.IServices;
using Payload.Models;
using System.Net.Http;
using Microsoft.Owin.Security.Provider;

namespace Payload.Services
{
    public class FilterShowsService : IFilterShowsService
    {
        public PayloadResponse Filter(PayloadViewModel data)
        {
            if (data == null) return PayloadResponse.Create(HttpStatusCode.BadRequest, ErrorViewModel.New());

            var filteredShows = new ResponseViewModel();

            IReadOnlyList<Models.Payload> shows = data.Payload.Skip(data.Skip).Take(data.Take).ToList();

            filteredShows.Response = shows.Where(x => x.Drm && x.EpisodeCount > 0)
                .Select(r => new Response { Image = r.Image.ShowImage, Slug = r.Slug, Title = r.Title })
                .ToList();

            return PayloadResponse.Create(HttpStatusCode.OK, filteredShows);
        }
    }
}