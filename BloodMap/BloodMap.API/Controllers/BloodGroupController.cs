using BloodMap.API.Models;
using BloodMap.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodMap.API.Controllers
{
    [Authorize]
    public class BloodGroupController : ApiController
    {
        private IBloodGroupService _bloodGroupService;
        public BloodGroupController(IBloodGroupService bloodGroupService)
        {
            _bloodGroupService = bloodGroupService;
        }
        [HttpGet]
        [Route("api/lookup/bloodgroup")]
        public HttpResponseMessage GetBloodGroups()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _bloodGroupService.GetAll());
        }
    }
}
