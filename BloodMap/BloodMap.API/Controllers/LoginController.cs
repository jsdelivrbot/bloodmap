using BloodMap.API.Models;
using BloodMap.Service.Contract;
using BloodMap.Service.Utility;
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
using System.Web.Http.Cors;
using System.Web.Security;

namespace BloodMap.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {

        private IAccountService _accountService;
        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginModel login)
        {

            var loginDetails = _accountService.VerifyLogin(login.UserName, login.Password);
            if (loginDetails != null)
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
                HttpResponseMessage response;
                if (login.RememberMe)
                {
                    Guid seriesIdentifier = Guid.NewGuid();
                    string encToken = Hashing.GetHashSha256(new Guid().ToString());
                    _accountService.InsertSecurityToken(new Data.Context.Re_Handshake()
                    {
                        CreatedDate = DateTime.Now,
                        Id = Guid.NewGuid(),
                        SeriesIdentifier = seriesIdentifier.ToString(),
                        Token = encToken,
                        UserId = loginDetails.UserId,
                        LastLogin = null
                    });
                    response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ObjectContent<object>(new
                        {
                            UserName = login.UserName,
                            AccessToken = token,
                            SeriesIdentifier = seriesIdentifier,
                            RefreshToken = encToken
                        }, Configuration.Formatters.JsonFormatter)
                    };
                }
                else
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ObjectContent<object>(new
                        {
                            UserName = login.UserName,
                            AccessToken = token
                        }, Configuration.Formatters.JsonFormatter)
                    };
                }
                FormsAuthentication.SetAuthCookie(login.UserName, true);

                return response;
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/refreshtoken")]
        public HttpResponseMessage RefreshToken(ReHandshakeModel login)
        {

            var loginDetails = _accountService.VerifyReHandshake(login.SeriesIdentifier, login.RefreshToken);
            if (loginDetails != null)
            {

                var identity = new ClaimsIdentity(Startup.OAuthOptions.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, loginDetails.EmailId));
                identity.AddClaim(new Claim("FirstName", loginDetails.FirstName));
                identity.AddClaim(new Claim("UserId", Convert.ToString(loginDetails.UserId)));

                AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
                var currentUtc = new SystemClock().UtcNow;
                ticket.Properties.IssuedUtc = currentUtc;
                ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));

                var token = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);
                HttpResponseMessage response;

                Guid seriesIdentifier = Guid.NewGuid();
                string encToken = Hashing.GetHashSha256(new Guid().ToString());
                _accountService.InsertSecurityToken(new Data.Context.Re_Handshake()
                {
                    CreatedDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    SeriesIdentifier = seriesIdentifier.ToString(),
                    Token = encToken,
                    UserId = loginDetails.UserId,
                    LastLogin = null
                });
                response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<object>(new
                    {
                        UserName = loginDetails.EmailId,
                        AccessToken = token,
                        SeriesIdentifier = seriesIdentifier,
                        RefreshToken = encToken
                    }, Configuration.Formatters.JsonFormatter)
                };


                FormsAuthentication.SetAuthCookie(loginDetails.EmailId, true);

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
