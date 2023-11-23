using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Capitulo06IdentityMVC.WEB.Startup))]
namespace Capitulo06IdentityMVC.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
