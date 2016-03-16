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
    public class ValuesController : ApiController
    {
        private IAccountService accserv;
        public ValuesController(IAccountService account)
        {
            accserv = account;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
       
       
        // GET api/values/5
        public string Get(int id)
        {
            var x = accserv.GetUser(1);
            return "value";
        }

        // POST api/values
        [Route("api/sagar")]
        public void Post([FromBody]string value)
        {
            var x = accserv.GetUser(1);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
