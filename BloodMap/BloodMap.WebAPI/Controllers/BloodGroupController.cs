using BloodMap.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodMap.WebAPI.Controllers
{
    [Authorize]
    public class BloodGroupController : ApiController
    {
        private IBloodGroupService _bloodGroupService;
        public BloodGroupController(IBloodGroupService bloodGroupService)
        {
            _bloodGroupService = bloodGroupService;
        }

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _bloodGroupService.Get());
        }

        // GET api/bloodgroup/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _bloodGroupService.Get(id));
        }
    }
}
