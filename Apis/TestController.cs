﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace Apis
{
    [Route("test")]
    public class TestController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;

            var subjectClaim = caller.FindFirst("sub");

            if (subjectClaim != null)
            {
                return Json(new {
                    message = "OK user",
                    client = caller.FindFirst("client_id").Value,
                    subject = subjectClaim.Value
                });
            }

            return Json(new 
            { 
                message = "OK computer",
                client = caller.FindFirst("client_id").Value
            });
        }

    }
}