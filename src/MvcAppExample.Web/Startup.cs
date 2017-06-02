using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MvcAppExample.Web.Startup))]
namespace MvcAppExample.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
