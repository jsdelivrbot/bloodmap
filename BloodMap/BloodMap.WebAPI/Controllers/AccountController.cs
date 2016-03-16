﻿using BloodMap.Data.Context;
using BloodMap.Service.Contract;
using BloodMap.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace BloodMap.WebAPI.Controllers
{
    public class AccountController : ApiController
    {
        private IAccountService _accountService;

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
                _accountService = new AccountService();
                user.UserId = _accountService.AddUser(user);
                return Request.CreateResponse(HttpStatusCode.OK, "Registered Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ex.Message);
            }
        }
    }
}
