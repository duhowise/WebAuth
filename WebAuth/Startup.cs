using System;
using System.Threading.Tasks;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Owin;

[assembly: OwinStartup(typeof(WebAuth.Startup))]

namespace WebAuth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(
                
                new IdentityServerBearerTokenAuthenticationOptions
                {
                    Authority = "http://localhost:64137"
                });
        }
    }
}
