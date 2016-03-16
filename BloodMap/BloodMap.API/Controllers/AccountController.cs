using BloodMap.Data.Context;
using BloodMap.Service.Contract;
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

namespace BloodMap.API.Controllers
{
    public class AccountController : ApiController
    {
        private IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        [Route("api/profile")]
        [Authorize]
        public HttpResponseMessage Profile()
        {
            var pass = ((ClaimsIdentity)User.Identity).FindFirst("Password");
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(new
                {
                    UserName = User.Identity.Name
                }, Configuration.Formatters.JsonFormatter)
            };
        }

        [HttpPost]
        [Route("api/register")]
        [AllowAnonymous]
        public HttpResponseMessage Register(User user)
        {
            try
            {
                user.UserId = _accountService.AddUser(user);
                if (user.UserId > 0)
                {

                    var identity = new ClaimsIdentity(Startup.OAuthOptions.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.EmailId));
                    identity.AddClaim(new Claim("FirstName", user.FirstName));
                    identity.AddClaim(new Claim("UserId", Convert.ToString(user.UserId)));

                    AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
                    var currentUtc = new SystemClock().UtcNow;
                    ticket.Properties.IssuedUtc = currentUtc;
                    ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));

                    var token = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);
                    var response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ObjectContent<object>(new
                        {
                            UserName = user.EmailId,
                            AccessToken = token
                        }, Configuration.Formatters.JsonFormatter)
                    };

                    FormsAuthentication.SetAuthCookie(user.EmailId, true);

                    return response;
                }
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "User not registered");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ex.Message);
            }
        }
    }
}
