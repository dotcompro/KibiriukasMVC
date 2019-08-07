using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kibiriukas.Startup))]
namespace Kibiriukas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
