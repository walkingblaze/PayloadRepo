using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Payload.Models;

namespace Payload.IServices
{
    public interface IFilterShowsService
    {
        PayloadResponse Filter(PayloadViewModel data);
    }
}
