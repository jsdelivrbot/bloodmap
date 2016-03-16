using BloodMap.WebAPI.Models;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Security;

namespace BloodMap.WebAPI.Controllers
{
    [AllowAnonymous]
    public class PingController : ApiController
    {
        public HttpResponseMessage Get()
        { return Request.CreateResponse(HttpStatusCode.OK, "Hello"); }
    }
}
