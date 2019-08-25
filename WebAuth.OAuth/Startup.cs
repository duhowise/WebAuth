using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebAuth.OAuth.Startup))]

namespace WebAuth.OAuth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var manager=new InMemoryManager();
            var factory=new IdentityServerServiceFactory()
                .UseInMemoryClients(manager.GetClients())
                .UseInMemoryScopes(manager.GetScopes())
                .UseInMemoryUsers(manager.GetUsers());
            var certificate = Convert.FromBase64String(ConfigurationManager.AppSettings["SigningCertificate"]);
            var options=new IdentityServerOptions
            {
                SigningCertificate = new X509Certificate2(certificate,ConfigurationManager.AppSettings["SigningCertificatePassword"]),
                RequireSsl = false,
                Factory = factory
            };
            app.UseIdentityServer(options);
        }
    }
}
