using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAuth.Mvc.Startup))]
namespace WebAuth.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
