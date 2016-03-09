using BloodMap.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodMap.API.Controllers
{
    public class PingController : ApiController
    {
        public PingController()
        {

        }
        /// <summary>
        /// Ping API to test the connectivity
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public BMHttpResponse Get()
        {
            return new BMHttpResponse { Message = "Ping" };
           
        }
    }
}
