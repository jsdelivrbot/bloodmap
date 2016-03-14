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

        [HttpPost]
        [AllowAnonymous]
        [Route("api/account/login")]
        public HttpResponseMessage Login(LoginModel login)
        {
            var authenticated = false;
            if (authenticated || (login.UserName == "a" && login.Password == "a"))
            {
                var identity = new ClaimsIdentity(Startup.OAuthOptions.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, login.UserName));

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
    }
}
