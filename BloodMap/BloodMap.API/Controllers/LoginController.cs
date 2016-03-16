using BloodMap.API.Models;
using BloodMap.Service.Contract;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace BloodMap.API.Controllers
{
    public class LoginController : ApiController
    {

        private IAccountService _accountService;
        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/kill")]
        public HttpResponseMessage Login(LoginModel login)
        {
            var authenticated = false;
            
            var loginDetails = _accountService.VerifyLogin(login.UserName, login.Password);
            if (authenticated || loginDetails != null)
            {

                var identity = new ClaimsIdentity(Startup.OAuthOptions.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, login.UserName));
                identity.AddClaim(new Claim("FirstName", loginDetails.FirstName));
                identity.AddClaim(new Claim("UserId", Convert.ToString(loginDetails.UserId)));

                AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
                var currentUtc = new SystemClock().UtcNow;
                ticket.Properties.IssuedUtc = currentUtc;
                ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));

                var token = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<object>(new
                    {
                        UserName = login.UserName,
                        AccessToken = token
                    }, Configuration.Formatters.JsonFormatter)
                };

                FormsAuthentication.SetAuthCookie(login.UserName, true);

                return response;
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        // POST api/User/Logout
        [HttpPost]
        [Authorize]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            //Request.GetOwinContext().Authentication.SignOut(Startup.OAuthOptions.AuthenticationType);
            HttpContext.Current.GetOwinContext().Authentication.SignOut(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie);
            return Request.CreateResponse(HttpStatusCode.OK, (new { message = "Logout successful." }));
        }

    }
}
