using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebM.Startup))]
namespace WebM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
