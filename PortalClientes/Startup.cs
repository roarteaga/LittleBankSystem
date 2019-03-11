using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PortalClientes.Startup))]
namespace PortalClientes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
