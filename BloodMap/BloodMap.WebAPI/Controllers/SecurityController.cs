using BloodMap.Data.Context;
using BloodMap.Service.Contract;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodMap.WebAPI.Controllers
{
    public class SecurityController : ApiController
    {
        private IAccountService _accountService;
        public SecurityController(IAccountService Accserv)
        {
            _accountService = Accserv;
        } 
        [HttpPost]
        [AllowAnonymous]
        [Route("api/auth")]
        public HttpResponseMessage Authenticate(Login login)
        {
            var authenticated = false;
            //_accountService = new AccountService();
            var loginDetails = _accountService.VerifyLogin(login.EmailId, login.Password);
            if (authenticated || loginDetails != null)
            {
              
              
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);

        }
    }
}
