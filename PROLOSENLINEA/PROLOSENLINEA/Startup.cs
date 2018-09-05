using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PROLOSENLINEA.Startup))]
namespace PROLOSENLINEA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
