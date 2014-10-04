using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FM_Grupo2.Startup))]
namespace FM_Grupo2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
