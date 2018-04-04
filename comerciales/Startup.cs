using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(comerciales.Startup))]
namespace comerciales
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
