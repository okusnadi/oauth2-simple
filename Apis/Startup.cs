﻿using IdentityServer3.AccessTokenValidation;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Apis
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // accept access tokens from identityserver and require a scope of 'api1'
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44333",
                ValidationMode = ValidationMode.ValidationEndpoint,

                RequiredScopes = new[] { "api1" }
            });

            // configure web api
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            // require authentication for all controllers. Moved to controller
            //config.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(config);
        }
    }
}