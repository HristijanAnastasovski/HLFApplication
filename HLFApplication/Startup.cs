using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HLFApplication.Startup))]
namespace HLFApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
