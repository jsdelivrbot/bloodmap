using BloodMap.Data.Context;
using BloodMap.Data.ViewModel;
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
    public class DonorController : ApiController
    {
        private IDonorService _donorService;
        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }
        [HttpPost]
        [Route("api/searchdonor")]
        public HttpResponseMessage SearchDonor(SearchDonor searchDonor)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _donorService.SearchDonors(searchDonor));
        }

    }
}
