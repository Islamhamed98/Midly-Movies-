using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Midly.Startup))]
namespace Midly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
